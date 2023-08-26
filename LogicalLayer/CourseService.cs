using AutoMapper;
using DataAccess.Interface;
using LogicalLayer.Response;
using DataAccess.Model;
using LogicalLayer.ResponseModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LogicalLayer
{
    public class CourseService: CService
    {
        public readonly CRepository _repository;
        private readonly IMapper _mapper;

        public CourseService(CRepository repository)
        {
            _repository = repository;
        }

        public List<CourseResponse> GetAllRequest()
        {
            var courses = _repository.GetAll().ToList();
            List<CourseResponse> newcourses = new List<CourseResponse>();

            if (courses != null)
            {
                foreach (var cour in courses)
                {
                    var courseRes = new CourseResponse();
                    courseRes.CourseId = cour.CourseId;
                    courseRes.CourseName = cour.CourseName;
                    courseRes.DeptId = cour.DepartmentId;
                    courseRes.DeptName = cour.Department.DeptName;
                    newcourses.Add(courseRes);
                }
            }

            return newcourses;                        
        }

        public async Task<Course> AddRequest(CourseResponse addCourseRequest)
        {
            Course newcourse = new Course();
            newcourse.CourseId = addCourseRequest.CourseId;
            newcourse.CourseName = addCourseRequest.CourseName;
            newcourse.DepartmentId = addCourseRequest.DeptId;
            return await _repository.Create(newcourse);
        }

        public List<CourseResponse> GetCourseIdRequest(string DeptId)
        {
            var courses = _repository.GetCourByDeptId(DeptId);
            List<CourseResponse> newcourses = new List<CourseResponse>();

            if (courses != null)
            {
                foreach (var cour in courses)
                {
                    var courseRes = new CourseResponse();
                    courseRes.CourseId = cour.CourseId;
                    courseRes.CourseName = cour.CourseName;
                    courseRes.DeptId = cour.DepartmentId;
                    courseRes.DeptName = cour.Department.DeptName;
                    newcourses.Add(courseRes);
                }
            }

            return newcourses;
        }
    }
}
