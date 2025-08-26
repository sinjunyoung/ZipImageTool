namespace ZipImageTool
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            materialComboBox_USB = new ComboBox();
            imageList1 = new ImageList(components);
            button_ImageWriteOpen = new Button();
            button_Write = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            button_Read = new Button();
            button_ImageReadOpen = new Button();
            tabControl1 = new CustomTabControl();
            tabPage3 = new TabPage();
            richTextBox_ImageWrite = new RichTextBox();
            pictureBox_Write = new PictureBox();
            tabPage4 = new TabPage();
            richTextBox_ImageRead = new RichTextBox();
            materialComboBox_CompressionLevel = new ComboBox();
            pictureBox_CompressionLevel = new PictureBox();
            materialComboBox_MaxOutputSegmentSize64 = new ComboBox();
            pictureBox_MaxOutputSegmentSize64 = new PictureBox();
            pictureBox_Read = new PictureBox();
            pictureBox_USB = new PictureBox();
            statusStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Write).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_CompressionLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_MaxOutputSegmentSize64).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Read).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_USB).BeginInit();
            SuspendLayout();
            // 
            // materialComboBox_USB
            // 
            materialComboBox_USB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            materialComboBox_USB.DropDownHeight = 174;
            materialComboBox_USB.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox_USB.DropDownWidth = 121;
            materialComboBox_USB.Font = new Font("굴림체", 10F);
            materialComboBox_USB.FormattingEnabled = true;
            materialComboBox_USB.IntegralHeight = false;
            materialComboBox_USB.ItemHeight = 20;
            materialComboBox_USB.Location = new Point(83, 22);
            materialComboBox_USB.MaxDropDownItems = 4;
            materialComboBox_USB.Name = "materialComboBox_USB";
            materialComboBox_USB.Size = new Size(874, 28);
            materialComboBox_USB.TabIndex = 1;
            materialComboBox_USB.DropDown += materialComboBox1_DropDown;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "refresh.png");
            imageList1.Images.SetKeyName(1, "ReadOpen.png");
            imageList1.Images.SetKeyName(2, "WriteOpen.png");
            imageList1.Images.SetKeyName(3, "ReadImage.png");
            imageList1.Images.SetKeyName(4, "run.png");
            imageList1.Images.SetKeyName(5, "read.png");
            imageList1.Images.SetKeyName(6, "write.png");
            // 
            // button_ImageWriteOpen
            // 
            button_ImageWriteOpen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_ImageWriteOpen.ImageAlign = ContentAlignment.MiddleLeft;
            button_ImageWriteOpen.ImageIndex = 1;
            button_ImageWriteOpen.ImageList = imageList1;
            button_ImageWriteOpen.Location = new Point(830, 7);
            button_ImageWriteOpen.Name = "button_ImageWriteOpen";
            button_ImageWriteOpen.Size = new Size(120, 49);
            button_ImageWriteOpen.TabIndex = 7;
            button_ImageWriteOpen.Text = "열기";
            button_ImageWriteOpen.TextAlign = ContentAlignment.MiddleRight;
            button_ImageWriteOpen.UseVisualStyleBackColor = true;
            button_ImageWriteOpen.Click += button_ImageWriteOpen_Click;
            // 
            // button_Write
            // 
            button_Write.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_Write.ImageAlign = ContentAlignment.MiddleLeft;
            button_Write.ImageIndex = 4;
            button_Write.ImageList = imageList1;
            button_Write.Location = new Point(830, 216);
            button_Write.Name = "button_Write";
            button_Write.Size = new Size(120, 49);
            button_Write.TabIndex = 8;
            button_Write.Text = "굽기";
            button_Write.TextAlign = ContentAlignment.MiddleRight;
            button_Write.UseVisualStyleBackColor = true;
            button_Write.Click += button_Write_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, toolStripProgressBar1 });
            statusStrip1.Location = new Point(3, 415);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(967, 32);
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.AutoSize = false;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(278, 25);
            toolStripStatusLabel1.Spring = true;
            toolStripStatusLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.AutoSize = false;
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(520, 25);
            toolStripStatusLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(150, 24);
            // 
            // button_Read
            // 
            button_Read.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_Read.ImageAlign = ContentAlignment.MiddleLeft;
            button_Read.ImageIndex = 3;
            button_Read.ImageList = imageList1;
            button_Read.Location = new Point(830, 216);
            button_Read.Name = "button_Read";
            button_Read.Size = new Size(120, 49);
            button_Read.TabIndex = 10;
            button_Read.Text = "저장";
            button_Read.TextAlign = ContentAlignment.MiddleRight;
            button_Read.UseVisualStyleBackColor = true;
            button_Read.Click += button_Read_Click;
            // 
            // button_ImageReadOpen
            // 
            button_ImageReadOpen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_ImageReadOpen.ImageAlign = ContentAlignment.MiddleLeft;
            button_ImageReadOpen.ImageIndex = 2;
            button_ImageReadOpen.ImageList = imageList1;
            button_ImageReadOpen.Location = new Point(830, 7);
            button_ImageReadOpen.Name = "button_ImageReadOpen";
            button_ImageReadOpen.Size = new Size(120, 49);
            button_ImageReadOpen.TabIndex = 14;
            button_ImageReadOpen.Text = "열기";
            button_ImageReadOpen.TextAlign = ContentAlignment.MiddleRight;
            button_ImageReadOpen.UseVisualStyleBackColor = true;
            button_ImageReadOpen.Click += button_ImageReadOpen_Click;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.ImageList = imageList1;
            tabControl1.ItemSize = new Size(150, 50);
            tabControl1.Location = new Point(3, 83);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new Point(15, 4);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(964, 329);
            tabControl1.TabIndex = 14;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(richTextBox_ImageWrite);
            tabPage3.Controls.Add(pictureBox_Write);
            tabPage3.Controls.Add(button_Write);
            tabPage3.Controls.Add(button_ImageWriteOpen);
            tabPage3.ImageIndex = 6;
            tabPage3.Location = new Point(4, 54);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(956, 271);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "굽기";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox_ImageWrite
            // 
            richTextBox_ImageWrite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox_ImageWrite.DetectUrls = false;
            richTextBox_ImageWrite.Font = new Font("맑은 고딕", 9F);
            richTextBox_ImageWrite.Location = new Point(76, 7);
            richTextBox_ImageWrite.Name = "richTextBox_ImageWrite";
            richTextBox_ImageWrite.Size = new Size(748, 49);
            richTextBox_ImageWrite.TabIndex = 19;
            richTextBox_ImageWrite.Text = "";
            // 
            // pictureBox_Write
            // 
            pictureBox_Write.Image = Properties.Resources.file;
            pictureBox_Write.Location = new Point(12, 6);
            pictureBox_Write.Name = "pictureBox_Write";
            pictureBox_Write.Size = new Size(50, 50);
            pictureBox_Write.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_Write.TabIndex = 17;
            pictureBox_Write.TabStop = false;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(richTextBox_ImageRead);
            tabPage4.Controls.Add(materialComboBox_CompressionLevel);
            tabPage4.Controls.Add(pictureBox_CompressionLevel);
            tabPage4.Controls.Add(materialComboBox_MaxOutputSegmentSize64);
            tabPage4.Controls.Add(pictureBox_MaxOutputSegmentSize64);
            tabPage4.Controls.Add(pictureBox_Read);
            tabPage4.Controls.Add(button_Read);
            tabPage4.Controls.Add(button_ImageReadOpen);
            tabPage4.ImageIndex = 5;
            tabPage4.Location = new Point(4, 54);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(956, 271);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "저장";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // richTextBox_ImageRead
            // 
            richTextBox_ImageRead.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox_ImageRead.DetectUrls = false;
            richTextBox_ImageRead.Font = new Font("맑은 고딕", 9F);
            richTextBox_ImageRead.Location = new Point(76, 7);
            richTextBox_ImageRead.Name = "richTextBox_ImageRead";
            richTextBox_ImageRead.Size = new Size(748, 49);
            richTextBox_ImageRead.TabIndex = 21;
            richTextBox_ImageRead.Text = "";
            // 
            // materialComboBox_CompressionLevel
            // 
            materialComboBox_CompressionLevel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            materialComboBox_CompressionLevel.DropDownHeight = 174;
            materialComboBox_CompressionLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox_CompressionLevel.DropDownWidth = 121;
            materialComboBox_CompressionLevel.Font = new Font("굴림체", 10F);
            materialComboBox_CompressionLevel.FormattingEnabled = true;
            materialComboBox_CompressionLevel.IntegralHeight = false;
            materialComboBox_CompressionLevel.ItemHeight = 20;
            materialComboBox_CompressionLevel.Items.AddRange(new object[] { "압축 안함", "보통 압축률", "최고 압축률" });
            materialComboBox_CompressionLevel.Location = new Point(76, 160);
            materialComboBox_CompressionLevel.MaxDropDownItems = 4;
            materialComboBox_CompressionLevel.Name = "materialComboBox_CompressionLevel";
            materialComboBox_CompressionLevel.Size = new Size(874, 28);
            materialComboBox_CompressionLevel.TabIndex = 19;
            materialComboBox_CompressionLevel.Visible = false;
            // 
            // pictureBox_CompressionLevel
            // 
            pictureBox_CompressionLevel.Image = (Image)resources.GetObject("pictureBox_CompressionLevel.Image");
            pictureBox_CompressionLevel.Location = new Point(12, 150);
            pictureBox_CompressionLevel.Name = "pictureBox_CompressionLevel";
            pictureBox_CompressionLevel.Size = new Size(50, 50);
            pictureBox_CompressionLevel.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_CompressionLevel.TabIndex = 20;
            pictureBox_CompressionLevel.TabStop = false;
            pictureBox_CompressionLevel.Visible = false;
            // 
            // materialComboBox_MaxOutputSegmentSize64
            // 
            materialComboBox_MaxOutputSegmentSize64.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            materialComboBox_MaxOutputSegmentSize64.DropDownHeight = 174;
            materialComboBox_MaxOutputSegmentSize64.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox_MaxOutputSegmentSize64.DropDownWidth = 121;
            materialComboBox_MaxOutputSegmentSize64.Font = new Font("굴림체", 10F);
            materialComboBox_MaxOutputSegmentSize64.FormattingEnabled = true;
            materialComboBox_MaxOutputSegmentSize64.IntegralHeight = false;
            materialComboBox_MaxOutputSegmentSize64.ItemHeight = 20;
            materialComboBox_MaxOutputSegmentSize64.Items.AddRange(new object[] { "분할안함", "1GB", "2GB", "5GB", "10GB", "20GB", "50GB", "100GB" });
            materialComboBox_MaxOutputSegmentSize64.Location = new Point(76, 93);
            materialComboBox_MaxOutputSegmentSize64.MaxDropDownItems = 4;
            materialComboBox_MaxOutputSegmentSize64.Name = "materialComboBox_MaxOutputSegmentSize64";
            materialComboBox_MaxOutputSegmentSize64.Size = new Size(874, 28);
            materialComboBox_MaxOutputSegmentSize64.TabIndex = 16;
            materialComboBox_MaxOutputSegmentSize64.Visible = false;
            // 
            // pictureBox_MaxOutputSegmentSize64
            // 
            pictureBox_MaxOutputSegmentSize64.Image = (Image)resources.GetObject("pictureBox_MaxOutputSegmentSize64.Image");
            pictureBox_MaxOutputSegmentSize64.Location = new Point(12, 80);
            pictureBox_MaxOutputSegmentSize64.Name = "pictureBox_MaxOutputSegmentSize64";
            pictureBox_MaxOutputSegmentSize64.Size = new Size(50, 50);
            pictureBox_MaxOutputSegmentSize64.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_MaxOutputSegmentSize64.TabIndex = 18;
            pictureBox_MaxOutputSegmentSize64.TabStop = false;
            pictureBox_MaxOutputSegmentSize64.Visible = false;
            // 
            // pictureBox_Read
            // 
            pictureBox_Read.Image = Properties.Resources.file;
            pictureBox_Read.Location = new Point(12, 6);
            pictureBox_Read.Name = "pictureBox_Read";
            pictureBox_Read.Size = new Size(50, 50);
            pictureBox_Read.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_Read.TabIndex = 16;
            pictureBox_Read.TabStop = false;
            // 
            // pictureBox_USB
            // 
            pictureBox_USB.Image = (Image)resources.GetObject("pictureBox_USB.Image");
            pictureBox_USB.Location = new Point(19, 13);
            pictureBox_USB.Name = "pictureBox_USB";
            pictureBox_USB.Size = new Size(50, 50);
            pictureBox_USB.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_USB.TabIndex = 15;
            pictureBox_USB.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Control;
            ClientSize = new Size(973, 450);
            Controls.Add(pictureBox_USB);
            Controls.Add(tabControl1);
            Controls.Add(statusStrip1);
            Controls.Add(materialComboBox_USB);
            Font = new Font("맑은 고딕", 9F);
            Name = "MainForm";
            Padding = new Padding(3, 80, 3, 3);
            Text = "ZipImageTool";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_Write).EndInit();
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_CompressionLevel).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_MaxOutputSegmentSize64).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Read).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_USB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox materialComboBox_USB;
        private Button button_ImageWriteOpen;
        private Button button_Write;
        private ImageList imageList1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private Button button_Read;
        private Button button_ImageReadOpen;
        private CustomTabControl tabControl1;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private PictureBox pictureBox_USB;
        private PictureBox pictureBox_Write;
        private PictureBox pictureBox_Read;
        private ComboBox materialComboBox_MaxOutputSegmentSize64;
        private PictureBox pictureBox_MaxOutputSegmentSize64;
        private ComboBox materialComboBox_CompressionLevel;
        private PictureBox pictureBox_CompressionLevel;
        private RichTextBox richTextBox_ImageWrite;
        private RichTextBox richTextBox_ImageRead;
    }
}
