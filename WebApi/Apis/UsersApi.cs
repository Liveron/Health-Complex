using Microsoft.AspNetCore.Mvc;

namespace HealthComplex.WebApi.Apis;

public static class UsersApi
{
    public static RouteGroupBuilder MapUsersApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetAllUsers);
        group.MapGet("/{id}", GetUser);
        group.MapPost("/", InsertUser);
        group.MapPut("/{id}", UpdateUser);
        group.MapDelete("/{id}", DeleteUser);

        return group;
    }

    private static async Task<IResult> GetAllUsers(IUserRepository userRepository)
    {
        return Results.Ok(await userRepository.GetUsersAsync());
    }

    private static async Task<IResult> GetUser(int id, IUserRepository userRepository)
    {
        return Results.Ok(await userRepository.GetUserAsync(id));
    }

    private static async Task<IResult> InsertUser([FromBody] User user, IUserRepository userRepository)
    {
        await userRepository.InsertUserAsync(user);
        await userRepository.SaveAsync();
        return Results.Created($"/users/{user.Id}", user);
    }

    private static async Task<IResult> UpdateUser([FromBody] User user, IUserRepository userRepository)
    {
        await userRepository.UpdateUserAsync(user);
        await userRepository.SaveAsync();
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteUser(int id, IUserRepository userRepository)
    {
        await userRepository.DeleteUserAsync(id);
        await userRepository.SaveAsync();
        return Results.NoContent();
    }
}