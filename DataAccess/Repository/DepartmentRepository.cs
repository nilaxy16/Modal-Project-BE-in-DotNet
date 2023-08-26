using DataAccess.Data;
using DataAccess.Interface;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class DepartmentRepository: DRepository<Department>
    {
        private readonly StudentAPIDbContext _DbContext;
        private readonly ILogger _logger;
        public DepartmentRepository(ILogger<Student> logger, StudentAPIDbContext DbContext)
        {
            _logger = logger;
            _DbContext = DbContext;
        }

        public IEnumerable<Department> GetAllDept()
        {
            try
            {
                var obj = _DbContext.Departments.Include(data => data.Students).Include(s => s.Courses).ToList();
                if (obj != null) return (obj);

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable GetByDeptId(string DeptId)
        {
            try
            {
                if (DeptId != null)
                {
                    var obj = _DbContext.Students.Where(data => data.Department.DeptId == DeptId).Select(stud => new { stud.StudentId, stud.FullName, stud.Mobile, stud.Department.DeptName });
                    if (obj != null) return obj;
                    else return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable GetByDeptName()
        {
            try
            {
                var departments = _DbContext.Departments.Select(s => s.DeptId).Distinct().ToList();
        
                 if (departments != null) return departments;
                 else return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public IEnumerable GetByCourseName()
        {
            try
            {
                var departments = _DbContext.Departments.Select(s => s.DeptId).Distinct().ToList();

                if (departments != null) return departments;
                else return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
