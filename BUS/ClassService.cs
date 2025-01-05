using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BUS
{
    public class ClassService
    {
        public  List<Lop> GetAll()
        {
            Model1 model  = new Model1();
            return model.Lop.ToList();
        }
           
    }
}
