using ConsideraDevApi.Core.Interfaces.MusiqueHub;
using ConsideraDevApi.Core.Models.MusiqueHub;
using Microsoft.EntityFrameworkCore;

namespace ConsideraDevApi.Infrastructure.Repositories.MusiqueHub;

public class UsersRepository : BaseRepository<User>, IUsersRepository
{
    public UsersRepository(DbContext context) : base(context) {}
    
    public async Task<bool> HasUser(string username) => 
        await Context.Set<User>().AnyAsync(u => u.Username == username);
    
    public async Task<User?> HasUser(string username, string password) => 
        await Context.Set<User>().FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

    public async Task<User?> AddUser(string username, string password)
    {
        Console.WriteLine("Adding user to database 2 ");
        if (await HasUser(username, password) != null) return null;
        
        Console.WriteLine("Adding user to database 3 ");
        var entity = (await Context.AddAsync(new User { Username = username, Password = password })).Entity;
        await Context.SaveChangesAsync();
        Console.WriteLine(entity);
        return entity;
    }
}