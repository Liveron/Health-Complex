public class UserDb : DbContext
{
    public UserDb(DbContextOptions<UserDb> options) : base(options) { }
    public DbSet<User> Users => Set<User>();
    public DbSet<UserCredentials> UserCredentials => Set<UserCredentials>();
}