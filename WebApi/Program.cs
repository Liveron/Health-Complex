var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserDb>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Pgsql"));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // using var scope = app.Services.CreateScope();
    // var db = scope.ServiceProvider.GetRequiredService<UserDb>();
    // db.Database.EnsureCreated();
}

app.MapGroup("/users")
    .MapUsersApi()
    .WithTags("Users");

app.UseHttpsRedirection();

app.Run();
