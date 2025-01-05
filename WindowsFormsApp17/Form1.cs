using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL.Models;

namespace WindowsFormsApp17
{
    public partial class Form1 : Form
    {
        private readonly StudentService studentService = new StudentService();
        private SinhVien currentStudent;
        public Form1()
        {
            studentService = new StudentService();
            InitializeComponent();
        }
        private bool isAdd = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            
            LoadForm();
            FillLopCMB();
            btnThoat.Enabled = false;
        }
        private void LoadForm()
        {
            var students = studentService.GetAll().ToList();


            var studentList = students.Select(s => new
            {
                MaSV = s.MaSV,
                HotenSV =s.HoTenSV,
                NgaySinh = s.NgaySinh,
                TenLop = s.Lop != null ? s.Lop.TenLop : ""
            }).ToList();


            dataGridView1.DataSource = studentList;
        }
        private void FillLopCMB()
        {
            var classes = studentService.GetAllClasses();
            if (classes != null && classes.Any())
            {
                cbLop.DataSource = classes;
                cbLop.DisplayMember = "TenLop";
                cbLop.ValueMember = "MaLop";
                cbLop.SelectedIndex = -1; // Không chọn lớp nào lúc đầu
            }
            else
            {
                MessageBox.Show("Không có dữ liệu lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbLop.DataSource = null;
            }
        }

        private void BindGrid(List<SinhVien> sinhViens)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in sinhViens)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.MaSV;
                dataGridView1.Rows[index].Cells[1].Value = item.HoTenSV;
                dataGridView1.Rows[index].Cells[2].Value = item.NgaySinh;
                dataGridView1.Rows[index].Cells[3].Value = item.Lop != null ? item.Lop.TenLop : "Công Nghệ Thông Tin";
            }
        }
        private void ClearForm()
        {
            txtMSSV.Clear();
            txtHoTen.Clear();
            txtTim.Clear();
            cbLop.SelectedIndex = -1;
        }
        private void ResetButtons()
        {
            btnThem.Enabled = true; // Nút Thêm
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnThoat.Enabled = false;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtTim.Text.Trim();

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                var searchResults = studentService.SearchStudents(searchKeyword);
                dataGridView1.DataSource = searchResults;
            }
            else
            {
                MessageBox.Show("Không tìm thấy tên cần tìm ");
                LoadForm();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdd = true;
            btnThoat.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentStudent != null)
            {
                studentService.Delete(currentStudent.MaSV);
                LoadForm();
                MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!");
            }
            ResetInputFields();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                var newStudent = new SinhVien
                {
                    MaSV = txtMSSV.Text,
                    HoTenSV = txtHoTen.Text,
                    NgaySinh = dateNS.Value,
                    MaLop = cbLop.SelectedValue.ToString()
                };

                studentService.Add(newStudent);
                LoadForm();
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (currentStudent != null)
                {
                    currentStudent.HoTenSV = txtHoTen.Text;
                    currentStudent.NgaySinh = dateNS.Value;
                    currentStudent.MaLop = cbLop.SelectedValue.ToString();

                    studentService.Update(currentStudent);

                    LoadForm();
                    MessageBox.Show("Sửa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ResetInputFields();
            isAdd = false;
            btnThoat.Enabled = false;
        }
        private void ResetInputFields()
        {

            txtMSSV.Clear();
            txtHoTen.Clear();
            dateNS.Value = DateTime.Now;
            cbLop.SelectedIndex = -1;
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThoat.Enabled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            ResetInputFields();
            btnThoat.Enabled = false;
            isAdd = true;
        }

        private void sinhVienBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                if (selectedRow.Cells["MaSV"].Value != null)
                {
                    var studentId = selectedRow.Cells["MaSV"].Value.ToString();
                    currentStudent = studentService.GetAll().FirstOrDefault(s => s.MaSV == studentId);

                    if (currentStudent != null)
                    {
                        txtMSSV.Text = currentStudent.MaSV;
                        txtHoTen.Text = currentStudent.HoTenSV;
                        dateNS.Value = currentStudent.NgaySinh ?? DateTime.Now;
                        cbLop.SelectedValue = currentStudent.MaLop;
                    }
                }
            }
        }
    }
}
  
