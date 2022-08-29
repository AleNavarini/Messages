using Models;

namespace MessagesAPI.Services
{
    public interface IMessagesService
    {
        Task<List<Message>> GetMessages();
        Task<Message> InsertMessage(Message message);
    }
}