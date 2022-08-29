namespace MessagesAPI.Services
{
    public interface IUserService
    {
        Task<bool> Login(string username, string password);
    }
}