using DataAccess.Model;
using LogicalLayer.Response;
using LogicalLayer.ResponseModal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalLayer
{
    public interface CService
    {
        public List<CourseResponse> GetAllRequest();
        public Task<Course> AddRequest(CourseResponse _object);
        public List<CourseResponse> GetCourseIdRequest(string DeptId);
    }
}
