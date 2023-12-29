using PhoneBook.Models;
using PhoneBook.Services;
using PhoneBook;

namespace PhoneBook.Services
{
    public interface IContactService
    {
        bool AddContactToList(IContact contact);

        IEnumerable<Contact> GetAllContactsFromList();

        IEnumerable<IContact> GetAllFromList();
    }
}