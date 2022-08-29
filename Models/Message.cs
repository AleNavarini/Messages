using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Message
    {
        public Message(string content, string author, DateTime? createdAt)
        {
            Content = content;
            Author = author;
            CreatedAt = createdAt;
        }

        [Key]
        public string Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
