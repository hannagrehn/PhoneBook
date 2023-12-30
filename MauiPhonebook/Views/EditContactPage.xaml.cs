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
            lblName.Text = contact.FirstName;
        }
    }

}