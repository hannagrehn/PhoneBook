using MauiPhonebook.Models;
using Contact = MauiPhonebook.Models.Contact;
using MauiPhonebook.Views;

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
            }
            
            
        }
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        contact.LastName = entryLastName.Text;
        contact.FirstName = entryFristName.Text;
        

        ContactRepos.UpdateContact(contact.ContactId, contact);
        Shell.Current.GoToAsync("..");
    }
}