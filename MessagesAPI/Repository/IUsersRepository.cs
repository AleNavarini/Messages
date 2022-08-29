namespace MessagesAPI.Repository
{
    public interface IUsersRepository
    {
        Task<bool> Login(string username, string password);
        Task SeedAsync();
    }
}