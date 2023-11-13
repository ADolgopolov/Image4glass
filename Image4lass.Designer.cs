using System.Windows.Forms;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Image4lass));
            numericUpDownFotoNumber = new NumericUpDown();
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
            labelLeftImageIndex = new Label();
            pictureBoxLeft = new PictureBox();
            tabPageRight = new TabPage();
            labelRightImageIndex = new Label();
            pictureBoxRight = new PictureBox();
            numericUpDownShiftimageIndex = new NumericUpDown();
            labelShift = new Label();
            folderBrowserDialog = new FolderBrowserDialog();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolStripSplitButton1 = new ToolStripSplitButton();
            openBasicFolderToolStripMenuItem = new ToolStripMenuItem();
            resetBasicFolderToolStripMenuItem = new ToolStripMenuItem();
            buttonPast = new Button();
            labelLoading = new Label();
            buttonNumberDown = new Button();
            buttonNumberUp = new Button();
            basicFolderBrowserDialog = new FolderBrowserDialog();
            checkBoxFixZoom = new CheckBox();
            buttonZoomFit = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFotoNumber).BeginInit();
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
            // numericUpDownFotoNumber
            // 
            numericUpDownFotoNumber.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownFotoNumber.Location = new Point(123, 2);
            numericUpDownFotoNumber.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownFotoNumber.Name = "numericUpDownFotoNumber";
            numericUpDownFotoNumber.Size = new Size(69, 27);
            numericUpDownFotoNumber.TabIndex = 0;
            numericUpDownFotoNumber.TextAlign = HorizontalAlignment.Center;
            numericUpDownFotoNumber.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownFotoNumber.ValueChanged += numericUpDownNumber_ValueChanged;
            // 
            // buttonOpenFolder
            // 
            buttonOpenFolder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonOpenFolder.Location = new Point(300, 0);
            buttonOpenFolder.Name = "buttonOpenFolder";
            buttonOpenFolder.Size = new Size(148, 30);
            buttonOpenFolder.TabIndex = 1;
            buttonOpenFolder.Text = "Open Run Folder";
            buttonOpenFolder.UseVisualStyleBackColor = true;
            buttonOpenFolder.Click += buttonOpenFolder_Click;
            // 
            // comboBoxFoldreName
            // 
            comboBoxFoldreName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxFoldreName.FormattingEnabled = true;
            comboBoxFoldreName.Location = new Point(454, 4);
            comboBoxFoldreName.Name = "comboBoxFoldreName";
            comboBoxFoldreName.Size = new Size(567, 23);
            comboBoxFoldreName.TabIndex = 2;
            comboBoxFoldreName.TabStop = false;
            comboBoxFoldreName.SelectedIndexChanged += comboBoxFoldreName_SelectedIndexChanged;
            comboBoxFoldreName.TextChanged += comboBoxFoldreName_TextChanged;
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabPageForward);
            tabControl.Controls.Add(tabPageRear);
            tabControl.Controls.Add(tabPageLeft);
            tabControl.Controls.Add(tabPageRight);
            tabControl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tabControl.Location = new Point(6, 32);
            tabControl.MinimumSize = new Size(960, 480);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1252, 554);
            tabControl.TabIndex = 3;
            tabControl.TabStop = false;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            tabControl.DoubleClick += pictureBoxForAll_DoubleClick;
            tabControl.Resize += tabControl_Resize;
            // 
            // tabPageForward
            // 
            tabPageForward.Controls.Add(labelForwardImageIndex);
            tabPageForward.Controls.Add(pictureBoxForward);
            tabPageForward.Location = new Point(4, 30);
            tabPageForward.Name = "tabPageForward";
            tabPageForward.Padding = new Padding(3);
            tabPageForward.Size = new Size(1244, 520);
            tabPageForward.TabIndex = 0;
            tabPageForward.Text = "Forward";
            tabPageForward.UseVisualStyleBackColor = true;
            // 
            // labelForwardImageIndex
            // 
            labelForwardImageIndex.AutoSize = true;
            labelForwardImageIndex.Location = new Point(6, 3);
            labelForwardImageIndex.Name = "labelForwardImageIndex";
            labelForwardImageIndex.Size = new Size(14, 21);
            labelForwardImageIndex.TabIndex = 7;
            labelForwardImageIndex.Text = " ";
            labelForwardImageIndex.Click += forAll_labels_ImageIndex_Click;
            // 
            // pictureBoxForward
            // 
            pictureBoxForward.Cursor = Cursors.Cross;
            pictureBoxForward.Location = new Point(366, 6);
            pictureBoxForward.Name = "pictureBoxForward";
            pictureBoxForward.Size = new Size(512, 512);
            pictureBoxForward.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxForward.TabIndex = 0;
            pictureBoxForward.TabStop = false;
            pictureBoxForward.DoubleClick += pictureBoxForAll_DoubleClick;
            pictureBoxForward.MouseDown += pictureBox_MouseDown;
            pictureBoxForward.MouseMove += pictureBox_MouseMove;
            pictureBoxForward.MouseUp += pictureBox_MouseUp;
            pictureBoxForward.MouseWheel += pictureBoxZoomImage_MouseWheel;
            // 
            // tabPageRear
            // 
            tabPageRear.Controls.Add(labelRearImageIndex);
            tabPageRear.Controls.Add(pictureBoxRear);
            tabPageRear.Location = new Point(4, 30);
            tabPageRear.Name = "tabPageRear";
            tabPageRear.Padding = new Padding(3);
            tabPageRear.Size = new Size(1244, 520);
            tabPageRear.TabIndex = 1;
            tabPageRear.Text = "Rear";
            tabPageRear.UseVisualStyleBackColor = true;
            // 
            // labelRearImageIndex
            // 
            labelRearImageIndex.AutoSize = true;
            labelRearImageIndex.Location = new Point(6, 3);
            labelRearImageIndex.Name = "labelRearImageIndex";
            labelRearImageIndex.Size = new Size(14, 21);
            labelRearImageIndex.TabIndex = 7;
            labelRearImageIndex.Text = " ";
            labelRearImageIndex.Click += forAll_labels_ImageIndex_Click;
            // 
            // pictureBoxRear
            // 
            pictureBoxRear.Cursor = Cursors.Cross;
            pictureBoxRear.Location = new Point(366, 6);
            pictureBoxRear.Name = "pictureBoxRear";
            pictureBoxRear.Size = new Size(512, 512);
            pictureBoxRear.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxRear.TabIndex = 0;
            pictureBoxRear.TabStop = false;
            pictureBoxRear.DoubleClick += pictureBoxForAll_DoubleClick;
            pictureBoxRear.MouseDown += pictureBox_MouseDown;
            pictureBoxRear.MouseMove += pictureBox_MouseMove;
            pictureBoxRear.MouseUp += pictureBox_MouseUp;
            pictureBoxRear.MouseWheel += pictureBoxZoomImage_MouseWheel;
            // 
            // tabPageLeft
            // 
            tabPageLeft.Controls.Add(labelLeftImageIndex);
            tabPageLeft.Controls.Add(pictureBoxLeft);
            tabPageLeft.Location = new Point(4, 30);
            tabPageLeft.Name = "tabPageLeft";
            tabPageLeft.Padding = new Padding(3);
            tabPageLeft.Size = new Size(1244, 520);
            tabPageLeft.TabIndex = 2;
            tabPageLeft.Text = "Left";
            tabPageLeft.UseVisualStyleBackColor = true;
            // 
            // labelLeftImageIndex
            // 
            labelLeftImageIndex.AutoSize = true;
            labelLeftImageIndex.Location = new Point(6, 3);
            labelLeftImageIndex.Name = "labelLeftImageIndex";
            labelLeftImageIndex.Size = new Size(14, 21);
            labelLeftImageIndex.TabIndex = 1;
            labelLeftImageIndex.Text = " ";
            labelLeftImageIndex.Click += forAll_labels_ImageIndex_Click;
            // 
            // pictureBoxLeft
            // 
            pictureBoxLeft.Cursor = Cursors.Cross;
            pictureBoxLeft.Location = new Point(366, 6);
            pictureBoxLeft.Name = "pictureBoxLeft";
            pictureBoxLeft.Size = new Size(512, 512);
            pictureBoxLeft.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLeft.TabIndex = 0;
            pictureBoxLeft.TabStop = false;
            pictureBoxLeft.DoubleClick += pictureBoxForAll_DoubleClick;
            pictureBoxLeft.MouseDown += pictureBox_MouseDown;
            pictureBoxLeft.MouseMove += pictureBox_MouseMove;
            pictureBoxLeft.MouseUp += pictureBox_MouseUp;
            pictureBoxLeft.MouseWheel += pictureBoxZoomImage_MouseWheel;
            // 
            // tabPageRight
            // 
            tabPageRight.Controls.Add(labelRightImageIndex);
            tabPageRight.Controls.Add(pictureBoxRight);
            tabPageRight.Location = new Point(4, 30);
            tabPageRight.Name = "tabPageRight";
            tabPageRight.Padding = new Padding(3);
            tabPageRight.Size = new Size(1244, 520);
            tabPageRight.TabIndex = 3;
            tabPageRight.Text = "Right";
            tabPageRight.UseVisualStyleBackColor = true;
            // 
            // labelRightImageIndex
            // 
            labelRightImageIndex.AutoSize = true;
            labelRightImageIndex.Location = new Point(6, 3);
            labelRightImageIndex.Name = "labelRightImageIndex";
            labelRightImageIndex.Size = new Size(14, 21);
            labelRightImageIndex.TabIndex = 1;
            labelRightImageIndex.Text = " ";
            labelRightImageIndex.Click += forAll_labels_ImageIndex_Click;
            // 
            // pictureBoxRight
            // 
            pictureBoxRight.Cursor = Cursors.Cross;
            pictureBoxRight.Location = new Point(366, 6);
            pictureBoxRight.Name = "pictureBoxRight";
            pictureBoxRight.Size = new Size(512, 512);
            pictureBoxRight.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxRight.TabIndex = 0;
            pictureBoxRight.TabStop = false;
            pictureBoxRight.DoubleClick += pictureBoxForAll_DoubleClick;
            pictureBoxRight.MouseDown += pictureBox_MouseDown;
            pictureBoxRight.MouseMove += pictureBox_MouseMove;
            pictureBoxRight.MouseUp += pictureBox_MouseUp;
            pictureBoxRight.MouseWheel += pictureBoxZoomImage_MouseWheel;
            // 
            // numericUpDownShiftimageIndex
            // 
            numericUpDownShiftimageIndex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownShiftimageIndex.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownShiftimageIndex.Location = new Point(1168, 2);
            numericUpDownShiftimageIndex.Name = "numericUpDownShiftimageIndex";
            numericUpDownShiftimageIndex.Size = new Size(38, 29);
            numericUpDownShiftimageIndex.TabIndex = 4;
            numericUpDownShiftimageIndex.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDownShiftimageIndex.ValueChanged += numericUpDownNumber_ValueChanged;
            // 
            // labelShift
            // 
            labelShift.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelShift.AutoSize = true;
            labelShift.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelShift.Location = new Point(1216, 5);
            labelShift.Name = "labelShift";
            labelShift.Size = new Size(42, 21);
            labelShift.TabIndex = 5;
            labelShift.Text = "Shift";
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel, toolStripSplitButton1 });
            statusStrip.Location = new Point(0, 589);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1264, 22);
            statusStrip.TabIndex = 6;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(254, 17);
            toolStripStatusLabel.Text = "Set basic folder to recognize string in clipboard";
            // 
            // toolStripSplitButton1
            // 
            toolStripSplitButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripSplitButton1.DropDownItems.AddRange(new ToolStripItem[] { openBasicFolderToolStripMenuItem, resetBasicFolderToolStripMenuItem });
            toolStripSplitButton1.Image = (Image)resources.GetObject("toolStripSplitButton1.Image");
            toolStripSplitButton1.ImageTransparentColor = Color.Magenta;
            toolStripSplitButton1.Name = "toolStripSplitButton1";
            toolStripSplitButton1.Size = new Size(32, 20);
            toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // openBasicFolderToolStripMenuItem
            // 
            openBasicFolderToolStripMenuItem.Name = "openBasicFolderToolStripMenuItem";
            openBasicFolderToolStripMenuItem.Size = new Size(307, 22);
            openBasicFolderToolStripMenuItem.Text = "Open basic folder";
            openBasicFolderToolStripMenuItem.Click += openBasicFolderToolStripMenuItem_Click;
            // 
            // resetBasicFolderToolStripMenuItem
            // 
            resetBasicFolderToolStripMenuItem.Name = "resetBasicFolderToolStripMenuItem";
            resetBasicFolderToolStripMenuItem.Size = new Size(307, 22);
            resetBasicFolderToolStripMenuItem.Text = "Reset basic folder (вставляти тільки номер)";
            resetBasicFolderToolStripMenuItem.Click += resetBasicFolderToolStripMenuItem_Click;
            // 
            // buttonPast
            // 
            buttonPast.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonPast.Location = new Point(0, 0);
            buttonPast.Name = "buttonPast";
            buttonPast.Size = new Size(117, 30);
            buttonPast.TabIndex = 7;
            buttonPast.Text = "Paste";
            buttonPast.UseVisualStyleBackColor = true;
            buttonPast.Click += buttonPast_Click;
            // 
            // labelLoading
            // 
            labelLoading.BorderStyle = BorderStyle.FixedSingle;
            labelLoading.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelLoading.Location = new Point(198, 3);
            labelLoading.Name = "labelLoading";
            labelLoading.Size = new Size(96, 23);
            labelLoading.TabIndex = 8;
            labelLoading.Text = "Loading...";
            labelLoading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonNumberDown
            // 
            buttonNumberDown.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonNumberDown.Location = new Point(198, 0);
            buttonNumberDown.Name = "buttonNumberDown";
            buttonNumberDown.Size = new Size(48, 30);
            buttonNumberDown.TabIndex = 9;
            buttonNumberDown.Text = "<<";
            buttonNumberDown.UseVisualStyleBackColor = true;
            buttonNumberDown.Click += buttonNumberDown_Click;
            // 
            // buttonNumberUp
            // 
            buttonNumberUp.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonNumberUp.Location = new Point(246, 0);
            buttonNumberUp.Name = "buttonNumberUp";
            buttonNumberUp.Size = new Size(48, 30);
            buttonNumberUp.TabIndex = 10;
            buttonNumberUp.Text = ">>";
            buttonNumberUp.UseVisualStyleBackColor = true;
            buttonNumberUp.Click += buttonNumberUp_Click;
            // 
            // checkBoxFixZoom
            // 
            checkBoxFixZoom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxFixZoom.AutoSize = true;
            checkBoxFixZoom.Checked = true;
            checkBoxFixZoom.CheckState = CheckState.Checked;
            checkBoxFixZoom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxFixZoom.Location = new Point(1069, 4);
            checkBoxFixZoom.Name = "checkBoxFixZoom";
            checkBoxFixZoom.Size = new Size(93, 25);
            checkBoxFixZoom.TabIndex = 14;
            checkBoxFixZoom.Text = "Fix Zoom";
            checkBoxFixZoom.UseVisualStyleBackColor = true;
            // 
            // buttonZoomFit
            // 
            buttonZoomFit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonZoomFit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonZoomFit.Location = new Point(1027, 0);
            buttonZoomFit.Name = "buttonZoomFit";
            buttonZoomFit.Size = new Size(35, 30);
            buttonZoomFit.TabIndex = 15;
            buttonZoomFit.Text = "><";
            buttonZoomFit.UseVisualStyleBackColor = true;
            buttonZoomFit.Click += buttonZoomFit_Click;
            // 
            // Image4lass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonZoomFit;
            ClientSize = new Size(1264, 611);
            Controls.Add(buttonZoomFit);
            Controls.Add(checkBoxFixZoom);
            Controls.Add(buttonNumberUp);
            Controls.Add(buttonNumberDown);
            Controls.Add(labelLoading);
            Controls.Add(buttonPast);
            Controls.Add(statusStrip);
            Controls.Add(labelShift);
            Controls.Add(numericUpDownShiftimageIndex);
            Controls.Add(tabControl);
            Controls.Add(comboBoxFoldreName);
            Controls.Add(buttonOpenFolder);
            Controls.Add(numericUpDownFotoNumber);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MinimumSize = new Size(960, 480);
            Name = "Image4lass";
            Text = "Image4lass 13-11-2023";
            FormClosing += Image4lass_FormClosing;
            Load += Image4lass_Load;
            KeyUp += Image4lass_KeyUp;
            ((System.ComponentModel.ISupportInitialize)numericUpDownFotoNumber).EndInit();
            tabControl.ResumeLayout(false);
            tabPageForward.ResumeLayout(false);
            tabPageForward.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxForward).EndInit();
            tabPageRear.ResumeLayout(false);
            tabPageRear.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRear).EndInit();
            tabPageLeft.ResumeLayout(false);
            tabPageLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLeft).EndInit();
            tabPageRight.ResumeLayout(false);
            tabPageRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownShiftimageIndex).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numericUpDownFotoNumber;
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
        private Button buttonPast;
        private Label labelLoading;
        private Button buttonNumberDown;
        private Button buttonNumberUp;
        private Label labelLeftImageIndex;
        private Label labelRightImageIndex;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripMenuItem openBasicFolderToolStripMenuItem;
        private FolderBrowserDialog basicFolderBrowserDialog;
        private ToolStripMenuItem resetBasicFolderToolStripMenuItem;
        private CheckBox checkBoxFixZoom;
        private Button buttonZoomFit;
    }
}