using DataAccess.Model;
using DataAccess.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IRepository 
    {        
        public IEnumerable<Student> GetAll();
        public Task<Student> Create(Student _object);
        public Student GetById(string Id);
        public void Update(Student _object);
        public void Delete(Student _object);
    }
}
