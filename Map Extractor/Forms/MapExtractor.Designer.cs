namespace Map_Extractor
{
    partial class MapExtractor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapExtractor));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sourceMap = new System.Windows.Forms.ComboBox();
            this.destinationMap = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.copyStatics = new System.Windows.Forms.CheckBox();
            this.entireMap = new System.Windows.Forms.RadioButton();
            this.portion = new System.Windows.Forms.RadioButton();
            this.coordBox = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.destY = new Map_Extractor.FilteredTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.destX = new Map_Extractor.FilteredTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.srcH = new Map_Extractor.FilteredTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.srcW = new Map_Extractor.FilteredTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.srcY = new Map_Extractor.FilteredTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.srcX = new Map_Extractor.FilteredTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.conversionButton = new System.Windows.Forms.Button();
            this.customSourceBox = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.sourceHeight = new Map_Extractor.FilteredTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.sourceWidth = new Map_Extractor.FilteredTextBox();
            this.sourceIndex = new Map_Extractor.FilteredTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.customDestinationBox = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.destinationHeight = new Map_Extractor.FilteredTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.destinationWidth = new Map_Extractor.FilteredTextBox();
            this.destinationIndex = new Map_Extractor.FilteredTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.destinationFiles = new Map_Extractor.DropDownBox();
            this.sourceFiles = new Map_Extractor.DropDownBox();
            this.coordBox.SuspendLayout();
            this.customSourceBox.SuspendLayout();
            this.customDestinationBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source MUL Files:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Source Map:";
            // 
            // sourceMap
            // 
            this.sourceMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceMap.FormattingEnabled = true;
            this.sourceMap.Items.AddRange(new object[] {
            "Map0 (Felucca) 6144x4096",
            "Map0 (Felucca) 7168x4096",
            "Map1 (Trammel) 6144x4096",
            "Map1 (Trammel) 7168x4096",
            "Map2 (Ilshenar) 2304x1600",
            "Map3 (Malas) 2560x2048",
            "Map4 (Tokuno) 1448x1448",
            "Map5 (Ter Mur) 1280x4096",
            "Custom"});
            this.sourceMap.Location = new System.Drawing.Point(142, 61);
            this.sourceMap.Name = "sourceMap";
            this.sourceMap.Size = new System.Drawing.Size(330, 21);
            this.sourceMap.TabIndex = 5;
            this.sourceMap.SelectedIndexChanged += new System.EventHandler(this.sourceMap_SelectedIndexChanged);
            // 
            // destinationMap
            // 
            this.destinationMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destinationMap.FormattingEnabled = true;
            this.destinationMap.Items.AddRange(new object[] {
            "Map0 (Felucca) 6144x4096",
            "Map0 (Felucca) 7168x4096",
            "Map1 (Trammel) 6144x4096",
            "Map1 (Trammel) 7168x4096",
            "Map2 (Ilshenar) 2304x1600",
            "Map3 (Malas) 2560x2048",
            "Map4 (Tokuno) 1448x1448",
            "Map5 (Ter Mur) 1280x4096",
            "Custom"});
            this.destinationMap.Location = new System.Drawing.Point(142, 88);
            this.destinationMap.Name = "destinationMap";
            this.destinationMap.Size = new System.Drawing.Size(330, 21);
            this.destinationMap.TabIndex = 7;
            this.destinationMap.SelectedIndexChanged += new System.EventHandler(this.destinationMap_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Destination Map:";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(203, 352);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 16;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Destination MUL Files:";
            // 
            // copyStatics
            // 
            this.copyStatics.AutoSize = true;
            this.copyStatics.Checked = true;
            this.copyStatics.CheckState = System.Windows.Forms.CheckState.Checked;
            this.copyStatics.Location = new System.Drawing.Point(6, 164);
            this.copyStatics.Name = "copyStatics";
            this.copyStatics.Size = new System.Drawing.Size(85, 17);
            this.copyStatics.TabIndex = 10;
            this.copyStatics.Text = "Copy Statics";
            this.copyStatics.UseVisualStyleBackColor = true;
            // 
            // entireMap
            // 
            this.entireMap.AutoSize = true;
            this.entireMap.Checked = true;
            this.entireMap.Location = new System.Drawing.Point(6, 118);
            this.entireMap.Name = "entireMap";
            this.entireMap.Size = new System.Drawing.Size(103, 17);
            this.entireMap.TabIndex = 8;
            this.entireMap.TabStop = true;
            this.entireMap.Text = "Copy Entire Map";
            this.entireMap.UseVisualStyleBackColor = true;
            this.entireMap.CheckedChanged += new System.EventHandler(this.portion_CheckedChanged);
            // 
            // portion
            // 
            this.portion.AutoSize = true;
            this.portion.Location = new System.Drawing.Point(6, 136);
            this.portion.Name = "portion";
            this.portion.Size = new System.Drawing.Size(121, 17);
            this.portion.TabIndex = 9;
            this.portion.Text = "Copy Portion of Map";
            this.portion.UseVisualStyleBackColor = true;
            this.portion.CheckedChanged += new System.EventHandler(this.portion_CheckedChanged);
            // 
            // coordBox
            // 
            this.coordBox.Controls.Add(this.label10);
            this.coordBox.Controls.Add(this.destY);
            this.coordBox.Controls.Add(this.label11);
            this.coordBox.Controls.Add(this.destX);
            this.coordBox.Controls.Add(this.label12);
            this.coordBox.Controls.Add(this.label9);
            this.coordBox.Controls.Add(this.srcH);
            this.coordBox.Controls.Add(this.label8);
            this.coordBox.Controls.Add(this.srcW);
            this.coordBox.Controls.Add(this.label7);
            this.coordBox.Controls.Add(this.srcY);
            this.coordBox.Controls.Add(this.label6);
            this.coordBox.Controls.Add(this.srcX);
            this.coordBox.Controls.Add(this.label5);
            this.coordBox.Enabled = false;
            this.coordBox.Location = new System.Drawing.Point(142, 115);
            this.coordBox.Name = "coordBox";
            this.coordBox.Size = new System.Drawing.Size(330, 100);
            this.coordBox.TabIndex = 11;
            this.coordBox.TabStop = false;
            this.coordBox.Text = "Specify Maps Coords to copy (must be divisable by 8)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(85, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Y :";
            // 
            // destY
            // 
            this.destY.AllowedChars = "1234567890";
            this.destY.Location = new System.Drawing.Point(111, 74);
            this.destY.MaxLength = 4;
            this.destY.Name = "destY";
            this.destY.Size = new System.Drawing.Size(34, 20);
            this.destY.TabIndex = 13;
            this.destY.Value = -1;
            this.destY.Leave += new System.EventHandler(this.divisible_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "X :";
            // 
            // destX
            // 
            this.destX.AllowedChars = "1234567890";
            this.destX.Location = new System.Drawing.Point(47, 74);
            this.destX.MaxLength = 4;
            this.destX.Name = "destX";
            this.destX.Size = new System.Drawing.Size(34, 20);
            this.destX.TabIndex = 11;
            this.destX.Value = -1;
            this.destX.Leave += new System.EventHandler(this.divisible_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Destination:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(243, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Height :";
            // 
            // srcH
            // 
            this.srcH.AllowedChars = "1234567890";
            this.srcH.Location = new System.Drawing.Point(290, 30);
            this.srcH.MaxLength = 4;
            this.srcH.Name = "srcH";
            this.srcH.Size = new System.Drawing.Size(34, 20);
            this.srcH.TabIndex = 8;
            this.srcH.Value = -1;
            this.srcH.Leave += new System.EventHandler(this.divisible_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(151, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Width :";
            // 
            // srcW
            // 
            this.srcW.AllowedChars = "1234567890";
            this.srcW.Location = new System.Drawing.Point(198, 30);
            this.srcW.MaxLength = 4;
            this.srcW.Name = "srcW";
            this.srcW.Size = new System.Drawing.Size(34, 20);
            this.srcW.TabIndex = 6;
            this.srcW.Value = -1;
            this.srcW.Leave += new System.EventHandler(this.divisible_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Y :";
            // 
            // srcY
            // 
            this.srcY.AllowedChars = "1234567890";
            this.srcY.Location = new System.Drawing.Point(111, 30);
            this.srcY.MaxLength = 4;
            this.srcY.Name = "srcY";
            this.srcY.Size = new System.Drawing.Size(34, 20);
            this.srcY.TabIndex = 4;
            this.srcY.Value = -1;
            this.srcY.Leave += new System.EventHandler(this.divisible_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "X :";
            // 
            // srcX
            // 
            this.srcX.AllowedChars = "1234567890";
            this.srcX.Location = new System.Drawing.Point(47, 30);
            this.srcX.MaxLength = 4;
            this.srcX.Name = "srcX";
            this.srcX.Size = new System.Drawing.Size(34, 20);
            this.srcX.TabIndex = 2;
            this.srcX.Value = -1;
            this.srcX.Leave += new System.EventHandler(this.divisible_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Source:";
            // 
            // progress
            // 
            this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progress.Location = new System.Drawing.Point(6, 325);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(466, 23);
            this.progress.TabIndex = 14;
            this.progress.Visible = false;
            // 
            // conversionButton
            // 
            this.conversionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.conversionButton.Location = new System.Drawing.Point(6, 354);
            this.conversionButton.Name = "conversionButton";
            this.conversionButton.Size = new System.Drawing.Size(145, 23);
            this.conversionButton.TabIndex = 15;
            this.conversionButton.Text = "Define Conversion Tables";
            this.conversionButton.UseVisualStyleBackColor = true;
            this.conversionButton.Click += new System.EventHandler(this.conversionButton_Click);
            // 
            // customSourceBox
            // 
            this.customSourceBox.Controls.Add(this.label14);
            this.customSourceBox.Controls.Add(this.sourceHeight);
            this.customSourceBox.Controls.Add(this.label15);
            this.customSourceBox.Controls.Add(this.sourceWidth);
            this.customSourceBox.Controls.Add(this.sourceIndex);
            this.customSourceBox.Controls.Add(this.label13);
            this.customSourceBox.Enabled = false;
            this.customSourceBox.Location = new System.Drawing.Point(142, 221);
            this.customSourceBox.Name = "customSourceBox";
            this.customSourceBox.Size = new System.Drawing.Size(330, 40);
            this.customSourceBox.TabIndex = 12;
            this.customSourceBox.TabStop = false;
            this.customSourceBox.Text = "Custom Source Map Settings";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(243, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Height :";
            // 
            // sourceHeight
            // 
            this.sourceHeight.AllowedChars = "1234567890";
            this.sourceHeight.Location = new System.Drawing.Point(290, 15);
            this.sourceHeight.MaxLength = 4;
            this.sourceHeight.Name = "sourceHeight";
            this.sourceHeight.Size = new System.Drawing.Size(34, 20);
            this.sourceHeight.TabIndex = 5;
            this.sourceHeight.Value = -1;
            this.sourceHeight.Leave += new System.EventHandler(this.divisible_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(151, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "Width :";
            // 
            // sourceWidth
            // 
            this.sourceWidth.AllowedChars = "1234567890";
            this.sourceWidth.Location = new System.Drawing.Point(198, 15);
            this.sourceWidth.MaxLength = 4;
            this.sourceWidth.Name = "sourceWidth";
            this.sourceWidth.Size = new System.Drawing.Size(34, 20);
            this.sourceWidth.TabIndex = 3;
            this.sourceWidth.Value = -1;
            this.sourceWidth.Leave += new System.EventHandler(this.divisible_Leave);
            // 
            // sourceIndex
            // 
            this.sourceIndex.AllowedChars = "1234567890";
            this.sourceIndex.Location = new System.Drawing.Point(70, 15);
            this.sourceIndex.MaxLength = 1;
            this.sourceIndex.Name = "sourceIndex";
            this.sourceIndex.Size = new System.Drawing.Size(21, 20);
            this.sourceIndex.TabIndex = 1;
            this.sourceIndex.Value = -1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "File Index :";
            // 
            // customDestinationBox
            // 
            this.customDestinationBox.Controls.Add(this.label16);
            this.customDestinationBox.Controls.Add(this.destinationHeight);
            this.customDestinationBox.Controls.Add(this.label17);
            this.customDestinationBox.Controls.Add(this.destinationWidth);
            this.customDestinationBox.Controls.Add(this.destinationIndex);
            this.customDestinationBox.Controls.Add(this.label18);
            this.customDestinationBox.Enabled = false;
            this.customDestinationBox.Location = new System.Drawing.Point(142, 267);
            this.customDestinationBox.Name = "customDestinationBox";
            this.customDestinationBox.Size = new System.Drawing.Size(330, 40);
            this.customDestinationBox.TabIndex = 13;
            this.customDestinationBox.TabStop = false;
            this.customDestinationBox.Text = "Custom Destination Map Settings";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(243, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 4;
            this.label16.Text = "Height :";
            // 
            // destinationHeight
            // 
            this.destinationHeight.AllowedChars = "1234567890";
            this.destinationHeight.Location = new System.Drawing.Point(290, 15);
            this.destinationHeight.MaxLength = 4;
            this.destinationHeight.Name = "destinationHeight";
            this.destinationHeight.Size = new System.Drawing.Size(34, 20);
            this.destinationHeight.TabIndex = 5;
            this.destinationHeight.Value = -1;
            this.destinationHeight.Leave += new System.EventHandler(this.divisible_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(151, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "Width :";
            // 
            // destinationWidth
            // 
            this.destinationWidth.AllowedChars = "1234567890";
            this.destinationWidth.Location = new System.Drawing.Point(198, 15);
            this.destinationWidth.MaxLength = 4;
            this.destinationWidth.Name = "destinationWidth";
            this.destinationWidth.Size = new System.Drawing.Size(34, 20);
            this.destinationWidth.TabIndex = 3;
            this.destinationWidth.Value = -1;
            this.destinationWidth.Leave += new System.EventHandler(this.divisible_Leave);
            // 
            // destinationIndex
            // 
            this.destinationIndex.AllowedChars = "1234567890";
            this.destinationIndex.Location = new System.Drawing.Point(70, 15);
            this.destinationIndex.MaxLength = 1;
            this.destinationIndex.Name = "destinationIndex";
            this.destinationIndex.Size = new System.Drawing.Size(21, 20);
            this.destinationIndex.TabIndex = 1;
            this.destinationIndex.Value = -1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "File Index :";
            // 
            // destinationFiles
            // 
            this.destinationFiles.BackColor = System.Drawing.SystemColors.Window;
            this.destinationFiles.Location = new System.Drawing.Point(142, 35);
            this.destinationFiles.Name = "destinationFiles";
            this.destinationFiles.Size = new System.Drawing.Size(330, 20);
            this.destinationFiles.TabIndex = 3;
            this.destinationFiles.TabStop = false;
            this.destinationFiles.TextEnabled = false;
            this.destinationFiles.DropDownClicked += new System.EventHandler(this.destinationFiles_DropDownClicked);
            // 
            // sourceFiles
            // 
            this.sourceFiles.BackColor = System.Drawing.SystemColors.Window;
            this.sourceFiles.Location = new System.Drawing.Point(142, 9);
            this.sourceFiles.Name = "sourceFiles";
            this.sourceFiles.Size = new System.Drawing.Size(330, 20);
            this.sourceFiles.TabIndex = 1;
            this.sourceFiles.TabStop = false;
            this.sourceFiles.TextEnabled = false;
            this.sourceFiles.DropDownClicked += new System.EventHandler(this.mulFiles_DropDownClicked);
            // 
            // MapExtractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 376);
            this.Controls.Add(this.customDestinationBox);
            this.Controls.Add(this.customSourceBox);
            this.Controls.Add(this.conversionButton);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.coordBox);
            this.Controls.Add(this.portion);
            this.Controls.Add(this.entireMap);
            this.Controls.Add(this.copyStatics);
            this.Controls.Add(this.destinationFiles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.destinationMap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sourceMap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sourceFiles);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MapExtractor";
            this.Text = "Map Extractor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapExtractor_FormClosing);
            this.coordBox.ResumeLayout(false);
            this.coordBox.PerformLayout();
            this.customSourceBox.ResumeLayout(false);
            this.customSourceBox.PerformLayout();
            this.customDestinationBox.ResumeLayout(false);
            this.customDestinationBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DropDownBox sourceFiles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox sourceMap;
        private System.Windows.Forms.ComboBox destinationMap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStart;
        private DropDownBox destinationFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox copyStatics;
        private System.Windows.Forms.RadioButton entireMap;
        private System.Windows.Forms.RadioButton portion;
        private System.Windows.Forms.GroupBox coordBox;
        private System.Windows.Forms.Label label10;
        private FilteredTextBox destY;
        private System.Windows.Forms.Label label11;
        private FilteredTextBox destX;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private FilteredTextBox srcH;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private FilteredTextBox srcY;
        private System.Windows.Forms.Label label6;
        private FilteredTextBox srcX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Button conversionButton;
        private System.Windows.Forms.GroupBox customSourceBox;
        private System.Windows.Forms.Label label14;
        private FilteredTextBox sourceHeight;
        private System.Windows.Forms.Label label15;
        private FilteredTextBox sourceWidth;
        private FilteredTextBox sourceIndex;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox customDestinationBox;
        private System.Windows.Forms.Label label16;
        private FilteredTextBox destinationHeight;
        private System.Windows.Forms.Label label17;
        private FilteredTextBox destinationWidth;
        private FilteredTextBox destinationIndex;
        private System.Windows.Forms.Label label18;
        private FilteredTextBox srcW;
    }
}

