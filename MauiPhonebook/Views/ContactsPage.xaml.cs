namespace MauiPhonebook.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();

		List<Contact> contacts = new List<Contact>()
		{
			new Contact { FirstName = "Frank", LastName = "Hanks", Email = "frank@hans.com" },
            new Contact { FirstName = "Hank", LastName = "Hanks", Email = "hanks@hans.com" },
            new Contact { FirstName = "Mank", LastName = "Toms", Email = "mank@toms.se" }
		};

		listContacts.ItemsSource = contacts;

			
	}

	public class Contact
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }


	}

	private void listContacts_ItemSelected(object sender, SelectionChangedEventArgs e)
	{
		DisplayAlert("test", "test", "ok");
		listContacts.SelectedItem = null;
	}


}