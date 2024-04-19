using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResoniteGBApp
{
    public class FrameData
    {
        public static Bitmap _cachedBitmap;
        public static Bitmap _simulatedCanvas;
        public static int[] rowContiguousSpanEndIndices;

        private static Dictionary<int, List<int>> rgbToSpans; // Map RGB values to spans
        private static IntPtr cachedWindowHandle = IntPtr.Zero;
        private static string cachedWindowTitle = "";

        private static Dictionary<int, int> rowExpansionAmounts;
        private static List<int> contiguousRangePairs;
        private static Dictionary<int, List<Color>> cachedRowPixels;


        static FrameData()
        {
            //initializeAllColors();
            Initialize();
        }

        public static void Initialize()
        {
            rowExpansionAmounts = null;
            contiguousRangePairs = new List<int>();
            cachedRowPixels = new Dictionary<int, List<Color>>();
        }

        // Define GameBoy greyscale colors as indices
        private static readonly Color[] GameBoyColors = new Color[] {
            Color.FromArgb(255, 255, 255), // White
            Color.FromArgb(192, 192, 192), // Light Gray
            Color.FromArgb(96, 96, 96),    // Dark Gray
            Color.FromArgb(0, 0, 0)        // Black
        };

        // Get the index of the closest GameBoy color
        private static int GetGameBoyColorIndex(Color originalColor)
        {
            int brightness = (int)(0.299 * originalColor.R + 0.587 * originalColor.G + 0.114 * originalColor.B);
            if (brightness >= 192) 
                return 0;  // White
            if (brightness >= 128) 
                return 1;  // Light Gray
            if (brightness >= 64) 
                return 2;  // Dark Gray
            return 3;                         // Black
        }

        static int PackXYZ(int x, int y, int z)
        {
            return 1000000000 + x * 1000000 + y * 1000 + z;
        }

        static void UnpackXYZ(Int32 packedXYZ, out int X, out int Y, out int Z)
        {
            X = (packedXYZ / 1000000) % 1000;
            Y = (packedXYZ / 1000) % 1000;
            Z = packedXYZ % 1000;
        }

        private static Bitmap CaptureWindow(string targetWindowTitle, int borderWidth, int titleBarHeight, double brightnessFactor, double darkenFactor)
        {
            IntPtr hWnd = IntPtr.Zero;
            NativeMethods.RECT rect = new NativeMethods.RECT { Top = 0, Left = 0, Right = 0, Bottom = 0 };
            bool cachedRectSet = false;

            // Check if the targetWindowTitle is the same as the cachedWindowTitle
            if (cachedWindowTitle == targetWindowTitle)
            {
                hWnd = cachedWindowHandle;

                // Check if the cached hWnd is still valid (the window is still open)
                if (NativeMethods.GetWindowRect(hWnd, out rect))
                {
                    cachedRectSet = true;
                }
                else
                {
                    // Window is no longer open. Reset the cached handle and search again.
                    cachedWindowHandle = IntPtr.Zero;
                    cachedWindowTitle = "";
                    hWnd = NativeMethods.FindWindowByTitleSubstring(targetWindowTitle);
                }
            }
            else
            {
                hWnd = NativeMethods.FindWindowByTitleSubstring(targetWindowTitle);
            }

            // If a window handle was found, cache it for next time
            if (hWnd != IntPtr.Zero)
            {
                cachedWindowHandle = hWnd;
                cachedWindowTitle = targetWindowTitle;
            }
            else
            {
                Console.WriteLine("Window with title " + targetWindowTitle + " not found");
                return null;
            }

            if (!cachedRectSet) NativeMethods.GetWindowRect(hWnd, out rect);

            // Adjusting for the title bar and borders - these values are just placeholders
            int adjustedTop = rect.Top + titleBarHeight;
            int adjustedLeft = rect.Left + borderWidth;
            int adjustedRight = rect.Right - borderWidth;
            int adjustedBottom = rect.Bottom;

            int width = adjustedRight - adjustedLeft;
            int height = adjustedBottom - adjustedTop;

            Bitmap bmp = new Bitmap(MainForm.FRAME_WIDTH, MainForm.FRAME_HEIGHT, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(adjustedLeft, adjustedTop, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);

            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int bytesPerPixel = Image.GetPixelFormatSize(bmp.PixelFormat) / 8;
            byte[] pixelBuffer = new byte[bmpData.Stride * bmpData.Height];
            Marshal.Copy(bmpData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

            for (int y = 0; y < bmpData.Height; y++)
            {
                int rowOffset = y * bmpData.Stride;
                for (int x = 0; x < bmpData.Width; x++)
                {
                    int columnOffset = x * bytesPerPixel + rowOffset;
                    Color pixelColor = Color.FromArgb(pixelBuffer[columnOffset + 2], pixelBuffer[columnOffset + 1], pixelBuffer[columnOffset]);
                    int colorIndex = GetGameBoyColorIndex(pixelColor);
                    Color newColor = GameBoyColors[colorIndex];
                    pixelBuffer[columnOffset] = newColor.B;
                    pixelBuffer[columnOffset + 1] = newColor.G;
                    pixelBuffer[columnOffset + 2] = newColor.R;
                }
            }

            Marshal.Copy(pixelBuffer, 0, bmpData.Scan0, pixelBuffer.Length);
            bmp.UnlockBits(bmpData);
            return bmp;
        }

        private static int IdentifySpan(byte[] bmpBytes, int x, int y, int stride, int width, int bytesPerPixel, int targetColorIndex)
        {
            int offset = y * stride + x * bytesPerPixel;
            while (x < width)
            {
                Color currentColor = Color.FromArgb(bmpBytes[offset + 2], bmpBytes[offset + 1], bmpBytes[offset]);
                if (GetGameBoyColorIndex(currentColor) != targetColorIndex)
                    break;

                x++;
                offset += bytesPerPixel;
            }
            return x;
        }

        private static void StoreSpan(Dictionary<int, List<int>> rgbToSpans, int colorIndex, int packedXYZ)
        {
            if (!rgbToSpans.TryGetValue(colorIndex, out var spanList))
            {
                spanList = new List<int>();
                rgbToSpans[colorIndex] = spanList;
            }
            spanList.Add(packedXYZ);
        }



        // Generate pixel data from a captured window, optimized for GameBoy color indices
        static public (List<int>, List<int>) GeneratePixelDataFromWindow(string targetWindowTitle, int borderWidth, int titleBarHeight, int width, int height, bool forceFullFrame, bool rowExpansionEnabled, double brightnessFactor, double darkenFactor)
        {
            Bitmap bmp = CaptureWindow(targetWindowTitle, borderWidth, titleBarHeight, brightnessFactor, darkenFactor);
            if (bmp == null)
            {
                return (null, null);
            }

            List<int> pixelDataList = new List<int>();
            rgbToSpans = new Dictionary<int, List<int>>();

            BitmapData currentBmpData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, bmp.PixelFormat);
            BitmapData cachedBmpData = _cachedBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, _cachedBitmap.PixelFormat);

            int bytesPerPixel = Image.GetPixelFormatSize(bmp.PixelFormat) / 8;
            byte[] currentBmpBytes = new byte[width * height * bytesPerPixel];
            byte[] cachedBmpBytes = new byte[width * height * bytesPerPixel];

            Marshal.Copy(currentBmpData.Scan0, currentBmpBytes, 0, currentBmpBytes.Length);
            Marshal.Copy(cachedBmpData.Scan0, cachedBmpBytes, 0, cachedBmpBytes.Length);

            int stride = currentBmpData.Stride;
            int spanStart;
            int offset;

            // For each row...
            for (int y = 0; y < height; y++)
            {
                // For each pixel in the row...
                for (int x = 0; x < width;)
                {
                    offset = y * stride + x * bytesPerPixel;
                    int currentColorIndex = GetGameBoyColorIndex(Color.FromArgb(currentBmpBytes[offset + 2], currentBmpBytes[offset + 1], currentBmpBytes[offset]));
                    int cachedColorIndex = GetGameBoyColorIndex(Color.FromArgb(cachedBmpBytes[offset + 2], cachedBmpBytes[offset + 1], cachedBmpBytes[offset]));

                    if (forceFullFrame || currentColorIndex != cachedColorIndex)
                    {
                        spanStart = x;
                        x = IdentifySpan(currentBmpBytes, x, y, stride, width, bytesPerPixel, currentColorIndex);
                        int spanLength = x - spanStart;
                        int packedXYZ = PackXYZ(spanStart, y, spanLength);
                        StoreSpan(rgbToSpans, currentColorIndex, packedXYZ);
                    }
                    else
                    {
                        x++;
                    }
                }
            }

            List<int> contiguousEndIndices = new List<int>();
            List<int> contiguousSpanLengths = new List<int>();
            int currentSpanLength = 0;

            for (int y = 1; y < height; y++) // Start from 1 because we compare with the previous row
            {
                bool rowsAreIdentical = true;

                for (int x = 0; x < width && rowsAreIdentical; x++)
                {
                    int offsetCurrent = y * stride + x * bytesPerPixel;
                    int offsetPrevious = (y - 1) * stride + x * bytesPerPixel;

                    int pixelCurrentIndex = GetGameBoyColorIndex(Color.FromArgb(currentBmpBytes[offsetCurrent + 2], currentBmpBytes[offsetCurrent + 1], currentBmpBytes[offsetCurrent]));
                    int pixelPreviousIndex = GetGameBoyColorIndex(Color.FromArgb(cachedBmpBytes[offsetPrevious + 2], cachedBmpBytes[offsetPrevious + 1], cachedBmpBytes[offsetPrevious]));

                    if (pixelCurrentIndex != pixelPreviousIndex)
                    {
                        rowsAreIdentical = false;
                    }
                }

                if (rowsAreIdentical)
                {
                    currentSpanLength++;
                }
                else
                {
                    if (currentSpanLength > 0 && rowExpansionEnabled && !forceFullFrame)
                    {
                        contiguousEndIndices.Add(y - 1);
                        contiguousSpanLengths.Add(currentSpanLength + 1); // +1 because it includes the start row as well
                        currentSpanLength = 0; // Reset
                    }
                }
            }

            if (currentSpanLength > 0 && rowExpansionEnabled && !forceFullFrame)
            {
                contiguousEndIndices.Add(height - 1);
                contiguousSpanLengths.Add(currentSpanLength + 1);
            }

            bmp.UnlockBits(currentBmpData);
            _cachedBitmap.UnlockBits(cachedBmpData);
            _cachedBitmap = bmp;

            contiguousRangePairs = new List<int>();

            foreach (var kvp in rgbToSpans)
            {
                pixelDataList.Add(kvp.Key);
                pixelDataList.AddRange(kvp.Value);
                pixelDataList.Add(-kvp.Value.Last());
            }

            return (pixelDataList, contiguousRangePairs);
        }



        private static void InitializeRowExpansionAmounts()
        {
            rowExpansionAmounts = new Dictionary<int, int>();
            for (int i = 0; i < MainForm.FRAME_HEIGHT; i++)
            {
                rowExpansionAmounts[i] = 1;
            }
        }
   


        private static void SetRowHeight(int rowIndex, int rowHeight)
        {
            if (rowIndex < 0 || rowHeight < 1)
            {
                Console.WriteLine("Invalid row index or height.");
                return;
            }

            rowExpansionAmounts[rowIndex] = rowHeight;
        }


        private static void ApplyRowHeight(Bitmap bitmap, int rowIndex, int rowHeight)
        {
            if (rowIndex < 0 || rowIndex >= bitmap.Height)
            {
                Console.WriteLine("Row index out of bounds.");
                return;
            }

            if (rowHeight < 1 || rowIndex - rowHeight < -1)
            {
                Console.WriteLine("Invalid row height or not enough rows below to set.");
                return;
            }

            // Expand the row upwards based on its height.
            // Greater rowIndex means lower on the screen.
            for (int y = rowIndex; y > rowIndex - rowHeight; y--)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, rowIndex);
                    bitmap.SetPixel(x, y, pixelColor);
                }
            }
            return;
        }

        private static void ApplyRowHeights(Bitmap bitmap)
        {
            foreach (var row in rowExpansionAmounts)
                ApplyRowHeight(_simulatedCanvas, row.Key, row.Value);
        }

        public static Bitmap SetPixelDataToBitmap()
        {

            if (rowExpansionAmounts == null) InitializeRowExpansionAmounts();

            int i = 0;
            int nPixelsChanged = 0;
            while (i < MemoryMappedFileManager.readPixelDataLength)
            {
                int colorIndex = MemoryMappedFileManager.readPixelData[i++];

                while (i < MemoryMappedFileManager.readPixelDataLength && MemoryMappedFileManager.readPixelData[i] >= 0)
                {
                    int packedxStartYSpan = MemoryMappedFileManager.readPixelData[i++];
                    UnpackXYZ(packedxStartYSpan, out int xStart, out int y, out int spanLength);
                    for (int x = xStart; x < xStart + spanLength; x++)
                    {
                        Color newPixelColor = GameBoyColors[colorIndex];
                        _simulatedCanvas.SetPixel(x, y, newPixelColor);
                        nPixelsChanged++;
                    }
                }
                i++; // Skip the negative delimiter
            }

            for (i = 0; i < MemoryMappedFileManager.readContiguousRangePairsLength; i += 2)
            {
                int rowIndex = MemoryMappedFileManager.readContiguousRangePairs[i];
                int rowHeight = MemoryMappedFileManager.readContiguousRangePairs[i + 1];
                SetRowHeight(rowIndex, rowHeight);
            }

            Console.WriteLine("Preview pixels changed: " + nPixelsChanged);
            MainForm.latestPreviewPixelsChangedCount = nPixelsChanged;

            ApplyRowHeights(_simulatedCanvas);
            return _simulatedCanvas;
        }
    }
}
