﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.MemoryMappedFiles;
using System.IO;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace ResoniteGBApp
{
    public partial class MainForm : Form
    {
        private Timer _timer;
        private Random _random;
        private int MAX_FRAME_WIDTH = 999;
        private int MAX_FRAME_HEIGHT = 999;
        public static int FRAME_WIDTH = 160;
        public static int FRAME_HEIGHT = 144;
        private int TargetFramerate = 36;

        private int PixelDataMemoryMappedFileSize;

        private int fullFrameInterval = 30 * 1000; // 30 seconds in milliseconds
        private DateTime _lastFullFrameTime = DateTime.MinValue;
        private DateTime programStartTime;

        public static double brightnessFactor = 1.0;
        public double darkenFactor = 0.0;
        public string targetWindowTitle = "mGBA";
        private int titleBarHeight = 30;
        private int borderWidth = 8;

        private int _frameCounter = 0;
        private Timer _fpsTimer;

        private DateTime _lastTickTime = DateTime.Now;
        public static int latestPreviewPixelsChangedCount = 0;

        public MainForm()
        {
            InitializeComponent();
            _random = new Random();
            programStartTime = DateTime.Now;
        }

        private void InitializeCanvas()
        {
            PixelDataMemoryMappedFileSize = ((MAX_FRAME_WIDTH * MAX_FRAME_HEIGHT * 2) + 3) * sizeof(int);
            pictureBox1.Width = FRAME_WIDTH;
            pictureBox1.Height = FRAME_HEIGHT;

            FrameData._cachedBitmap = new Bitmap(FRAME_WIDTH, FRAME_HEIGHT);
            FrameData._simulatedCanvas = new Bitmap(FRAME_WIDTH, FRAME_HEIGHT);
            FrameData.rowContiguousSpanEndIndices = new int[FRAME_HEIGHT];

            MemoryMappedFileManager.readContiguousRangePairs = new int[FRAME_WIDTH * FRAME_HEIGHT];
            MemoryMappedFileManager.readPixelData = new int[FRAME_WIDTH * FRAME_HEIGHT];
    }

        private void Form1_Load(object sender, EventArgs e)
        {
            _timer = new Timer();
            _timer.Interval = (int)((1.0 / TargetFramerate) * 1000);
            _timer.Tick += Timer_Tick;
            _timer.Start();

            _fpsTimer = new Timer();
            _fpsTimer.Interval = 1000;  // 1 second
            _fpsTimer.Tick += FpsTimer_Tick;
            _fpsTimer.Start();

            InitializeCanvas();
            Console.WriteLine("Form loaded with Timer Interval: " + _timer.Interval);
        }

        private void FpsTimer_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine($"Published FPS: {_frameCounter}");
            publishedFPSLabel.Text = _frameCounter.ToString();
            _frameCounter = 0;  // Reset the counter
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!checkBox1.Checked) return;

            if (checkBox3.Checked && !(MemoryMappedFileManager.clientRenderConfirmed())) return;

            var startTickTime = DateTime.Now;

            bool forceFullFrame = false;
            if ((DateTime.Now - _lastFullFrameTime).TotalMilliseconds >= fullFrameInterval)
            {
                forceFullFrame = true;
                _lastFullFrameTime = DateTime.Now;
            }
            MemoryMappedFileManager._lastFrameTime = DateTime.Now;

            // Generate pixel data (SLOW)
            var(pixelData, contiguousRangePairs) = FrameData.GeneratePixelDataFromWindow(targetWindowTitle, borderWidth, titleBarHeight,  FRAME_WIDTH, FRAME_HEIGHT, forceFullFrame, rowExpansionCheckBox.Checked, brightnessFactor, darkenFactor);
            if (pixelData == null) return;

            // Write to MemoryMappedFile
            MemoryMappedFileManager.WritePixelDataToMemoryMappedFile(pixelData, contiguousRangePairs, PixelDataMemoryMappedFileSize, forceFullFrame);

            // Read from MemoryMappedFile
            if (MemoryMappedFileManager._pixelDataMemoryMappedViewStream == null)
            {
                MemoryMappedFileManager._pixelDataMemoryMappedViewStream = MemoryMappedFileManager._pixelDataMemoryMappedFile.CreateViewStream();
                MemoryMappedFileManager._pixelDataBinaryReader = new BinaryReader(MemoryMappedFileManager._pixelDataMemoryMappedViewStream);
            }

            MemoryMappedFileManager.ReadPixelDataFromMemoryMappedFile();
            if (MemoryMappedFileManager.readPixelData == null) return;

            if (previewCheckBox.Checked)
            {
                // Preview is enabled, so convert pixel data to Bitmap and set to PictureBox (SLOW)
                pictureBox1.Image = FrameData.SetPixelDataToBitmap();
                previewPixelsChangedCountLabel.Text = latestPreviewPixelsChangedCount.ToString();
            }

            if (checkBox4.Checked)
            {
                MemoryMappedFileManager.WriteLatestReceivedFrameMillisecondsOffsetToMemoryMappedFile();
                //Console.WriteLine("Confirmation of render from server is enabled, so called WriteLatestReceivedFrameMillisecondsOffsetToMemoryMappedFile()");
            }
            _frameCounter++;

            var endTickTime = DateTime.Now;
            var executionTime = (endTickTime - startTickTime).TotalMilliseconds;

            // Set the next timer tick interval. We want to subtract the execution time of this function from the interval to make sure we're publishing near the target framerate
            // The Math.Max() call is to ensure that the interval is never less than 1 millisecond. This happens if the execution time is greater than the target framerate.
            _timer.Interval = Math.Max(1, (int)((1.0 / TargetFramerate) * 1000) - (int)executionTime);

            _lastTickTime = endTickTime; // Update the last tick time

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dispose the MemoryMappedFile
            MemoryMappedFileManager._pixelDataMemoryMappedFile?.Dispose();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // We need to use an event handler because we have to update the timer's interval
            if (int.TryParse(targetFramerateTextBox.Text, out int selectedTargetFramerate) && selectedTargetFramerate <= 60 && selectedTargetFramerate >= 1)
            {
                TargetFramerate = selectedTargetFramerate;
                _timer.Interval = (int)((1.0 / TargetFramerate) * 1000); // Update timer's interval here
                Console.WriteLine("TargetFramerate changed to " + TargetFramerate + " and Timer Interval set to " + _timer.Interval);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Adjusting brightness of the entire frame
            // A value of 1 means no change. Values > 1 increase brightness, and values < 1 decrease it.
            // 
            if (!double.TryParse(brightnessTextBox.Text, out brightnessFactor) || brightnessFactor < 0 || brightnessFactor > 2.0) return;
        }


        private void targetWindowTextBox_TextChanged(object sender, EventArgs e)
        {
            targetWindowTitle = targetWindowTextBox.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox6.Text, out int selectedFullFrameInterval) && selectedFullFrameInterval >= 1)
                fullFrameInterval = selectedFullFrameInterval * 1000;
        }

        private void borderWidthTextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(borderWidthTextBox.Text, out int selectedBorderWidth) && selectedBorderWidth >= 1)
                borderWidth = selectedBorderWidth;
        }

        private void canvasWidthTextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(canvasWidthTextBox.Text, out int selectedCanvasWidth) && selectedCanvasWidth >= 100 && selectedCanvasWidth <= 999)
            {
                FRAME_WIDTH = selectedCanvasWidth;
                InitializeCanvas();
            }
        }

        private void canvasHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(canvasHeightTextBox.Text, out int selectedCanvasHeight) && selectedCanvasHeight >= 100 && selectedCanvasHeight <= 999)
            {
                FRAME_HEIGHT = selectedCanvasHeight;
                InitializeCanvas();
            }
        }

        private void consolePresetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = consolePresetComboBox.SelectedItem.ToString();
            if (selectedValue == "GB")
            {
                targetWindowTextBox.Text = "mGBA";
                canvasWidthTextBox.Text = "160";
                canvasHeightTextBox.Text = "144";
            }
        }
    }
}