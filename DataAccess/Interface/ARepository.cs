using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface ARepository
    {
        public Task<User> Login(User userObj);
        public Task<User> Signup(User userObj);
        public Task<bool> CheckUserNameExistAsync(string username);
        public Task<bool> CheckEmailExistAsync(string email);
        public string CheckPasswordStrength(string password);
        public List<User> GetAll();

    }
}
