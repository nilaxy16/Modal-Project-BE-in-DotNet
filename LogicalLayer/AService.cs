using DataAccess.Model;
using LogicalLayer.ResponseModal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalLayer
{
    public interface AService
    {
        public Task<User> loginRequest(User userObj);
        public Task<User> signupRequest(User userObj);

        public Task<bool> RequestCheckUserNameExistAsync(string username);
        public Task<bool> RequestCheckEmailExistAsync(string email);
        public string RequestCheckPasswordStrength(string password);
        public List<User> RequestGetAll();

    }
}
