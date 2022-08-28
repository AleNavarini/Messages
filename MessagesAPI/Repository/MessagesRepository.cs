using Microsoft.EntityFrameworkCore;
using Models;

namespace MessagesAPI.Repository
{
    public class MessagesRepository
    {
        private readonly MessagesContext _context;

        public MessagesRepository(MessagesContext context)
        {
            _context = context;
        }

        public async Task<List<Message>> GetMessages() => await _context.Messages.ToListAsync();
    }
}
