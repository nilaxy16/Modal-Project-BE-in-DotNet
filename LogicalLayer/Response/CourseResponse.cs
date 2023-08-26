using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalLayer.Response
{
    public class CourseResponse
    {
        public string? CourseId { get; set; }
        public string? CourseName { get; set; }
        public string DeptId { get; set; }
        public string DeptName { get; set; }
    }
}
