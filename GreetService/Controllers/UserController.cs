using GreetService.Contract;
using GreetService.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace GreetService.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private string _defaultMsg = "Hello, World!";

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return Content(_defaultMsg);
        }

        [Route("user/{id}")]
        public IActionResult Index(int id)
        {
            
            if (id > 0)
            {                
                User user = _userService.GetUser(id);
                if (user != null)
                {
                    int index = new Random().Next(user.Alias.Count);                    
                    return Content(string.Format("Hello, {0}", user.Alias[index])); 
                }
                else
                    return Content(_defaultMsg);
            }
            else
            {
                return Content(_defaultMsg);
            }
        }

    }
}
