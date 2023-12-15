using System;
using System.Collections.Generic;
using PhoneMaui.Models;


namespace PhoneMaui.Services
{
    public interface IPhonebookService
    {
        void AddContact(Models.Contact contact);
        void RemoveContact(Models.Contact contact);
        void UpdateContact(Models.Contact contact);
        
    }

    public class PhonebookService : IPhonebookService
    {
        private List<Models.Contact> contacts = new List<Models.Contact>();

        public void AddContact(Models.Contact contact)
        {
            contacts.Add(contact);
        }

       

        public void ShowAllContacts()
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.FirstName} {contact.LastName}, {contact.PhoneNumber} <{contact.Email}>");
            }
        }

        public void AddContact()
        {

        }


        public void RemoveContact(Models.Contact contact)
        {
            contacts.Remove(contact);
        }

        public void SearchForContact()
        {
            Console.ReadLine();
        }

        public void UpdateContact(Models.Contact contact)
        {
            Console.ReadLine();
        }
    }
}
