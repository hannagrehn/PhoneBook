using MauiPhonebook.Models;
using Contact = MauiPhonebook.Models.Contact;
using MauiPhonebook.Views;
using System.Reflection.Metadata.Ecma335;

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
                entryFristName.Text = contact.FirstName;
                entryLastName.Text = contact.LastName;
                entryEmail.Text = contact.Email;
                entryPhone.Text = contact.Phone;    
                entryAddress.Text = contact.Address;
            }
            
            
        }
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        if (nameValidator.IsNotValid)
        {
            DisplayAlert("You stupid", "idiot", "try again");
            return;
        }

        if (emailValidator.IsNotValid)
        {
            foreach(var error in emailValidator.Errors)
            {
                DisplayAlert("Very stupid", error.ToString(), "As per usual");
            }

            return;
        }

        contact.LastName = entryLastName.Text;
        contact.FirstName = entryFristName.Text;
        contact.Email = entryEmail.Text;
        contact.Phone = entryPhone.Text;
        contact.Address = entryAddress.Text;
        

        ContactRepos.UpdateContact(contact.ContactId, contact);
        Shell.Current.GoToAsync("..");
    }
}