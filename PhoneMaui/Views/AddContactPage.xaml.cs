using Microsoft.Maui.Controls;
using PhoneMaui.Models;
using PhoneMaui.Services;
using System;

namespace PhoneMaui
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddContactPage : ContentPage
    {
        private readonly IPhonebookService phonebookService;

        // Primary constructor that takes IPhonebookService
        public AddContactPage(IPhonebookService phonebookService)
        {
            InitializeComponent();
            this.phonebookService = phonebookService;
        }

        // Secondary constructor for IPhonebookService1 (if needed)
        public AddContactPage(Interfaces.IPhonebookService phonebookService1) : this((IPhonebookService)null)
        {
            this.phonebookService = (IPhonebookService)phonebookService1;
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            // Retrieve values from entries and create a new contact
            string firstName = firstNameEntry.Text;
            string lastName = lastNameEntry.Text;
            string email = emailEntry.Text;

            // Check if the phone entry has a valid integer value
            if (!int.TryParse(phoneEntry.Text, out int phone))
            {
                // Handle the case where the phone entry does not contain a valid integer
                DisplayAlert("Error", "Invalid phone number", "OK");
            }
            else
            {
                // Create a new contact using these values
                PhoneMaui.Models.Contact newContact = new PhoneMaui.Models.Contact
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phone
                };

                // Use your IPhonebookService to add the contact
                phonebookService?.AddContact(newContact);

                // Optionally, navigate back to the main page or show a success message
                Navigation.PopAsync();
            }
        }
    }
}
