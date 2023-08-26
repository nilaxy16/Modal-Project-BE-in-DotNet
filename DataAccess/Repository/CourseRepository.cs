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
    public class CourseRepository: CRepository
    {
        private readonly StudentAPIDbContext _DbContext;
        private readonly ILogger _logger;

        public CourseRepository(ILogger<Student> logger, StudentAPIDbContext DbContext)
        {
            _logger = logger;
            _DbContext = DbContext;
        }

        public IEnumerable<Course> GetAll()
        {
            try
            {
                var obj = _DbContext.Courses.Include(s => s.Department).ToList();
                if (obj != null) return obj;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Course> Create(Course course)
        {
            try
            {
                if (course != null)
                {
                    var obj = _DbContext.Add<Course>(course);
                    await _DbContext.SaveChangesAsync();
                    return obj.Entity;
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
        
        public IEnumerable<Course> GetCourByDeptId(string DeptId)
        {
            try
            {
                if (DeptId != null)
                {
                    var obj = _DbContext.Courses.Include(s => s.Department).Where(data => data.Department.DeptId == DeptId).ToList();
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
    }
}
