

namespace PhoneBook.Models
{
    public interface IContact
    {
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int PhoneNumber { get; set; }
    }

    public class Contact : IContact
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public object FullName { get; internal set; }
    }
}
