namespace WindowsFormsApp10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class VMNguoiDung
    {
       
        public string StudentID { get; set; }

   
        public string FullName { get; set; }


        public double AverageScore { get; set; }


        public string  FacultyName { get; set; }
    }
}
