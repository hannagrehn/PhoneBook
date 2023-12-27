namespace PhoneBook.Tests
{
    public class ContactService_Tests
    {
        [Fact]

        public AddContactToList_Should_Add_OneContactToList_ReturnTrue()
        {
            IContact Contact = new ContactService_Tests { FirstName = "Dolly", LastName = "Pardon" };
            IContactService contactService = new ContactService_Tests();

            bool result = contactService.AddContactToList(Contact);

            Assert.True(result);


        }
    }
}