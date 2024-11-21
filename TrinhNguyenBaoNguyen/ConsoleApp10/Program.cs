using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //Student student = new Student();
            //tao danh sach
            List<Student> students = new List<Student>();
            students.Add(new Student(1, "Bao Minh", 20));
            students.Add(new Student(2, "Bao Nguyen", 17));
            students.Add(new Student(3, "Vinh Phuc", 15));
            students.Add(new Student(4, "Anh", 19));
            students.Add(new Student(5, "Hai", 16));

            Console.WriteLine("Danh sach sinh vien: ");
            foreach (var student in students)
            {
                student.ShowThongTin();
            }
            var ds = students.Where(student=> student.Age >= 15 && student.Age <= 18).ToList();
            Console.WriteLine("B. Danh sach sinh vien tu 15 - 18: ");
            foreach (var student in ds)
            {
                student.ShowThongTin();
            }
            var ten = students.Where(student => student.Name.StartsWith("A")).ToList();
            Console.WriteLine("C. Hoc sinh co ten bat dau chu cai bang A : ");
            foreach(var student in ten)
            {
                student.ShowThongTin();
            }
            int tongTuoi = students.Sum(student => student.Age);
            Console.WriteLine("D. Tong tuoi tat ca cac hoc sinh : " +tongTuoi);
            var sinhVienLonTuoiNhat= students.OrderByDescending(student => student.Age).FirstOrDefault();
            Console.WriteLine($"E. Học sinh lớn tuổi nhất: ID: {sinhVienLonTuoiNhat.Id}, Tên: {sinhVienLonTuoiNhat.Name}, Tuổi: {sinhVienLonTuoiNhat.Age}");
            Console.WriteLine("F. Danh sach hoc sinh sap xep theo tuoi tang dan : ");
            var y = students.OrderBy(student => student.Age).ToList();
            foreach (var student in y)
            {
                student.ShowThongTin();
            }
            Console.ReadLine();
        }
    }
}
