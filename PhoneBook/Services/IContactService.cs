using PhoneBook.Models;

namespace PhoneBook.Services
{
    public interface IContactService
    {
        bool AddContactToList(IContact contact);

        IEnumerable<Contact> GetAllContactsFromList();

        IEnumerable<IContact> GetAllFromList();
    }
}