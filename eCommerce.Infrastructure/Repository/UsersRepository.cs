using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContract;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repository;
internal class UsersRepository : IUsersRepository
{
    private readonly DapperDbContext _dapperDbContext;

    public UsersRepository(DapperDbContext dapperDbContext)
    {
        _dapperDbContext = dapperDbContext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser applicationUser)
    {
        applicationUser.UserId = Guid.NewGuid();

        string query = "INSERT INTO public.\"Users\" (\"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES (@UserID, @Email, @PersonName, @Gender, @Password);";
        int rowCountAffected=  await _dapperDbContext.dbConnection.ExecuteAsync(query, applicationUser);
        if (rowCountAffected > 0) 
        {
            return applicationUser;
        }
        else
        {
            return null;
        }
        
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        string query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";
        var parameter = new { Email = email, Password = password };
        ApplicationUser? Data = await _dapperDbContext.dbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameter);

        return Data;
    }
}

