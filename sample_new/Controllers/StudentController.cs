using Microsoft.AspNetCore.Mvc;
using DataAccess.Data;
using DataAccess.Interface;
using DataAccess.Model;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using LogicalLayer;
using System.Collections;
using LogicalLayer.ResponseModal;

namespace Modal_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController: ControllerBase
    {
        public readonly IService _service;

        public StudentController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<StudentResponse> Get()
        {
            return _service.GetAllRequest().ToList();
        }

        [HttpPost]
        public async Task<Student> Add(StudentResponse addStudentRequest)
        {

            return await _service.AddRequest(addStudentRequest);
        }

        [HttpGet]
        [Route("{StudentId}")]
        public async Task<StudentResponse> GetID([FromRoute] string StudentId)
        {
            return _service.GetIdRequest(StudentId);
        }

        [HttpPut]
        [Route("{StudentId}")]
        public void Update([FromRoute] string StudentId, StudentResponse updateStudentRequest)
        {
            _service.UpdateRequest(StudentId, updateStudentRequest);
        }

        [HttpDelete]
        [Route("{StudentId}")]
        public async void Delete([FromRoute] string StudentId)
        {
            _service.DeleteRequest(StudentId);
        }
    }
}
