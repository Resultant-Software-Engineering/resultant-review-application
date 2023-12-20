using ReviewApplication.WebAPI.Models;

namespace ReviewApplication.WebAPI.Services.UserService;

public interface IUserService
{
    User AddUser(User user);
    User? GetUser(string username, string password);
}