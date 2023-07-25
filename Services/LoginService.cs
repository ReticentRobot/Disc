﻿using Disc.Models;

namespace Disc.Services
{
    public class LoginService : ILoginService
    {
        IRestService _restService;

        public LoginService(IRestService service)
        {
            _restService = service;
        }

        public Task LoginAsync(LoginInfo login)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Login: " + login);
            return _restService.LoginAsync(login);
        }
    }
}