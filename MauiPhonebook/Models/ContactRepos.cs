using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _contacts.FirstOrDefault(x => x.ContactId == contactId);
        }


    }
}
