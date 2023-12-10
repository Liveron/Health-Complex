
namespace HealthComplex.WebApi.Data;

public class UserRepository : IUserRepository
{
    public Task<List<User>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task InsertUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUserAsync(User user)
    {
        throw new NotImplementedException();
    }
    public Task SaveAsync()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}