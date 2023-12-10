namespace HealthComplex.WebApi.Apis;

public static class UsersApi
{
    public static RouteGroupBuilder MapUsersApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", );
        group.MapGet("/{id}",);
        group.MapPost("/",);
        group.MapPut("/{id}",);
        group.MapDelete("/{id}",);

        return group;
    }

    private Task<IResult> GetAllUsers(IUsersRepository usersRepository)
    {

    }
}