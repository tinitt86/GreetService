using GreetService.Contract;
using GreetService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GreetService.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("user/{id}")]
        public IActionResult Index(int id)
        {
            var defaultMsg = "Hello, World!";
            if (id > 0)
            {
                
                User user = _userService.GetUser(id);
                if (user != null)
                    return Content(string.Format("Hello, {0} {1}", user.FirstName, user.LastName));
                else
                    return Content(defaultMsg);
            }
            else
            {
                return Content(defaultMsg);
            }
        }

    }
}
