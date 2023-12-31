using MauiPhonebook.Views;
using MauiPhonebook.Models;
using Contact = MauiPhonebook.Models.Contact;

namespace MauiPhonebook.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
			
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

        List<Contact> contacts = ContactRepos.GetContacts();

        listContacts.ItemsSource = contacts;
    }
	

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if (listContacts.SelectedItem != null)
		{
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).ContactId}");
		}

    }
	
	private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		listContacts.SelectedItem = null;
	}

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(AddContactPage));	
    }
}