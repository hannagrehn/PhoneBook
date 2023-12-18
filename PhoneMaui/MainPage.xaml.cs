using PhoneMaui.Services;
using PhoneMaui.Models;
using PhoneMaui.Interfaces;


namespace PhoneMaui
{
    public partial class MainPage : ContentPage
    {
        private readonly Interfaces.IPhonebookService phonebookService;

        public MainPage(Interfaces.IPhonebookService phonebookService)
        {
            this.phonebookService = phonebookService;
            InitializeComponent();
        }

        public void ShowAllContacts_Clicked(object sender, EventArgs e)
        {
            // Assuming you have some UI element like a ListView to display contacts
            // Replace 'yourListView' with the actual name of your ListView
            // Make sure you have the appropriate XAML markup for the ListView in your MainPage.xaml
        }



        public void AddContact_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddContactPage(phonebookService));
        }




        private void RemoveContact_Clicked(object sender, EventArgs e)
        {
            // Similar to AddContact, you might need a page for removing a contact
            // You could navigate to this page or show a modal for selecting and removing contacts
            //Navigation.PushAsync(new RemoveContactPage(phonebookService));
        }

        public void UpdateContact_Clicked(object sender, EventArgs e)
        {
            // Similar to AddContact and RemoveContact, you might need a page for updating a contact
            // You could navigate to this page or show a modal for selecting and updating contacts
            //Navigation.PushAsync(new UpdateContactPage(phonebookService));
        }

        // Other methods and event handlers as needed
    }
}
