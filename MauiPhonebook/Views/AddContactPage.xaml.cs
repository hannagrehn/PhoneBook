using MauiPhonebook.Models;
using Contact = MauiPhonebook.Models.Contact;
namespace MauiPhonebook.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }

    private void contactCtrl_OnSave(object sender, EventArgs e)
    {
        try
        {
            var newContact = new Contact
            {
                FirstName = contactCtrl.FirstName,
                LastName = contactCtrl.LastName,
                Email = contactCtrl.Email,
                Phone = contactCtrl.Phone,
                Address = contactCtrl.Address
            };

            ContactRepos.AddContact(newContact);

            
            DisplayAlert("Success!", $"Contact added: {newContact.FirstName} {newContact.LastName}", "Nice");

            Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            
            DisplayAlert("Error", $"Error adding contact: {ex.Message}", "OK");
        }
    }



    private void contactCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("You donut", e, "I'm sorry");
    }

    private void contactCtrl_OnSave_1(object sender, EventArgs e)
    {
        try
        {
            var newContact = new Contact
            {
                FirstName = contactCtrl.FirstName,
                LastName = contactCtrl.LastName,
                Email = contactCtrl.Email,
                Phone = contactCtrl.Phone,
                Address = contactCtrl.Address
            };

            ContactRepos.AddContact(newContact);


            DisplayAlert("Success", $"Contact added: {newContact.FirstName} {newContact.LastName}", "OK");

            Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {

            DisplayAlert("Error", $"Error adding contact: {ex.Message}", "OK");
        }
    }
}