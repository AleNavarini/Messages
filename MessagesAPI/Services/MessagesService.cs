using MessagesAPI.Repository;
using Models;

namespace MessagesAPI.Services
{
    public class MessagesService : IMessagesService
    {
        private IMessagesRepository _repository;

        public MessagesService(IMessagesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Message>> GetMessages() => await _repository.GetMessages();

        public async Task<Message> InsertMessage(Message message) => await _repository.CreateMessage(message);
    }
}
