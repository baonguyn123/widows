using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string _currentFilePath = null; // Holds the file path
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentFilePath))
            {
                
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Lưu nội dung văn bản";
                saveFileDialog.Filter = "Rich Text Format|*.rtf"; 
                saveFileDialog.DefaultExt = "rtf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _currentFilePath = saveFileDialog.FileName; // 
                    richTextBox1.SaveFile(_currentFilePath, RichTextBoxStreamType.RichText);
                    MessageBox.Show("Văn bản đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Save to existing file path
                richTextBox1.SaveFile(_currentFilePath, RichTextBoxStreamType.RichText);
                MessageBox.Show("Văn bản đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFont.Text = "Tahoma";
            LoadSize.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                LoadFont.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                LoadSize.Items.Add(s);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sự kiện Tạo Mới đã được kích hoạt!");
            richTextBox1.Clear();

            // Thiết lập lại Font và Size mặc định
            richTextBox1.Font = new Font("Times New Roman", 12);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem văn bản hiện tại có được in đậm không
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle = currentFont.Style ^ FontStyle.Bold;
                richTextBox1.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem văn bản hiện tại có được in nghiêng không
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle = currentFont.Style ^ FontStyle.Italic;
                richTextBox1.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem văn bản hiện tại có được gạch chân không
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle = currentFont.Style ^ FontStyle.Underline;
                richTextBox1.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Mở văn bản";
            openFile.Filter = "Text Files|*.txt|Rich Text Format|*.rtf"; // Lọc các file văn bản

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                // Tạo Form mới để hiển thị nội dung văn bản
                Form frmVanBan = new Form();
                frmVanBan.Text = "Văn bản - " + openFile.FileName;
                frmVanBan.Width = 800;
                frmVanBan.Height = 600;

                // Tạo RichTextBox để hiển thị văn bản
                RichTextBox rtbVanBan = new RichTextBox();
                rtbVanBan.Dock = DockStyle.Fill; // Chiếm toàn bộ form
                rtbVanBan.Font = new Font("Tahoma", 12);

                // Đọc nội dung file vào RichTextBox
                if (openFile.FilterIndex == 1) // Nếu là file .txt
                {
                    rtbVanBan.Text = System.IO.File.ReadAllText(openFile.FileName);
                }
                else if (openFile.FilterIndex == 2) // Nếu là file .rtf
                {
                    rtbVanBan.LoadFile(openFile.FileName, RichTextBoxStreamType.RichText);
                }

                // Thêm RichTextBox vào Form và hiển thị
                frmVanBan.Controls.Add(rtbVanBan);
                frmVanBan.MdiParent = this; // Mở trong cửa sổ cha (MDI)
                frmVanBan.Show();
            }
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            // Thiết lập lại Font và Size mặc định
            richTextBox1.Font = new Font("Times New Roman", 12);
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "RTF File | *.rtf |txt File|*.txt";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(sv.FileName);
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            ApplyFontChange();
        }
        private void ApplyFontChange()
        {
            // Kiểm tra nếu có văn bản được chọn
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;

                // Lấy font từ ComboBox (ToolStripComboBox2 hoặc các combo khác)
                string fontName = LoadFont.SelectedItem?.ToString() ?? currentFont.FontFamily.Name;

                // Lấy size từ ComboBox
                float fontSize = float.TryParse(LoadSize.SelectedItem?.ToString(), out float size) ? size : currentFont.Size;

                // Giữ nguyên FontStyle hiện tại
                FontStyle fontStyle = currentFont.Style;

                // Áp dụng font mới
                richTextBox1.SelectionFont = new Font(fontName, fontSize, fontStyle);
            }
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                FontDialog fontDlg = new FontDialog();
                fontDlg.ShowColor = true;
                fontDlg.ShowApply = true;
                fontDlg.ShowEffects = true;
                fontDlg.ShowHelp = true;
                if (fontDlg.ShowDialog() != DialogResult.Cancel)
                {
                    richTextBox1.ForeColor = fontDlg.Color;
                    richTextBox1.Font = fontDlg.Font;
                }
            }
        }
        private void UpdateFont()
        {
            if (richTextBox1.SelectionFont != null)
            {
                // Lấy font hiện tại của văn bản
                Font currentFont = richTextBox1.SelectionFont;

                // Lấy Font Family từ ComboBox
                string fontName = LoadFont.SelectedItem?.ToString() ?? currentFont.FontFamily.Name;

                // Lấy kích thước từ ComboBox
                float fontSize = float.TryParse(LoadSize.SelectedItem?.ToString(), out float size) ? size : currentFont.Size;

                // Áp dụng font mới với FontStyle hiện tại
                richTextBox1.SelectionFont = new Font(fontName, fontSize, currentFont.Style);
            }
        }


        private void LoadFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFont();
        }

        private void LoadSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFont();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close ();
        }

        private void LoadSize_Click(object sender, EventArgs e)
        {

        }
    }
}
