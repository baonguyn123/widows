using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BUS
{
    public class StudentService
    {  // lay sinh vien
        private readonly LopRepository lopRepository;
        //public List<Sinhvien> GetAll()
        //{
        //    Model1 model = new Model1();
        //    return model.Sinhviens.ToList();
        //}
        private readonly Model1 context;
        public StudentService()
        {
            lopRepository = new LopRepository();
        }

        public List<SinhVien> GetAll()
        {
            return lopRepository.GetAll().ToList();
        }

        public void Add(SinhVien student)
        {
            lopRepository.Add(student);
        }

        public void Update(SinhVien student)
        {
            lopRepository.Update(student);
        }

        public void Delete(string studentId)
        {
            lopRepository.Delete(studentId);
        }
        public List<Lop> GetAllClasses()
        {
            return lopRepository.GetAllClasses();
        }

        public List<SinhVien> SearchStudents(string keyword)
        {
            return lopRepository.SearchStudents(keyword);
        }
    } }

