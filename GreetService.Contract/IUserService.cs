using GreetService.Domain;

namespace GreetService.Contract
{
    public interface IUserService
    {
        User GetUser(int id);
    }
}