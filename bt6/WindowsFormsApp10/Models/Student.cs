namespace WindowsFormsApp10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string StudentID { get; set; }

        [StringLength(200)]
        public string FullName { get; set; }

      
        public double AverageScore { get; set; }

        [ForeignKey("Faculty")]
        public int FacultyID { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
