using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
