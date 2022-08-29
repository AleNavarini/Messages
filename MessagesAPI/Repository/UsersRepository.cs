using Models;

namespace MessagesAPI.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationContext _context;

        public UsersRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            List<User> users = new List<User>()
            {
                new User("user1", "user1"),
                new User("user2", "user2"),
            };
            await _context.AddRangeAsync(users);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Login(string username, string password)
        {
            if (!_context.Users.Any()) await SeedAsync();

            var user = _context.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (user is null) return false;
            return true;

        }
    }
}
