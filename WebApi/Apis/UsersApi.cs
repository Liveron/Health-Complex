using Microsoft.AspNetCore.Mvc;

namespace HealthComplex.WebApi.Apis;

public static class UsersApi
{
    public static RouteGroupBuilder MapUsersApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetAllUsers)
            .Produces<List<User>>(StatusCodes.Status200OK)
            .WithName("GetAllUsers");

        group.MapGet("/{id}", GetUser)
            .Produces<User>(StatusCodes.Status200OK)
            .WithName("GetUser");

        group.MapPost("/", InsertUser)
            .Accepts<User>("application/json")
            .Produces<User>(StatusCodes.Status201Created)
            .WithName("CreateUser");

        group.MapPut("/{id}", UpdateUser)
            .Accepts<User>("application/json")
            .WithName("UpdateUser")
            .Produces(StatusCodes.Status204NoContent);

        group.MapDelete("/{id}", DeleteUser)
            .WithName("DeleteUser")
            .Produces(StatusCodes.Status204NoContent);

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