using PhoneBook.Models;
using PhoneBook.Services;

namespace PhoneBook.Tests;

public class ContactService_Tests
{
    [Fact]

    public void AddContactToList_Should_Add_OneContactToList_ReturnTrue()
    {
        IContact contact = new Contact { FirstName = "Dolly", LastName = "Pardon", Email = "dolly@pardon.com" };
        IContactService contactService = new ContactService();

        bool result = contactService.AddContactToList(contact);

        Assert.True(result);
    }

    [Fact]

    public void GetAllContactsFromListShould_GetAllContactsInContactList_ReturnListOfContacts()
    {
        IContactService contactService = new ContactService();
        IContact contact = new Contact { FirstName = "Dolly", LastName = "Pardon", Email = "dolly@pardon.com" };
        contactService.AddContactToList(contact);

        IEnumerable<IContact> result = contactService.GetAllContactsFromList();

        Assert.NotNull(result);  
        Assert.True(((IEnumerable<Contact>)result).Any());
    }
}
