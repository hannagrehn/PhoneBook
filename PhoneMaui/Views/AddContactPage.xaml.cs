using Microsoft.Maui.Controls;
using PhoneMaui.Models;
using PhoneMaui.Services;

namespace PhoneMaui
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddContactPage : ContentPage
    {
        // Declare entry fields
        Entry firstNameEntry;
        Entry lastNameEntry;
        Entry emailEntry;
        Entry phoneEntry; // Remove <int> as Entry is not a generic class
        private readonly IPhonebookService phonebookService;

        public AddContactPage(IPhonebookService phonebookService)
        {
            InitializeComponent();

            // Initialize entry fields
            firstNameEntry = new Entry();
            lastNameEntry = new Entry();
            emailEntry = new Entry();
            phoneEntry = new Entry();
            this.phonebookService = phonebookService;
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            // Retrieve values from entries and create a new contact
            string firstName = firstNameEntry.Text;
            string lastName = lastNameEntry.Text;
            string email = emailEntry.Text;

            // Check if the phone entry has a valid integer value
            if (int.TryParse(phoneEntry.Text, out int phone))
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
                phonebookService.AddContact(newContact);

                // Optionally, navigate back to the main page or show a success message
                Navigation.PopAsync();
            }
            else
            {
                // Handle the case where the phone entry does not contain a valid integer
                DisplayAlert("Error", "Invalid phone number", "OK");
            }
        }
    }
}
