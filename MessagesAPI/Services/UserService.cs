using MessagesAPI.Repository;

namespace MessagesAPI.Services
{
    public class UserService : IUserService
    {
        private IUsersRepository _repository;

        public UserService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Login(string username, string password) => await _repository.Login(username, password);
    }
}
