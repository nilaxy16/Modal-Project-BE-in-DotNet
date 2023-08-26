using DataAccess.Model;
using DataAccess.Repository;
using LogicalLayer.ResponseModal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalLayer
{
    public interface IService
    {
        public List<StudentResponse> GetAllRequest();
        public Task<Student> AddRequest(StudentResponse _object);
        public StudentResponse GetIdRequest(string Id);
        public void UpdateRequest(string id, StudentResponse _object);
        public void DeleteRequest(string id);
    }
}
