using GreetService.Contract;
using GreetService.Domain;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace GreetService.Service
{
    public class UserService : IUserService
    {
        private readonly IHostEnvironment _hostingEnvironment;
        public UserService(IHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public User GetUser(int id)
        {
            var rootPath = _hostingEnvironment.ContentRootPath;
            var fullPath = Path.Combine(rootPath, "Data/Users.json");
            var jsonData = File.ReadAllText(fullPath);
            if (string.IsNullOrWhiteSpace(jsonData))
                return null;

            var users = JsonConvert.DeserializeObject<List<User>>(jsonData);

            if (users == null || users.Count == 0)
                return null;

            var user = users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return null;

            return user;
        }
    }
}