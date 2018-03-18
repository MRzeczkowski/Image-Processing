namespace ImageProcessing
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.RedBar = new System.Windows.Forms.TrackBar();
            this.GreenBar = new System.Windows.Forms.TrackBar();
            this.BlueBar = new System.Windows.Forms.TrackBar();
            this.cmbSwapPixelValues = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbRed = new System.Windows.Forms.Label();
            this.lbGreen = new System.Windows.Forms.Label();
            this.lbBlue = new System.Windows.Forms.Label();
            this.btnRotateCountClockwise = new System.Windows.Forms.Button();
            this.btnRotateClockwise = new System.Windows.Forms.Button();
            this.lbSwap = new System.Windows.Forms.Label();
            this.lbChangeTone = new System.Windows.Forms.Label();
            this.cmbChangeTone = new System.Windows.Forms.ComboBox();
            this.cmbRemoveColor = new System.Windows.Forms.ComboBox();
            this.lbRemoveColor = new System.Windows.Forms.Label();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.lbSortByValue = new System.Windows.Forms.Label();
            this.btnMirrorImage = new System.Windows.Forms.Button();
            this.btnNegtive = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(28, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open Image";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1091, 744);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(155, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(585, 475);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(746, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(585, 475);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // RedBar
            // 
            this.RedBar.Location = new System.Drawing.Point(8, 56);
            this.RedBar.Maximum = 255;
            this.RedBar.Minimum = -255;
            this.RedBar.Name = "RedBar";
            this.RedBar.Size = new System.Drawing.Size(141, 45);
            this.RedBar.TabIndex = 5;
            this.RedBar.Value = 1;
            this.RedBar.Scroll += new System.EventHandler(this.RedBar_Scroll);
            this.RedBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RedBar_MouseUp);
            // 
            // GreenBar
            // 
            this.GreenBar.Location = new System.Drawing.Point(8, 107);
            this.GreenBar.Maximum = 255;
            this.GreenBar.Minimum = -255;
            this.GreenBar.Name = "GreenBar";
            this.GreenBar.Size = new System.Drawing.Size(141, 45);
            this.GreenBar.TabIndex = 6;
            this.GreenBar.Value = 1;
            this.GreenBar.Scroll += new System.EventHandler(this.GreenBar_Scroll);
            this.GreenBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GreenBar_MouseUp);
            // 
            // BlueBar
            // 
            this.BlueBar.Location = new System.Drawing.Point(8, 158);
            this.BlueBar.Maximum = 255;
            this.BlueBar.Minimum = -255;
            this.BlueBar.Name = "BlueBar";
            this.BlueBar.Size = new System.Drawing.Size(141, 45);
            this.BlueBar.TabIndex = 7;
            this.BlueBar.Value = 1;
            this.BlueBar.Scroll += new System.EventHandler(this.BlueBar_Scroll);
            this.BlueBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BlueBar_MouseUp);
            // 
            // cmbSwapPixelValues
            // 
            this.cmbSwapPixelValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSwapPixelValues.DropDownWidth = 110;
            this.cmbSwapPixelValues.FormattingEnabled = true;
            this.cmbSwapPixelValues.Items.AddRange(new object[] {
            "ShiftPixelValues",
            "Swap Blue&Green",
            "Swap Blue&Red",
            "Swap Green&Red"});
            this.cmbSwapPixelValues.Location = new System.Drawing.Point(34, 232);
            this.cmbSwapPixelValues.Name = "cmbSwapPixelValues";
            this.cmbSwapPixelValues.Size = new System.Drawing.Size(76, 21);
            this.cmbSwapPixelValues.TabIndex = 8;
            this.cmbSwapPixelValues.SelectedIndexChanged += new System.EventHandler(this.cmbSwapPixelValues_SelectedIndexChanged);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(38, 627);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(38, 531);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbRed
            // 
            this.lbRed.AutoSize = true;
            this.lbRed.Location = new System.Drawing.Point(56, 40);
            this.lbRed.Name = "lbRed";
            this.lbRed.Size = new System.Drawing.Size(27, 13);
            this.lbRed.TabIndex = 11;
            this.lbRed.Text = "Red";
            // 
            // lbGreen
            // 
            this.lbGreen.AutoSize = true;
            this.lbGreen.Location = new System.Drawing.Point(47, 91);
            this.lbGreen.Name = "lbGreen";
            this.lbGreen.Size = new System.Drawing.Size(36, 13);
            this.lbGreen.TabIndex = 12;
            this.lbGreen.Text = "Green";
            // 
            // lbBlue
            // 
            this.lbBlue.AutoSize = true;
            this.lbBlue.Location = new System.Drawing.Point(56, 139);
            this.lbBlue.Name = "lbBlue";
            this.lbBlue.Size = new System.Drawing.Size(28, 13);
            this.lbBlue.TabIndex = 13;
            this.lbBlue.Text = "Blue";
            // 
            // btnRotateCountClockwise
            // 
            this.btnRotateCountClockwise.Location = new System.Drawing.Point(795, 744);
            this.btnRotateCountClockwise.Name = "btnRotateCountClockwise";
            this.btnRotateCountClockwise.Size = new System.Drawing.Size(29, 19);
            this.btnRotateCountClockwise.TabIndex = 14;
            this.btnRotateCountClockwise.Text = "<-";
            this.btnRotateCountClockwise.UseVisualStyleBackColor = true;
            this.btnRotateCountClockwise.Click += new System.EventHandler(this.btnRotateCountClockwise_Click);
            // 
            // btnRotateClockwise
            // 
            this.btnRotateClockwise.Location = new System.Drawing.Point(857, 744);
            this.btnRotateClockwise.Name = "btnRotateClockwise";
            this.btnRotateClockwise.Size = new System.Drawing.Size(29, 19);
            this.btnRotateClockwise.TabIndex = 15;
            this.btnRotateClockwise.Text = "->";
            this.btnRotateClockwise.UseVisualStyleBackColor = true;
            this.btnRotateClockwise.Click += new System.EventHandler(this.btnRotateClockwise_Click);
            // 
            // lbSwap
            // 
            this.lbSwap.AutoSize = true;
            this.lbSwap.Location = new System.Drawing.Point(31, 216);
            this.lbSwap.Name = "lbSwap";
            this.lbSwap.Size = new System.Drawing.Size(92, 13);
            this.lbSwap.TabIndex = 16;
            this.lbSwap.Text = "Swap pixel values";
            // 
            // lbChangeTone
            // 
            this.lbChangeTone.AutoSize = true;
            this.lbChangeTone.Location = new System.Drawing.Point(35, 273);
            this.lbChangeTone.Name = "lbChangeTone";
            this.lbChangeTone.Size = new System.Drawing.Size(68, 13);
            this.lbChangeTone.TabIndex = 17;
            this.lbChangeTone.Text = "Change tone";
            // 
            // cmbChangeTone
            // 
            this.cmbChangeTone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChangeTone.FormattingEnabled = true;
            this.cmbChangeTone.Items.AddRange(new object[] {
            "Grayscale",
            "Sepia"});
            this.cmbChangeTone.Location = new System.Drawing.Point(34, 289);
            this.cmbChangeTone.Name = "cmbChangeTone";
            this.cmbChangeTone.Size = new System.Drawing.Size(76, 21);
            this.cmbChangeTone.TabIndex = 18;
            this.cmbChangeTone.SelectedIndexChanged += new System.EventHandler(this.cmbChangeTone_SelectedIndexChanged);
            // 
            // cmbRemoveColor
            // 
            this.cmbRemoveColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRemoveColor.FormattingEnabled = true;
            this.cmbRemoveColor.Items.AddRange(new object[] {
            "Only red",
            "Only green",
            "Only blue",
            "Black and white"});
            this.cmbRemoveColor.Location = new System.Drawing.Point(34, 350);
            this.cmbRemoveColor.Name = "cmbRemoveColor";
            this.cmbRemoveColor.Size = new System.Drawing.Size(74, 21);
            this.cmbRemoveColor.TabIndex = 19;
            this.cmbRemoveColor.SelectedIndexChanged += new System.EventHandler(this.cmbRemoveColor_SelectedIndexChanged);
            // 
            // lbRemoveColor
            // 
            this.lbRemoveColor.AutoSize = true;
            this.lbRemoveColor.Location = new System.Drawing.Point(35, 334);
            this.lbRemoveColor.Name = "lbRemoveColor";
            this.lbRemoveColor.Size = new System.Drawing.Size(73, 13);
            this.lbRemoveColor.TabIndex = 20;
            this.lbRemoveColor.Text = "Remove color";
            // 
            // cmbSort
            // 
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.DropDownWidth = 110;
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Items.AddRange(new object[] {
            "Sort by hue",
            "Sort by saturation",
            "Sort by brightness"});
            this.cmbSort.Location = new System.Drawing.Point(33, 407);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(77, 21);
            this.cmbSort.TabIndex = 21;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);
            // 
            // lbSortByValue
            // 
            this.lbSortByValue.AutoSize = true;
            this.lbSortByValue.Location = new System.Drawing.Point(35, 391);
            this.lbSortByValue.Name = "lbSortByValue";
            this.lbSortByValue.Size = new System.Drawing.Size(55, 13);
            this.lbSortByValue.TabIndex = 22;
            this.lbSortByValue.Text = "Sort pixels";
            // 
            // btnMirrorImage
            // 
            this.btnMirrorImage.Location = new System.Drawing.Point(571, 740);
            this.btnMirrorImage.Name = "btnMirrorImage";
            this.btnMirrorImage.Size = new System.Drawing.Size(75, 23);
            this.btnMirrorImage.TabIndex = 23;
            this.btnMirrorImage.Text = "Mirror Image";
            this.btnMirrorImage.UseVisualStyleBackColor = true;
            this.btnMirrorImage.Click += new System.EventHandler(this.btnMirrorImage_Click);
            // 
            // btnNegtive
            // 
            this.btnNegtive.Location = new System.Drawing.Point(652, 740);
            this.btnNegtive.Name = "btnNegtive";
            this.btnNegtive.Size = new System.Drawing.Size(75, 23);
            this.btnNegtive.TabIndex = 24;
            this.btnNegtive.Text = "Negtive";
            this.btnNegtive.UseVisualStyleBackColor = true;
            this.btnNegtive.Click += new System.EventHandler(this.btnNegtive_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(155, 489);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(585, 245);
            this.pictureBox3.TabIndex = 25;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(746, 489);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(585, 245);
            this.pictureBox4.TabIndex = 26;
            this.pictureBox4.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 770);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnNegtive);
            this.Controls.Add(this.btnMirrorImage);
            this.Controls.Add(this.lbSortByValue);
            this.Controls.Add(this.cmbSort);
            this.Controls.Add(this.lbRemoveColor);
            this.Controls.Add(this.cmbRemoveColor);
            this.Controls.Add(this.cmbChangeTone);
            this.Controls.Add(this.lbChangeTone);
            this.Controls.Add(this.lbSwap);
            this.Controls.Add(this.btnRotateClockwise);
            this.Controls.Add(this.btnRotateCountClockwise);
            this.Controls.Add(this.lbBlue);
            this.Controls.Add(this.lbGreen);
            this.Controls.Add(this.lbRed);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.cmbSwapPixelValues);
            this.Controls.Add(this.BlueBar);
            this.Controls.Add(this.GreenBar);
            this.Controls.Add(this.RedBar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOpen);
            this.Name = "MainForm";
            this.Text = "Image Processing";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TrackBar RedBar;
        private System.Windows.Forms.TrackBar GreenBar;
        private System.Windows.Forms.TrackBar BlueBar;
        private System.Windows.Forms.ComboBox cmbSwapPixelValues;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbRed;
        private System.Windows.Forms.Label lbGreen;
        private System.Windows.Forms.Label lbBlue;
        private System.Windows.Forms.Button btnRotateCountClockwise;
        private System.Windows.Forms.Button btnRotateClockwise;
        private System.Windows.Forms.Label lbSwap;
        private System.Windows.Forms.Label lbChangeTone;
        private System.Windows.Forms.ComboBox cmbChangeTone;
        private System.Windows.Forms.ComboBox cmbRemoveColor;
        private System.Windows.Forms.Label lbRemoveColor;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Label lbSortByValue;
        private System.Windows.Forms.Button btnMirrorImage;
        private System.Windows.Forms.Button btnNegtive;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}

