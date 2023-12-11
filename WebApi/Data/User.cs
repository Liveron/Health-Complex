namespace HealthComplex.WebApi.Data;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}