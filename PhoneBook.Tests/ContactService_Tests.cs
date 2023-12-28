using PhoneBook.Models;
using PhoneBook.Services;
using PhoneBook;
using PhoneBook.Tests;

namespace PhoneBook.Tests;

public class ContactService_Tests
{
    [Fact]

    public void AddContactToList_Should_Add_OneContactToList_ReturnTrue()
    {
        IContact Contact = new Contact { FirstName = "Dolly", LastName = "Pardon", Email = "dolly@pardon.com" };

        IContactService contactService = new ContactService();

        bool result = contactService.AddContactToList(Contact);

        Assert.True(result);


    }
}
