using Week7WithADO.Entities;
namespace Week7WithADO.Repositories
{
    public interface IAuthRepository
    {
        Task<User?> GetUserByCredentials(string username, string password);

    }
}
