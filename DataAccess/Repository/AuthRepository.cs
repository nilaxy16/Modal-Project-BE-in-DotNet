using DataAccess.Data;
using DataAccess.Helpers;
using DataAccess.Interface;
using DataAccess.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AuthRepository : ARepository
    {
        private readonly StudentAPIDbContext _DbContext;

        public AuthRepository(StudentAPIDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public async Task<User> Login(User userObj)
        {
            var user = await _DbContext.Users.FirstOrDefaultAsync(x => x.UserName == userObj.UserName);
            return user;  
        }

        public async Task<User> Signup(User userObj)
        {
            var obj = _DbContext.Add<User>(userObj);
            await _DbContext.SaveChangesAsync();
            return obj.Entity;

            //return Ok(new { Message = "User Registered!" });
        }

        public async Task<bool> CheckUserNameExistAsync(string username)
        {
            return await _DbContext.Users.AnyAsync(x => x.UserName == username);
        }

        public async Task<bool> CheckEmailExistAsync(string email)
        {
            return await _DbContext.Users.AnyAsync(x => x.Email == email);
        }

        public string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder();
            if (password.Length < 8)
                sb.Append("Minimum password length should be 8" + Environment.NewLine);
            if (!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]") && Regex.IsMatch(password, "[0-9]")))
                sb.Append("Password should be Alphanumeric" + Environment.NewLine);
            if (!Regex.IsMatch(password, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,\\[,\\],{,},?,:,;,|,',\\,.,/,~,`]"))
                sb.Append("Password should contain special chars" + Environment.NewLine);

            return sb.ToString();
        }

        public List<User> GetAll()
        {
            try
            {
                var obj = _DbContext.Users.ToList();
                if (obj != null) return obj;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}















