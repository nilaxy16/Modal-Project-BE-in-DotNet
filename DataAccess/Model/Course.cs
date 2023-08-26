using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Course
    {
        [Key] public string? CourseId { get; set; }
        public string? CourseName { get; set; }
        [ForeignKey("Department")] public string DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
