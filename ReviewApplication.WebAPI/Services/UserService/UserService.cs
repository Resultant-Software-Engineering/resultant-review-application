using ReviewApplication.WebAPI.Models;

namespace ReviewApplication.WebAPI.Services.UserService;

public class UserService(ApiDbContext context) : IUserService
{
    private ApiDbContext Context => context;
    
    public User AddUser(User user)
    {
        Context.Add(user);
        Context.SaveChanges();
        return user;
    }

    public User? GetUser(string username, string password)
    {
        return Context.Users
            .FirstOrDefault(x => x.Username == username && x.Password == password);
    }
}