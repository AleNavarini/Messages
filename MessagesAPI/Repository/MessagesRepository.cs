using Microsoft.EntityFrameworkCore;
using Models;

namespace MessagesAPI.Repository
{
    public class MessagesRepository : IMessagesRepository
    {
        private readonly ApplicationContext _context;

        public MessagesRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Message>> GetMessages() => await _context.Messages.ToListAsync();

        public async Task<Message> CreateMessage(Message message)
        {
            if (message.CreatedAt is null) message.CreatedAt = DateTime.Now;
            var entityEntry = await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }
    }
}
