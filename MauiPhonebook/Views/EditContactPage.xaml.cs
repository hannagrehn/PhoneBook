using MauiPhonebook.Models;
using Contact = MauiPhonebook.Models.Contact;

namespace MauiPhonebook.Views;

[QueryProperty(nameof(ContactId), "Id")]

public partial class EditContactPage : ContentPage
{
    private Contact contact;

	public EditContactPage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    public string ContactId
    {
        set
        {
            contact = ContactRepos.GetContactById(int.Parse(value));
            if (contact != null)
            {
                contactCtrl.FirstName = contact.FirstName;
                contactCtrl.LastName = contact.LastName;
                contactCtrl.Email = contact.Email;
                contactCtrl.Phone = contact.Phone;    
                contactCtrl.Address = contact.Address;
            }
        }
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {

        contact.LastName = contactCtrl.FirstName;
        contact.FirstName = contactCtrl.LastName;
        contact.Email = contactCtrl.Email;
        contact.Phone = contactCtrl.Phone;
        contact.Address = contactCtrl.Address;

        ContactRepos.UpdateContact(contact.ContactId, contact);
        Shell.Current.GoToAsync("..");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "As per usual");
    }
}