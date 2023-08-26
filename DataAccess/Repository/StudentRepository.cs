using AutoMapper;
using DataAccess.Data;
using DataAccess.Interface;
using DataAccess.Model;

using Microsoft.AspNetCore.Mvc.Infrastructure;
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
    public class StudentRepository: IRepository
    {
        private readonly StudentAPIDbContext _contactDbContext;
        private readonly ILogger _logger;

        public StudentRepository(ILogger<Student> logger, StudentAPIDbContext contactDbContext)
        {
            _logger = logger;
            _contactDbContext = contactDbContext;
        }

        public IEnumerable<Student> GetAll()
        {
            try
            {
                var obj = _contactDbContext.Students.Include(s => s.Department).ToList();
                if (obj != null) return obj;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Student> Create(Student student)
        {
            try
            {
                if (student != null)
                {
                    var obj = _contactDbContext.Add<Student>(student);
                    await _contactDbContext.SaveChangesAsync();
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

        public Student GetById(string id)
        {
            try
            {
                if (id != null)
                {
                    var Obj = _contactDbContext.Students.Include(s => s.Department).FirstOrDefault(x => x.StudentId == id);
                    if (Obj != null) return Obj; 
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


        public void Update(Student student)
        {
            try
            {
                if (student != null)
                {
                    var obj = _contactDbContext.Update(student);
                    if (obj != null) _contactDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Student student)
        {
            try
            {
                if (_contactDbContext != null)
                {
                    var obj = _contactDbContext.Remove(student);
                    if (obj != null)
                    {
                        _contactDbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
