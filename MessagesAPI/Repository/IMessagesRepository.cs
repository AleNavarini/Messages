using Models;

namespace MessagesAPI.Repository
{
    public interface IMessagesRepository
    {
        Task<Message> CreateMessage(Message message);
        Task<List<Message>> GetMessages();
    }
}