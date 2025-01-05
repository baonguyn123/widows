using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    public class LopRepository
    {
        private readonly Model1 db;

        public LopRepository()
        {
            db = new Model1();
        }

        public IQueryable<SinhVien> GetAll()
        {
            //return db.Sinhviens.Include(s => s.Lop);
            var students = db.SinhVien.Include(s => s.Lop).ToList();
            return db.SinhVien.Include(s => s.Lop);
        }

        public void Add(SinhVien student)
        {
            db.SinhVien.Add(student);
            db.SaveChanges();
        }

        public void Update(SinhVien student)
        {
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(string studentId)
        {
            var student = db.SinhVien.Find(studentId);
            if (student != null)
            {
                db.SinhVien.Remove(student);
                db.SaveChanges();
            }
        }
        public List<Lop> GetAllClasses()
        {
            return db.Lop.ToList();
        }
        public List<SinhVien> SearchStudents(string keyword)
        {
            // Tìm kiếm theo mã sinh viên hoặc tên sinh viên
            var result = db.SinhVien
                                 .Where(s => s.MaSV.Contains(keyword) || s.HoTenSV.Contains(keyword))
                                 .ToList();
            return result;
        }
    }
}
