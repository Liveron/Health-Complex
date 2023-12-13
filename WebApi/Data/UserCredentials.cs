namespace HealthComplex.WebApi.Data;

public class UserCredentials
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
}