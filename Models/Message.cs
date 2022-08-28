namespace Models
{
    public class Message
    {
        public Message(string content, string author, DateTime createdAt)
        {
            Content = content;
            Author = author;
            CreatedAt = createdAt;
        }

        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
