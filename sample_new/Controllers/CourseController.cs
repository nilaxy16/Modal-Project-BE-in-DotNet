using DataAccess.Model;
using LogicalLayer.ResponseModal;
using LogicalLayer;
using Microsoft.AspNetCore.Mvc;
using LogicalLayer.Response;

namespace Modal_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController: ControllerBase
    {
        public readonly CService _service;

        public CourseController(CService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<CourseResponse> Get()
        {
            return _service.GetAllRequest().ToList();
        }

        [HttpPost]
        public async Task<Course> Add(CourseResponse addCourseRequest)
        {

            return await _service.AddRequest(addCourseRequest);
        }

        [HttpGet]
        [Route("{DeptId}")]
        public List<CourseResponse> GetCourseID([FromRoute] string DeptId)
        {
            return _service.GetCourseIdRequest(DeptId);
        }
    }
}
