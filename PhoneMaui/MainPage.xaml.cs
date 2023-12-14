using PhoneMaui.Services;
using PhoneMaui.Models;


namespace PhoneMaui
{
    public partial class MainPage : ContentPage
    {
        private readonly IPhonebookService phonebookService;

        public MainPage(IPhonebookService phonebookService)
        {
            this.phonebookService = phonebookService;
            InitializeComponent();
        }

        public  void ShowAllContacts_Clicked(object sender, EventArgs e)
        {
            
        }

        public void AddContact_Clicked(object sender, EventArgs e)
        {
            Models.Contact newContact = new() { };
            phonebookService.AddContact(newContact);
        }

        private IPhonebookService GetPhonebookService()
        {
            return phonebookService;
        }

        private void RemoveContact_Clicked(object sender, EventArgs e)
        {
            
            
        }


        public void UpdateContact_Clicked(object sender, EventArgs e)
        {
            
           
        }

       
    }
}
