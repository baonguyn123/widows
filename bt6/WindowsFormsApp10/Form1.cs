using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp10.Models;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        Model1 model = new Model1();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Model1 model = new Model1();
                List<Faculty> listFalcultys = model.Faculty.ToList(); //lấy các khoa
                List<Student> listStudent = model.Student.ToList(); //lấy sinh viên
                FillFalcutyComboBox(listFalcultys);
                BindGrid(listStudent);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}\nChi tiết: {ex.InnerException?.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FillFalcutyComboBox(List<Faculty> listFalcutys)
        {
            this.cbKhoa.DataSource = listFalcutys;
            this.cbKhoa.DisplayMember = "FacultyName";
            this.cbKhoa.ValueMember = "FacultyID";
        }
        private void BindGrid(List<Student> listStudent)
        {
            var lstStudent = model.Student.ToList();
            List<VMNguoiDung> lstVMNStudents = new List<VMNguoiDung>();
            foreach (var item in lstStudent)
            {
                VMNguoiDung VM = new VMNguoiDung();
                VM.StudentID = item.StudentID;
                VM.FullName = item.FullName;
                VM.FacultyName = item.Faculty.FacultyName;
                VM.AverageScore = item.AverageScore;
                lstVMNStudents.Add(VM);
            }
            dataGridView1.DataSource = lstVMNStudents;
            dataGridView1.AutoGenerateColumns = false;
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Gán dữ liệu từ hàng vào các ô nhập liệu
                txtMSSV.Text = selectedRow.Cells[0].Value.ToString();
                txtTen.Text = selectedRow.Cells[1].Value.ToString();
                cbKhoa.Text = selectedRow.Cells[2].Value.ToString();
                txtDTB.Text = selectedRow.Cells[3].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 model = new Model1();
                List<Student> students = model.Student.ToList();
                if (students.Any(s => s.StudentID == txtMSSV.Text))
                {
                    MessageBox.Show("Mã số sinh viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var newStudent = new Student
                {
                    StudentID = txtMSSV.Text,
                    FullName = txtTen.Text,
                    FacultyID = int.Parse(cbKhoa.SelectedValue.ToString()),
                    AverageScore = float.Parse(txtDTB.Text)
                };
                model.Student.Add(newStudent);
                model.SaveChanges();
                BindGrid(model.Student.ToList());
                MessageBox.Show("Thêm sinh viên thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm sinh viên thất bại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 model = new Model1();
                List<Student> students = model.Student.ToList();
                var student = students.FirstOrDefault(s => s.StudentID == txtMSSV.Text);
                if (student != null)
                {
                    model.Student.Remove(student);
                    model.SaveChanges();
                    BindGrid(model.Student.ToList());
                    MessageBox.Show("Xóa sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(" sinh viên không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 model = new Model1();
                List<Student> students = model.Student.ToList();
                var student = students.FirstOrDefault(s => s.StudentID == txtMSSV.Text);
                if (student != null) {
                    if(students.Any(s=>s.StudentID == txtMSSV.Text && s.StudentID != student.StudentID))
                    {
                        MessageBox.Show("Mã số sinh viên đã tồn tại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    student.FullName = txtTen.Text;
                    student.FacultyID = int.Parse(cbKhoa.SelectedValue.ToString());
                    student.AverageScore = float.Parse(txtDTB.Text);
                    model.SaveChanges();// Lưu thay đổi vào cơ sở dữ liệu
                    BindGrid(model.Student.ToList()); // Cập nhật lại lưới
                    MessageBox.Show("Sửa  sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sinh viên không tìm thấy ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                }
            catch(Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
