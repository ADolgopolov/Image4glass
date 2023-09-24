namespace Image4glass
{
    partial class Image4lass
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            numericUpDownNumber = new NumericUpDown();
            buttonOpenFolder = new Button();
            comboBoxFoldreName = new ComboBox();
            tabControl = new TabControl();
            tabPageForward = new TabPage();
            labelForwardImageIndex = new Label();
            pictureBoxForward = new PictureBox();
            tabPageRear = new TabPage();
            labelRearImageIndex = new Label();
            pictureBoxRear = new PictureBox();
            tabPageLeft = new TabPage();
            pictureBoxLeft = new PictureBox();
            tabPageRight = new TabPage();
            pictureBoxRight = new PictureBox();
            numericUpDownShiftimageIndex = new NumericUpDown();
            labelShift = new Label();
            folderBrowserDialog = new FolderBrowserDialog();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNumber).BeginInit();
            tabControl.SuspendLayout();
            tabPageForward.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxForward).BeginInit();
            tabPageRear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRear).BeginInit();
            tabPageLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLeft).BeginInit();
            tabPageRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownShiftimageIndex).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // numericUpDownNumber
            // 
            numericUpDownNumber.Location = new Point(6, 6);
            numericUpDownNumber.Maximum = new decimal(new int[] { 20000, 0, 0, 0 });
            numericUpDownNumber.Name = "numericUpDownNumber";
            numericUpDownNumber.Size = new Size(120, 23);
            numericUpDownNumber.TabIndex = 0;
            numericUpDownNumber.TextAlign = HorizontalAlignment.Center;
            numericUpDownNumber.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownNumber.ValueChanged += numericUpDownNumber_ValueChanged;
            // 
            // buttonOpenFolder
            // 
            buttonOpenFolder.Location = new Point(132, 5);
            buttonOpenFolder.Name = "buttonOpenFolder";
            buttonOpenFolder.Size = new Size(86, 23);
            buttonOpenFolder.TabIndex = 1;
            buttonOpenFolder.Text = "Open Folder";
            buttonOpenFolder.UseVisualStyleBackColor = true;
            buttonOpenFolder.Click += buttonOpenFolder_Click;
            // 
            // comboBoxFoldreName
            // 
            comboBoxFoldreName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxFoldreName.FormattingEnabled = true;
            comboBoxFoldreName.Location = new Point(224, 6);
            comboBoxFoldreName.Name = "comboBoxFoldreName";
            comboBoxFoldreName.Size = new Size(473, 23);
            comboBoxFoldreName.TabIndex = 2;
            comboBoxFoldreName.TextChanged += comboBoxFoldreName_TextChanged;
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabPageForward);
            tabControl.Controls.Add(tabPageRear);
            tabControl.Controls.Add(tabPageLeft);
            tabControl.Controls.Add(tabPageRight);
            tabControl.Location = new Point(6, 35);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(772, 501);
            tabControl.TabIndex = 3;
            // 
            // tabPageForward
            // 
            tabPageForward.Controls.Add(labelForwardImageIndex);
            tabPageForward.Controls.Add(pictureBoxForward);
            tabPageForward.Location = new Point(4, 24);
            tabPageForward.Name = "tabPageForward";
            tabPageForward.Padding = new Padding(3);
            tabPageForward.Size = new Size(764, 473);
            tabPageForward.TabIndex = 0;
            tabPageForward.Text = "Forward";
            tabPageForward.UseVisualStyleBackColor = true;
            // 
            // labelForwardImageIndex
            // 
            labelForwardImageIndex.AutoSize = true;
            labelForwardImageIndex.Location = new Point(6, 3);
            labelForwardImageIndex.Name = "labelForwardImageIndex";
            labelForwardImageIndex.Size = new Size(13, 15);
            labelForwardImageIndex.TabIndex = 7;
            labelForwardImageIndex.Text = "0";
            // 
            // pictureBoxForward
            // 
            pictureBoxForward.Dock = DockStyle.Fill;
            pictureBoxForward.Location = new Point(3, 3);
            pictureBoxForward.Name = "pictureBoxForward";
            pictureBoxForward.Size = new Size(758, 467);
            pictureBoxForward.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxForward.TabIndex = 0;
            pictureBoxForward.TabStop = false;
            // 
            // tabPageRear
            // 
            tabPageRear.Controls.Add(labelRearImageIndex);
            tabPageRear.Controls.Add(pictureBoxRear);
            tabPageRear.Location = new Point(4, 24);
            tabPageRear.Name = "tabPageRear";
            tabPageRear.Padding = new Padding(3);
            tabPageRear.Size = new Size(764, 473);
            tabPageRear.TabIndex = 1;
            tabPageRear.Text = "Rear";
            tabPageRear.UseVisualStyleBackColor = true;
            // 
            // labelRearImageIndex
            // 
            labelRearImageIndex.AutoSize = true;
            labelRearImageIndex.Location = new Point(6, 3);
            labelRearImageIndex.Name = "labelRearImageIndex";
            labelRearImageIndex.Size = new Size(13, 15);
            labelRearImageIndex.TabIndex = 7;
            labelRearImageIndex.Text = "0";
            // 
            // pictureBoxRear
            // 
            pictureBoxRear.Dock = DockStyle.Fill;
            pictureBoxRear.Location = new Point(3, 3);
            pictureBoxRear.Name = "pictureBoxRear";
            pictureBoxRear.Size = new Size(758, 467);
            pictureBoxRear.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxRear.TabIndex = 0;
            pictureBoxRear.TabStop = false;
            // 
            // tabPageLeft
            // 
            tabPageLeft.Controls.Add(pictureBoxLeft);
            tabPageLeft.Location = new Point(4, 24);
            tabPageLeft.Name = "tabPageLeft";
            tabPageLeft.Padding = new Padding(3);
            tabPageLeft.Size = new Size(764, 473);
            tabPageLeft.TabIndex = 2;
            tabPageLeft.Text = "Left";
            tabPageLeft.UseVisualStyleBackColor = true;
            // 
            // pictureBoxLeft
            // 
            pictureBoxLeft.Dock = DockStyle.Fill;
            pictureBoxLeft.Location = new Point(3, 3);
            pictureBoxLeft.Name = "pictureBoxLeft";
            pictureBoxLeft.Size = new Size(758, 467);
            pictureBoxLeft.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLeft.TabIndex = 0;
            pictureBoxLeft.TabStop = false;
            // 
            // tabPageRight
            // 
            tabPageRight.Controls.Add(pictureBoxRight);
            tabPageRight.Location = new Point(4, 24);
            tabPageRight.Name = "tabPageRight";
            tabPageRight.Padding = new Padding(3);
            tabPageRight.Size = new Size(764, 473);
            tabPageRight.TabIndex = 3;
            tabPageRight.Text = "Right";
            tabPageRight.UseVisualStyleBackColor = true;
            // 
            // pictureBoxRight
            // 
            pictureBoxRight.Dock = DockStyle.Fill;
            pictureBoxRight.Location = new Point(3, 3);
            pictureBoxRight.Name = "pictureBoxRight";
            pictureBoxRight.Size = new Size(758, 467);
            pictureBoxRight.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxRight.TabIndex = 0;
            pictureBoxRight.TabStop = false;
            // 
            // numericUpDownShiftimageIndex
            // 
            numericUpDownShiftimageIndex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownShiftimageIndex.Location = new Point(740, 6);
            numericUpDownShiftimageIndex.Name = "numericUpDownShiftimageIndex";
            numericUpDownShiftimageIndex.Size = new Size(38, 23);
            numericUpDownShiftimageIndex.TabIndex = 4;
            numericUpDownShiftimageIndex.Value = new decimal(new int[] { 7, 0, 0, 0 });
            numericUpDownShiftimageIndex.ValueChanged += numericUpDownNumber_ValueChanged;
            // 
            // labelShift
            // 
            labelShift.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelShift.AutoSize = true;
            labelShift.Location = new Point(703, 9);
            labelShift.Name = "labelShift";
            labelShift.Size = new Size(31, 15);
            labelShift.TabIndex = 5;
            labelShift.Text = "Shift";
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 539);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(784, 22);
            statusStrip.TabIndex = 6;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(256, 17);
            toolStripStatusLabel.Text = "Use button \"Open Folder\" to init start directory.";
            // 
            // Image4lass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(statusStrip);
            Controls.Add(labelShift);
            Controls.Add(numericUpDownShiftimageIndex);
            Controls.Add(tabControl);
            Controls.Add(comboBoxFoldreName);
            Controls.Add(buttonOpenFolder);
            Controls.Add(numericUpDownNumber);
            Name = "Image4lass";
            Text = "Image4lass";
            ((System.ComponentModel.ISupportInitialize)numericUpDownNumber).EndInit();
            tabControl.ResumeLayout(false);
            tabPageForward.ResumeLayout(false);
            tabPageForward.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxForward).EndInit();
            tabPageRear.ResumeLayout(false);
            tabPageRear.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRear).EndInit();
            tabPageLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLeft).EndInit();
            tabPageRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownShiftimageIndex).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numericUpDownNumber;
        private Button buttonOpenFolder;
        private ComboBox comboBoxFoldreName;
        private TabControl tabControl;
        private TabPage tabPageForward;
        private TabPage tabPageRear;
        private TabPage tabPageLeft;
        private TabPage tabPageRight;
        private PictureBox pictureBoxForward;
        private NumericUpDown numericUpDownShiftimageIndex;
        private Label labelShift;
        private PictureBox pictureBoxRear;
        private PictureBox pictureBoxRight;
        private FolderBrowserDialog folderBrowserDialog;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private PictureBox pictureBoxLeft;
        private Label labelForwardImageIndex;
        private Label labelRearImageIndex;
    }
}