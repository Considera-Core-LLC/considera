using ConsideraDevApi.Core.Models.MusiqueHub;

namespace ConsideraDevApi.Core.Interfaces.MusiqueHub;

public interface IUsersRepository : IRepository<User>
{
    Task<bool> HasUser(string username);
    Task<User?> HasUser(string username, string password);
    Task<User?> AddUser(string username, string password);
}