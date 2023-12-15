using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneMaui.Interfaces
{
    
    public interface IPhonebookService
    {
        void ShowAllContacts();
        void AddContact(Contact contact);
        void RemoveContact(Contact contact);
        void SearchForContact();
        void UpdateContact(Contact contact);
    }

}
