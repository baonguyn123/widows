using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp14
{
    public partial class Form1 : Form
    {
        List<NhanVien>dsnv = new List<NhanVien>();
        public Form1()
        {
            InitializeComponent();
        }
        /*Làm mới bảng DataGridView.
          Gán danh sách hoặc tập dữ liệu từ employees vào DataGridView để hiển thị.*/
        private void DataFGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dsnv;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            // Nếu người dùng nhấn "Đồng ý"
            if (frm.ShowDialog() == DialogResult.OK)
            {
                /* Lấy dữ liệu từ form nhập liệu*/
                dsnv.Add(frm.NhanVien);
                // Cập nhật DataGridView
                DataFGridView();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //nếu có ít nhất 1 dòng được chọn thì tiếp tục

            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy chỉ số dòng đã chọn
                int index = dataGridView1.SelectedRows[0].Index;
                // Lấy nhân viên từ danh sách theo chỉ số đã chọn
                NhanVien selectedEmployee = dsnv[index];
                // Mở form sửa thông tin nhân viên với thông tin nhân viên đã chọn
                Form2 frm = new Form2(selectedEmployee);
                // Lấy nhân vien từ danh sách theo chỉ số đã chọn
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        dsnv[index] = frm.NhanVien;
                        DataFGridView();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count >0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                NhanVien selectedEmployee = dsnv[index];
                //Xoa o dong da chon
                dsnv.RemoveAt(index);
                DataFGridView();
            }
            else
            {
                MessageBox.Show("Vui long cho mot nhan vien de xoa");
            }
        }
    }
}
