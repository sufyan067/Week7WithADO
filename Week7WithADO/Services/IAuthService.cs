namespace Week7WithADO.Services
{
    public interface IAuthService
    {
        Task<string?> Login(string username, string password);
    }
}
