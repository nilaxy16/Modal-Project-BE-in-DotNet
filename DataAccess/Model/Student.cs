using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Student
    {
        [Key] public string? StudentId { get; set; }
        public string? FullName { get; set; }
        public int Mobile { get; set; }
        public string Course { get; set; }
        [ForeignKey("Department")] public string DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        /* [ForeignKey("Course")] public string CourId { get; set; }
        public virtual Course Course { get; set; } */
    }
}
