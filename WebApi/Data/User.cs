namespace HealthComplex.WebApi.Data;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int Age { get; set; }
}