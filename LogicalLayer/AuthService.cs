using AutoMapper;
using DataAccess.Interface;
using DataAccess.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalLayer
{
    public class AuthService : AService
    {
        public readonly ARepository _repository;

        public AuthService(ARepository repository)
        {
            _repository = repository;
        }
        public async Task<User> loginRequest(User userObj)
        {
            return await _repository.Login(userObj);
        }

        public async Task<bool> RequestCheckUserNameExistAsync(string username)
        {
            return await _repository.CheckUserNameExistAsync(username);
        }

        public async Task<bool> RequestCheckEmailExistAsync(string email)
        {
            return await _repository.CheckEmailExistAsync(email);
        }

        public string RequestCheckPasswordStrength(string password)
        {
            return _repository.CheckPasswordStrength(password);
        }

        public async Task<User> signupRequest(User userObj)
        {
            return await _repository.Signup(userObj);
        }

        public List<User> RequestGetAll()
        {
            return _repository.GetAll();
        }
    }
}
