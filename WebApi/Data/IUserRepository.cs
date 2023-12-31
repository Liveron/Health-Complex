namespace HealthComplex.WebApi.Data;

public interface IUserRepository : IDisposable
{
    Task<List<User>> GetUsersAsync();
    Task<User> GetUserAsync(int userId);
    Task InsertUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int userId);
    Task SaveAsync();
}