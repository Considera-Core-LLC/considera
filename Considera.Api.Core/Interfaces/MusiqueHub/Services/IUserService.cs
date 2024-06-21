using Considera.Api.Core.Models.MusiqueHub;

namespace Considera.Api.Core.Interfaces.MusiqueHub.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<bool> HasUser(string username);
    Task<UserProtected> HasUser(string username, string password);
    Task<UserProtected> AddUser(string username, string password);
    Task<User?> AddUser(User user);
}
