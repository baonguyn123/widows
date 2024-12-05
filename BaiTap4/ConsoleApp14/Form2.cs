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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(NhanVien nhanVien) : this()
        {
            txtMSNV.Text = nhanVien.MSNV;
            txtTen.Text = nhanVien.tenNV;
            txtLuong.Text = nhanVien.luongCB.ToString();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        /*Thuộc tính này được dùng để lưu thông tin của nhân viên mới mà người dùng nhập vào.*/
        public NhanVien NhanVien { get; set; }
        private void btnDongY_Click(object sender, EventArgs e)
        {
             NhanVien = new NhanVien
            {
                MSNV = txtMSNV.Text,
                tenNV = txtTen.Text,
                luongCB = float.Parse(txtLuong.Text)
            };
            this.DialogResult = DialogResult.OK;
        }
    }
}
