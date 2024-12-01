using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào từ TextBox
            if (string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng điền thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Tạo 1 dòng dữ liệu (ListViewItem)
            ListViewItem it = new ListViewItem(txtLastName.Text);

            //Thêm các cột còn lại vào dòng it
            it.SubItems.Add(txtFirstName.Text);
            it.SubItems.Add(txtPhone.Text);

            //Đưa dòng dữ liệu lên listView
            lvStudent.Items.Add(it);

            // Xóa dữ liệu trong TextBox sau khi thêm
            txtLastName.Clear();
            txtFirstName.Clear();
            txtPhone.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có dòng nào được chọn
            if (lvStudent.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvStudent.SelectedItems[0];

                // Kiểm tra đầu vào
                if (string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật giá trị cho dòng được chọn
                selectedItem.Text = txtLastName.Text;
                selectedItem.SubItems[1].Text = txtFirstName.Text;
                selectedItem.SubItems[2].Text = txtPhone.Text;

                // Xóa TextBox sau khi sửa
                txtLastName.Clear();
                txtFirstName.Clear();
                txtPhone.Clear();
                txtLastName.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            {
                // Kiểm tra nếu có dòng nào được chọn
                if (lvStudent.SelectedItems.Count > 0)
                {
                    // Xóa dòng được chọn
                    lvStudent.Items.Remove(lvStudent.SelectedItems[0]);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
