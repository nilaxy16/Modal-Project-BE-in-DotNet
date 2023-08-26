using DataAccess.Interface;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalLayer
{
    public class DepartmentService: DService<Department>
    {
        public readonly DRepository<Department> _repository;

        public DepartmentService(DRepository<Department> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Department> GetAllDepartment()
        {
            return _repository.GetAllDept().ToList(); 
        }

        public IEnumerable GetDeptIdRequest(string DeptId)
        {
            return _repository.GetByDeptId(DeptId);
        }

        public IEnumerable GetDeptNameRequest()
        {
            return _repository.GetByDeptName();
        }

        public IEnumerable GetCourseNameRequest()
        {
            return _repository.GetByCourseName();
        }
    }
}
