
namespace HealthComplex.WebApi.Data;

public class UserRepository : IUserRepository
{
    UserDb _userDb;
    public UserRepository(UserDb userDb)
    {
        _userDb = userDb;
    }
    public async Task<List<User>> GetUsersAsync()
    {
        return await _userDb.Users.ToListAsync();
    }

    public async Task<User> GetUserAsync(int userId)
    {
        return await _userDb.Users.FindAsync([userId]);
    }

    public async Task DeleteUserAsync(int userId)
    {
        User userFromDb = await _userDb.Users.FindAsync([userId]);
        if (userFromDb == null) return;
        _userDb.Users.Remove(userFromDb);
    }

    public async Task InsertUserAsync(User user)
    {
        await _userDb.Users.AddAsync(user);
    }

    public async Task UpdateUserAsync(User user)
    {
        throw new NotImplementedException();
    }
    public async Task SaveAsync()
    {
        await _userDb.SaveChangesAsync();
    }

    private bool _disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _userDb.Dispose();
            }
        }
        _disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}