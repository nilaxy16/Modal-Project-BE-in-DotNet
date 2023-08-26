using DataAccess.Data;
using DataAccess.Interface;
using DataAccess.Model;
using LogicalLayer.ResponseModal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace LogicalLayer
{
    public class StudentService: IService
    {
        public readonly IRepository _repository;
        private readonly IMapper _mapper;

        public StudentService(IRepository repository)
        {
            _repository = repository;
        }

        public List<StudentResponse> GetAllRequest()
        { 
            var students = _repository.GetAll().ToList();
            List<StudentResponse> newstudents = new List<StudentResponse>();

            if(students != null)
            {
                foreach (var stud in students)
                {
                    var studentRes = new StudentResponse();
                    studentRes.StudentId = stud.StudentId;
                    studentRes.FullName = stud.FullName;
                    studentRes.Mobile = stud.Mobile;
                    studentRes.Course = stud.Course;
                    studentRes.DeptId = stud.DepartmentId;
                    studentRes.DeptName = stud.Department.DeptName;
                    newstudents.Add(studentRes);
                }
            }
              
            return newstudents;
        }

        public async Task<Student> AddRequest(StudentResponse addStudentRequest)
        {
            Student newstudent = new Student();
            newstudent.StudentId = addStudentRequest.StudentId;
            newstudent.FullName = addStudentRequest.FullName;
            newstudent.Mobile = addStudentRequest.Mobile;
            newstudent.Course = addStudentRequest.Course;
            newstudent.DepartmentId = addStudentRequest.DeptId;
            return await _repository.Create(newstudent);
        }

        public StudentResponse GetIdRequest(string StudentId)
        {
            var obj = _repository.GetById(StudentId);
            StudentResponse newstudent = new StudentResponse();
            newstudent.StudentId = obj.StudentId;
            newstudent.FullName = obj.FullName;
            newstudent.Mobile = obj.Mobile;
            newstudent.DeptId = obj.DepartmentId;
            newstudent.DeptName = obj.Department.DeptName;
            return newstudent;
        }

        public void UpdateRequest(string StudentId, StudentResponse updateStudentRequest)
        {
            if (StudentId is not null)
            {
                Student obj = _repository.GetById(StudentId);
                obj.FullName = updateStudentRequest.FullName;
                obj.Mobile = updateStudentRequest.Mobile;
                obj.Course = updateStudentRequest.Course;
                obj.DepartmentId = updateStudentRequest.DeptId;
                obj.Department.DeptName = updateStudentRequest.DeptName;
                if (obj != null) _repository.Update(obj);
            }
        }

        public async void DeleteRequest(string StudentId)
        {
            var obj = _repository.GetById(StudentId);
            _repository.Delete(obj);
        }
    }
}
