using ConsideraDevApi.Core.Interfaces.MusiqueHub;
using ConsideraDevApi.Core.Interfaces.MusiqueHub.Services;
using ConsideraDevApi.Core.Models.MusiqueHub;

namespace ConsideraDevApi.Infrastructure.Services.MusiqueHub;

public class UserService : IUserService
{
    private readonly IUsersRepository _usersRepository;

    public UserService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<IEnumerable<User>> GetAllUsers() => 
        await _usersRepository.GetAll();
    
    public async Task<bool> HasUser(string username) => 
        await _usersRepository.HasUser(username);
    
    public async Task<UserProtected> HasUser(string username, string password)
    {
        var result = await _usersRepository.HasUser(username, password);
        return result == null ? new UserProtected(false) : new UserProtected
        {
            Id = result.Id,
            Username = result.Username,
            IsLoggedIn = true
        };
    }

    public async Task<UserProtected> AddUser(string username, string password)
    {
        var result = await _usersRepository.AddUser(username, password);
        Console.WriteLine(result);
        return result == null ? new UserProtected() : new UserProtected
        {
            Id = result.Id,
            Username = result.Username,
            IsLoggedIn = true
        };
    }

    public async Task<User?> AddUser(User user) =>
        await _usersRepository.Add(user);
}
