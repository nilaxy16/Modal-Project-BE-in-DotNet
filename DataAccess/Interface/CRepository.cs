using DataAccess.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface CRepository
    {
        public IEnumerable<Course> GetAll();
        public Task<Course> Create(Course _object);
        public IEnumerable<Course> GetCourByDeptId(string Id);
        
    }
}
