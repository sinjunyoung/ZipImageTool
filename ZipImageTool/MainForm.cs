using Ionic.Zlib;
using MaterialSkin;
using PickPack.Disk;
using SharpCompress.Common;
using System.ComponentModel;
using System.Diagnostics;

namespace ZipImageTool
{
    public partial class MainForm : MaterialSkin.Controls.MaterialForm
    {
        #region Field

        readonly MaterialSkinManager materialSkinManager;
        WmiWatchers wmiWatchers = new WmiWatchers();
        CancellationTokenSource? cancellationTokenSource;
        bool isWorking = false;

        #endregion

        public MainForm()
        {
            InitializeComponent();

            this.Text = $"{Application.ProductName} v 0.9b";

            #region Init MaterialSkinManager

            this.materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            this.materialSkinManager.AddFormToManage(this);

            void ApplyFontToAllControls(Control parent, System.Drawing.Font font)
            {
                foreach (Control c in parent.Controls)
                {
                    c.Font = font;
                    if (c.HasChildren)
                        ApplyFontToAllControls(c, font);
                }
            }

            ApplyFontToAllControls(this, this.Font);

            #endregion

            ListRemovableUsbDrives();

            this.wmiWatchers.USBArrival += (s, e) =>
            {
                MessageBox.Show("�̵��� ����̺��� ������ �����Ǿ����ϴ�.\n����̺� ����� �����մϴ�.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Invoke((Action)(() => ListRemovableUsbDrives()));
            };

            this.wmiWatchers.USBRemoval += (s, e) =>
            {
                MessageBox.Show("�̵��� ����̺��� �и��� �����Ǿ����ϴ�.\n����̺� ����� �����մϴ�.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Invoke((Action)(() => ListRemovableUsbDrives()));
            };
        }


        #region Private        

        private void ListRemovableUsbDrives()
        {
            this.materialComboBox_USB.Items.Clear();
            var infos = DriveInfos.GetDriveInfos();
            foreach (var info in infos)
                this.materialComboBox_USB.Items.Add(info);

            if (this.materialComboBox_USB.Items.Count == 0)
            {
                MessageBox.Show("����� �̵��� ����̺갡 �����ϴ�.\n���� �� ��õ� �ϼ���.", "�˸�",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.materialComboBox_USB.SelectedIndex = 0;
            }
        }

        private long GetMaxOutputSegmentSize64()
        {
            switch (this.materialComboBox_MaxOutputSegmentSize64.SelectedIndex)
            {
                // ���Ҿ���
                case 0:
                    return 0;
                // 1GB
                case 1:
                    return 1073741824;
                // 2GB
                case 2:
                    return 2 * FileSize._1GB;
                // 5GB
                case 3:
                    return 5 * FileSize._1GB;
                // 10GB
                case 4:
                    return 10 * FileSize._1GB;
                // 20GB
                case 5:
                    return 20 * FileSize._1GB;
                // 50GB
                case 6:
                    return 50 * FileSize._1GB;
                // 100GB
                case 7:
                    return 100 * FileSize._1GB;
                default:
                    return 20 * FileSize._1GB;
            }
        }

        private CompressionLevel GetCompressionLevel()
        {
            switch (this.materialComboBox_CompressionLevel.SelectedIndex)
            {
                // ������
                case 0:
                    return CompressionLevel.None;
                // ����
                case 1:
                    return CompressionLevel.Level4;
                // �ְ�
                case 2:
                    return CompressionLevel.BestCompression;
                default:
                    return CompressionLevel.None;
            }
        }

        private void DeleteArchiveTempAndPartialFiles(string fileName)
        {
            File.Delete(fileName);
            string directoryPath = Path.GetDirectoryName(fileName);

            if (string.IsNullOrEmpty(directoryPath) || !Directory.Exists(directoryPath))
                return;

            try
            {
                string[] tempFiles = Directory.GetFiles(directoryPath, "DotNetZip-*.tmp");
                foreach (string file in tempFiles)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (IOException ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Could not delete temp file {file}: {ex.Message}");
                    }
                }

                string searchPattern = Path.GetFileNameWithoutExtension(fileName) + ".z*";
                string[] partialFiles = Directory.GetFiles(directoryPath, searchPattern);

                foreach (string file in partialFiles)
                {
                    try
                    {
                        File.Delete(file);
                        System.Diagnostics.Debug.WriteLine($"Deleted partial zip file: {file}");
                    }
                    catch (IOException ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Could not delete partial file {file}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        #endregion

        private void materialComboBox1_DropDown(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            int width = combo.DropDownWidth;
            Graphics g = combo.CreateGraphics();
            Font font = combo.Font;
            int vertScrollBarWidth = (combo.Items.Count > combo.MaxDropDownItems) ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;
            foreach (var s in combo.Items)
            {
                newWidth = (int)g.MeasureString(s.ToString(), font).Width + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            combo.DropDownWidth = width;
        }

        private async void button_Write_Click(object sender, EventArgs e)
        {
            if (this.isWorking)
            {   
                this.cancellationTokenSource?.Cancel();
                this.toolStripStatusLabel1.Text = "�����...";
                return;
            }

            if (this.materialComboBox_USB.SelectedIndex == -1)
            {
                MessageBox.Show("SD ī�带 �������ּ���.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string imagePath = this.richTextBox_ImageWrite.Text;

            if (!File.Exists(imagePath))
            {
                MessageBox.Show("�̹��� ������ �������ּ���.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("���⸦ �����ϸ� ������ ����̺��� ��� �����Ͱ� ���� �˴ϴ�.\n���� �ұ��?", "�˸�", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            this.isWorking = true;
            this.button_Read.Enabled = false;
            this.cancellationTokenSource = new CancellationTokenSource();
            this.button_Write.Text = "���";

            try
            {
                DriveInfos info = this.materialComboBox_USB.SelectedItem as DriveInfos;
                int diskNumber = info.DiskNumber;

                ImageWriter imgWriter = new ImageWriter();
                imgWriter.ProgressChanged += ImgWriter_ProgressChanged;
                imgWriter.WriteEnded += ImgWriter_WriteEnded;

                await imgWriter.WriteImageAsync(imagePath, diskNumber, info.SizeBytes, this.cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                this.toolStripProgressBar1.Value = 0;
                this.toolStripStatusLabel1.Text = "���� ���";

                await PartitionUtil.RescanDisksAsync();

                MessageBox.Show("���Ⱑ ��� �Ǿ����ϴ�.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show(ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.isWorking = false;
                this.button_Write.Text = "����";
                this.button_Read.Enabled = true;
                this.cancellationTokenSource?.Dispose();
                this.cancellationTokenSource = null;
            }
        }

        private void ImgWriter_ProgressChanged(object? sender, PickPack.Disk.ProgressEventArgs e)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => ImgWriter_ProgressChanged(sender, e)));
            else
            {
                this.toolStripProgressBar1.Value = e.Percent;
                this.toolStripStatusLabel1.Text = e.Message1;
                if(e.Message2 != null)
                    this.toolStripStatusLabel2.Text = e.Message2;

                Application.DoEvents();
            }
        }

        private async void ImgWriter_WriteEnded(object? sender, EventArgs e)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => ImgWriter_WriteEnded(sender, e)));
            else
            {
                this.toolStripProgressBar1.Value = 100;
                this.toolStripStatusLabel1.Text = "�̹��� ���� �Ϸ�";

                await PartitionUtil.RescanDisksAsync();

                // RescanDisks�� Drive Letter ������ �ȵǴ� ��찡 �־� �߰�
                PartitionUtil.AssignNextAvailableDriveLetter();

                Application.DoEvents();

                MessageBox.Show(this,
                    "�̹��� ���Ⱑ �Ϸ�Ǿ����ϴ�.",
                    "���� �Ϸ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void button_Read_Click(object sender, EventArgs e)
        {
            if (this.isWorking)
            {
                this.cancellationTokenSource?.Cancel();
                this.toolStripStatusLabel1.Text = "�����...";
                return;
            }

            if (this.materialComboBox_USB.SelectedIndex == -1)
            {
                MessageBox.Show("SD ī�带 �������ּ���.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string imagePath = this.richTextBox_ImageRead.Text;

            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("�̹��� ������ �������ּ���.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DriveInfos info = this.materialComboBox_USB.SelectedItem as DriveInfos;

            ulong freeSpace = 0;

            try
            {   
                freeSpace = DiskUtil.GetAvailableFreeSpace(Path.GetPathRoot(imagePath));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"��ũ �뷮�� Ȯ���ϴ� �� ������ �߻��߽��ϴ�: {ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }

            if (freeSpace < (ulong)info.SizeBytes)
            {
                MessageBox.Show("��ũ �뷮�� �����մϴ�.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.isWorking = true;
            this.button_Write.Enabled = false;
            this.cancellationTokenSource = new CancellationTokenSource();
            this.button_Read.Text = "���";

            try
            {   
                int diskNumber = info.DiskNumber;

                ImageReader reader = new ImageReader();
                reader.ProgressChanged += ImgWriter_ProgressChanged;
                reader.WriteEnded += Reader_WriteEnded;

                long maxOutputSegmentSize64 = GetMaxOutputSegmentSize64();
                CompressionLevel compressionLevel = GetCompressionLevel();

                await Task.Run(() => reader.ReadImageAsync(diskNumber, imagePath, maxOutputSegmentSize64, compressionLevel, this.cancellationTokenSource.Token));
            }
            catch (OperationCanceledException)
            {
                this.toolStripProgressBar1.Value = 0;
                this.toolStripStatusLabel1.Text = "���� ���";

                DeleteArchiveTempAndPartialFiles(this.richTextBox_ImageRead.Text);

                MessageBox.Show(this, "������ ��ҵǾ����ϴ�.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Win32Exception ex)
            {
                MessageBox.Show(this, ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.isWorking = false;
                this.button_Read.Text = "����";
                this.button_Write.Enabled = true;
                this.cancellationTokenSource?.Dispose();
                this.cancellationTokenSource = null;
            }
        }

        private void Reader_WriteEnded(object? sender, EventArgs e)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => Reader_WriteEnded(sender, e)));
            else
            {
                this.toolStripProgressBar1.Value = 100;
                this.toolStripStatusLabel1.Text = "�̹��� ���� �Ϸ�";

                Application.DoEvents();

                MessageBox.Show(this, "�̹��� ������ �Ϸ�Ǿ����ϴ�.", "���� �Ϸ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_ImageWriteOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ZIP ���� (*.zip)|*.zip|7z ���� (*.7z)|*.7z|gz ���� (*.gz)|*.gz|��ũ �̹��� ���� (*.img)|*.img|��� ���� (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(ofd.FileName);
                ext = ext.ToLowerInvariant();
                ext = ext.Substring(1);

                Image img = Properties.Resources.ResourceManager.GetObject(ext) as Bitmap;
                if (img == null)
                    img = Properties.Resources.file;

                this.pictureBox_Write.Image = img;
                this.richTextBox_ImageWrite.Text = ofd.FileName;
            }
        }

        private void button_ImageReadOpen_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "��ũ �̹��� ���� (*.img)|*.img|ZIP ���� (*.zip)|*.zip";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(sfd.FileName);
                ext = ext.ToLowerInvariant();
                ext = ext.Substring(1);

                Image img = Properties.Resources.ResourceManager.GetObject(ext) as Bitmap;
                if (img == null)
                    img = Properties.Resources.file;

                switch (ext)
                {
                    case "img":
                        {
                            this.pictureBox_MaxOutputSegmentSize64.Visible = false;
                            this.pictureBox_CompressionLevel.Visible = false;
                            this.materialComboBox_MaxOutputSegmentSize64.Visible = false;
                            this.materialComboBox_CompressionLevel.Visible = false;
                        }
                        break;
                    case "zip":
                        {
                            this.pictureBox_MaxOutputSegmentSize64.Visible= true;
                            this.pictureBox_CompressionLevel.Visible= true;
                            this.materialComboBox_MaxOutputSegmentSize64.Visible = true;
                            this.materialComboBox_CompressionLevel.Visible = true;
                        }
                        break;
                    default:
                        MessageBox.Show(this, "�������� �ʴ� ���� �����Դϴ�.(.zip �Ǵ� .img)", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                this.pictureBox_Read.Image = img;
                this.richTextBox_ImageRead.Text = sfd.FileName;
            }
        }
    }
}