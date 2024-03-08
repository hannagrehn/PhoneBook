
namespace MauiPhonebook.Models
{
    public static class ContactRepos
    {
        public static List<Contact> _contacts = new List<Contact>()
        {
            new Contact { ContactId= 1, FirstName = "Sam", LastName = "Win", Email = "sam@sam.com" },
            new Contact { ContactId= 2, FirstName = "Hank", LastName = "Spanks", Email = "hanks@hans.com" },
            new Contact { ContactId= 3, FirstName = "Mank", LastName = "Moms", Email = "mank@toms.se" },
            new Contact { ContactId= 4, FirstName = "Frida", LastName = "Nos", Email = "frids@noms.se" },
            new Contact { ContactId= 5, FirstName = "Maya", LastName = "Mos", Email = "mayya@oms.se" }
        };

        public static List<Contact> GetContacts() => _contacts;

        public static Contact GetContactById(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null)
            {
                return new Contact
                {
                    ContactId = contactId,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    Address = contact.Address,
                    
                };
            }
            return null;
        }

        public static void UpdateContact(int contactId, Contact contact)
        {
            if (contactId != contact.ContactId) return;

            var contactToUpdate = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contactToUpdate != null)
            {
                contactToUpdate.FirstName = contact.FirstName;
                contactToUpdate.LastName = contact.LastName;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Phone = contact.Phone;
                contactToUpdate.Address = contact.Address;
            }
        }

        public static void AddContact(Contact contact)
        {
            var maxId = _contacts.Max(x => x.ContactId);
            contact.ContactId = maxId + 1;
            _contacts.Add(contact);

        }
    }
}


