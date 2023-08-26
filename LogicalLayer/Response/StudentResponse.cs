using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalLayer.ResponseModal
{
    public class StudentResponse
    {
        public string? StudentId { get; set; }
        public string? FullName { get; set; }
        public int Mobile { get; set; }
        public string Course { get; set; }
        public string DeptId { get; set; }
        public string DeptName { get; set; }
    }
}
