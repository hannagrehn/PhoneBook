using MauiPhonebook.Views;

namespace MauiPhonebook
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
            Routing.RegisterRoute(nameof(EditContactPage), typeof(EditContactPage));
            Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
            Routing.RegisterRoute(nameof(RemoveContactPage), typeof(RemoveContactPage));
        }
    }
}
