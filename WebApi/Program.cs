var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UserDb>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Pgsql"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<UserDb>();
    db.Database.EnsureCreated();
}

app.MapGroup("/users")
    .MapUsersApi();

app.Run();
