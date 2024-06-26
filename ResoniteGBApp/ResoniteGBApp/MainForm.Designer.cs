﻿namespace ResoniteGBApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.targetWindowTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.consolePresetComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.canvasWidthLabel = new System.Windows.Forms.Label();
            this.canvasWidthTextBox = new System.Windows.Forms.TextBox();
            this.canvasHeightLabel = new System.Windows.Forms.Label();
            this.canvasHeightTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.borderWidthTextBox = new System.Windows.Forms.TextBox();
            this.previewPixelsChangedCountLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.rowExpansionCheckBox = new System.Windows.Forms.CheckBox();
            this.publishedFPSLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.previewCheckBox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.targetFramerateTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.brightnessTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // targetWindowTextBox
            // 
            this.targetWindowTextBox.Location = new System.Drawing.Point(125, 375);
            this.targetWindowTextBox.Name = "targetWindowTextBox";
            this.targetWindowTextBox.Size = new System.Drawing.Size(100, 20);
            this.targetWindowTextBox.TabIndex = 0;
            this.targetWindowTextBox.Text = "mGBA";
            this.targetWindowTextBox.TextChanged += new System.EventHandler(this.targetWindowTextBox_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(8, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(420, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 240);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Input Websocket Status:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(690, 438);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.consolePresetComboBox);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.canvasWidthLabel);
            this.tabPage1.Controls.Add(this.canvasWidthTextBox);
            this.tabPage1.Controls.Add(this.canvasHeightLabel);
            this.tabPage1.Controls.Add(this.canvasHeightTextBox);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.borderWidthTextBox);
            this.tabPage1.Controls.Add(this.previewPixelsChangedCountLabel);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.rowExpansionCheckBox);
            this.tabPage1.Controls.Add(this.publishedFPSLabel);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.previewCheckBox);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.textBox6);
            this.tabPage1.Controls.Add(this.checkBox4);
            this.tabPage1.Controls.Add(this.checkBox3);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.targetFramerateTextBox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.brightnessTextBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.targetWindowTextBox);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(682, 412);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // consolePresetComboBox
            // 
            this.consolePresetComboBox.FormattingEnabled = true;
            this.consolePresetComboBox.Items.AddRange(new object[] {
            "GB"});
            this.consolePresetComboBox.Location = new System.Drawing.Point(3, 374);
            this.consolePresetComboBox.Name = "consolePresetComboBox";
            this.consolePresetComboBox.Size = new System.Drawing.Size(100, 21);
            this.consolePresetComboBox.TabIndex = 37;
            this.consolePresetComboBox.SelectedIndexChanged += new System.EventHandler(this.consolePresetComboBox_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 347);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Console Preset";
            // 
            // canvasWidthLabel
            // 
            this.canvasWidthLabel.AutoSize = true;
            this.canvasWidthLabel.Location = new System.Drawing.Point(8, 227);
            this.canvasWidthLabel.Name = "canvasWidthLabel";
            this.canvasWidthLabel.Size = new System.Drawing.Size(74, 13);
            this.canvasWidthLabel.TabIndex = 35;
            this.canvasWidthLabel.Text = "Canvas Width";
            // 
            // canvasWidthTextBox
            // 
            this.canvasWidthTextBox.Location = new System.Drawing.Point(3, 246);
            this.canvasWidthTextBox.Name = "canvasWidthTextBox";
            this.canvasWidthTextBox.Size = new System.Drawing.Size(100, 20);
            this.canvasWidthTextBox.TabIndex = 34;
            this.canvasWidthTextBox.Text = "160";
            this.canvasWidthTextBox.TextChanged += new System.EventHandler(this.canvasWidthTextBox_TextChanged);
            // 
            // canvasHeightLabel
            // 
            this.canvasHeightLabel.AutoSize = true;
            this.canvasHeightLabel.Location = new System.Drawing.Point(8, 279);
            this.canvasHeightLabel.Name = "canvasHeightLabel";
            this.canvasHeightLabel.Size = new System.Drawing.Size(77, 13);
            this.canvasHeightLabel.TabIndex = 33;
            this.canvasHeightLabel.Text = "Canvas Height";
            // 
            // canvasHeightTextBox
            // 
            this.canvasHeightTextBox.Location = new System.Drawing.Point(3, 298);
            this.canvasHeightTextBox.Name = "canvasHeightTextBox";
            this.canvasHeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.canvasHeightTextBox.TabIndex = 32;
            this.canvasHeightTextBox.Text = "144";
            this.canvasHeightTextBox.TextChanged += new System.EventHandler(this.canvasHeightTextBox_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(270, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Border Width";
            // 
            // borderWidthTextBox
            // 
            this.borderWidthTextBox.Location = new System.Drawing.Point(265, 194);
            this.borderWidthTextBox.Name = "borderWidthTextBox";
            this.borderWidthTextBox.Size = new System.Drawing.Size(100, 20);
            this.borderWidthTextBox.TabIndex = 30;
            this.borderWidthTextBox.Text = "8";
            this.borderWidthTextBox.TextChanged += new System.EventHandler(this.borderWidthTextBox_TextChanged);
            // 
            // previewPixelsChangedCountLabel
            // 
            this.previewPixelsChangedCountLabel.AutoSize = true;
            this.previewPixelsChangedCountLabel.Location = new System.Drawing.Point(337, 42);
            this.previewPixelsChangedCountLabel.Name = "previewPixelsChangedCountLabel";
            this.previewPixelsChangedCountLabel.Size = new System.Drawing.Size(13, 13);
            this.previewPixelsChangedCountLabel.TabIndex = 29;
            this.previewPixelsChangedCountLabel.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(255, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Pixels Changed:";
            // 
            // rowExpansionCheckBox
            // 
            this.rowExpansionCheckBox.AutoSize = true;
            this.rowExpansionCheckBox.Location = new System.Drawing.Point(258, 140);
            this.rowExpansionCheckBox.Name = "rowExpansionCheckBox";
            this.rowExpansionCheckBox.Size = new System.Drawing.Size(100, 17);
            this.rowExpansionCheckBox.TabIndex = 27;
            this.rowExpansionCheckBox.Text = "Row Expansion";
            this.rowExpansionCheckBox.UseVisualStyleBackColor = true;
            // 
            // publishedFPSLabel
            // 
            this.publishedFPSLabel.AutoSize = true;
            this.publishedFPSLabel.Location = new System.Drawing.Point(337, 16);
            this.publishedFPSLabel.Name = "publishedFPSLabel";
            this.publishedFPSLabel.Size = new System.Drawing.Size(13, 13);
            this.publishedFPSLabel.TabIndex = 26;
            this.publishedFPSLabel.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(255, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Published FPS:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(270, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Title Bar Height";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(265, 246);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 23;
            this.textBox2.Text = "30";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(128, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Target Window";
            // 
            // previewCheckBox
            // 
            this.previewCheckBox.AutoSize = true;
            this.previewCheckBox.Checked = true;
            this.previewCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.previewCheckBox.Location = new System.Drawing.Point(501, 309);
            this.previewCheckBox.Name = "previewCheckBox";
            this.previewCheckBox.Size = new System.Drawing.Size(65, 30);
            this.previewCheckBox.TabIndex = 21;
            this.previewCheckBox.Text = "Preview\r\nEnabled";
            this.previewCheckBox.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(255, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Full Frame Interval (seconds)";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(265, 306);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 19;
            this.textBox6.Text = "30";
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(258, 104);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(156, 30);
            this.checkBox4.TabIndex = 18;
            this.checkBox4.Text = "Confirm Render from Server\r\n(for testing)";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(258, 68);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(111, 30);
            this.checkBox3.TabIndex = 17;
            this.checkBox3.Text = "Await Client \r\nRender Confirmed";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 347);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Target Framerate";
            // 
            // targetFramerateTextBox
            // 
            this.targetFramerateTextBox.Location = new System.Drawing.Point(265, 375);
            this.targetFramerateTextBox.Name = "targetFramerateTextBox";
            this.targetFramerateTextBox.Size = new System.Drawing.Size(100, 20);
            this.targetFramerateTextBox.TabIndex = 13;
            this.targetFramerateTextBox.Text = "36";
            this.targetFramerateTextBox.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(439, 347);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Brightness";
            // 
            // brightnessTextBox
            // 
            this.brightnessTextBox.Location = new System.Drawing.Point(420, 375);
            this.brightnessTextBox.Name = "brightnessTextBox";
            this.brightnessTextBox.Size = new System.Drawing.Size(100, 20);
            this.brightnessTextBox.TabIndex = 9;
            this.brightnessTextBox.Text = "1";
            this.brightnessTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Capturable Windows";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(420, 309);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(65, 30);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Server\r\nEnabled";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(498, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Canvas Preview:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(682, 412);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Resonite GB App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox targetWindowTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox brightnessTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox targetFramerateTextBox;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.CheckBox previewCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label publishedFPSLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox rowExpansionCheckBox;
        private System.Windows.Forms.Label previewPixelsChangedCountLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox borderWidthTextBox;
        private System.Windows.Forms.Label canvasWidthLabel;
        private System.Windows.Forms.TextBox canvasWidthTextBox;
        private System.Windows.Forms.Label canvasHeightLabel;
        private System.Windows.Forms.TextBox canvasHeightTextBox;
        private System.Windows.Forms.ComboBox consolePresetComboBox;
        private System.Windows.Forms.Label label13;
    }
}

