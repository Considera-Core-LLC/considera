using Considera.Api.Core.Models.MusiqueHub;

namespace Considera.Api.Core.Interfaces.MusiqueHub;

public interface IUsersRepository : IRepository<User>
{
    Task<bool> HasUser(string username);
    Task<User?> HasUser(string username, string password);
    Task<User?> AddUser(string username, string password);
}