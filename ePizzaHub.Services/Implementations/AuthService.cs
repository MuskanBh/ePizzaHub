﻿using ePizzaHub.Core.Entities;
using ePizzaHub.Models;
using ePizzaHub.Repositories.Interfaces;
using ePizzaHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Services.Implementations
{
    internal class AuthService : Service<User>, IAuthService
    {
        IUserRepository _userRepo;
        public AuthService(IUserRepository userRepo) : base(userRepo)
        {
            _userRepo= userRepo;
        }
        public bool CreateUser(User user, string Role)
        {
            return _userRepo.CreateUser(user, Role);
        }

        public UserModel ValidateUser(string Email, string Password)
        {
            return _userRepo.ValidateUser(Email, Password);
        }
    }
}
