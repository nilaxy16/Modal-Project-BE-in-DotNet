using DataAccess.Model;
using LogicalLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace Modal_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public readonly DService<Department> _service;

        public DepartmentController(DService<Department> service)
        {
            _service = service;
        }

        [HttpGet(Name = "Department")]
        public IEnumerable<Department> Get()
        {
            return _service.GetAllDepartment().ToList();

        }

        //[HttpGet]
        //[Route("{id}")]
        //public async Task<IActionResult> GetDeptStudent([FromRoute] string id)
        //{
        //var students = dbContext.students.Where(x => x.DeptId == id).ToList();
        //  return Ok(students);
        //}

        [HttpGet]
        [Route("{DeptId}")]
        public IEnumerable GetDeptID([FromRoute] string DeptId)
        {
            return _service.GetDeptIdRequest(DeptId);
        }

        [HttpGet()]
        [Route("GetDepartmentsName")]
        public IEnumerable GetDepartmentsName()
        {
            //return Ok(dbContext.students.Select(s => s.DeptId).Distinct().ToList());
            return _service.GetDeptNameRequest();
        }

        [HttpGet()]
        [Route("{DeptId}GetCourseName")]
        public IEnumerable GetCourseName()
        {
            //return Ok(dbContext.students.Select(s => s.DeptId).Distinct().ToList());
            return _service.GetCourseNameRequest();
        }

    }
}

