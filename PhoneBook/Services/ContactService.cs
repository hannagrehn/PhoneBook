using Newtonsoft.Json;
using PhoneBook.Models;
using System.Diagnostics;

namespace PhoneBook.Services
{
    public class ContactService : IContactService


    {
        private readonly List<IContact> _icontactList = new List<IContact>();

        private readonly FileService _fileService = new(@"C:\Education\PhoneBook\content.json");
        private List<Contact> _contactList;

        public ContactService()
        {
            LoadContactsFromFile();
        }

        private void LoadContactsFromFile()
        {
            try
            {
                var content = _fileService.GetContentFromFile();
                if (!string.IsNullOrEmpty(content))
                {
                    var deserializedContacts = JsonConvert.DeserializeObject<List<Contact>>(content);
                    if (deserializedContacts != null)
                    {
                        _contactList = deserializedContacts;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred while loading contacts: {ex.Message}");
            }


            _contactList ??= [];
        }

        /// <summary>
        /// This function will add a contact to the list
        /// </summary>

        public void AddContactToList()
        {
            try
            {
                Console.WriteLine("Enter first name:");
                string? firstName = Console.ReadLine();

                Console.WriteLine("Enter last name:");
                string? lastName = Console.ReadLine();

                Console.WriteLine("Enter phone number:");
                string? phoneNumberInput = Console.ReadLine();

                if (int.TryParse(phoneNumberInput, out int phoneNumber))
                {
                    Console.WriteLine("Enter email:");
                    string? email = Console.ReadLine();

                    Contact newContact = new() { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Email = email };

                    if (!_contactList.Any(x => x.Email == newContact.Email))

                    {
                        _contactList.Add(newContact);
                        _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contactList));
                        Console.WriteLine("Contact added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Contact with the same email already exists!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid phone number. Please enter a valid int.\nTry again.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }



        public IEnumerable<Contact> GetAllContactsFromList()
        {
            try
            {
                var content = _fileService.GetContentFromFile();
                if (!string.IsNullOrEmpty(content))
                {
                    var deserializedContacts = JsonConvert.DeserializeObject<List<Contact>>(content);
                    if (deserializedContacts != null)
                    {
                        _contactList = deserializedContacts;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return _contactList ?? Enumerable.Empty<Contact>();
        }

        public void RemoveContactFromList()
        {
            try
            {
                Console.WriteLine("Enter part of the email to search for:");
                string partialEmail = Console.ReadLine();

                var matchingContacts = _contactList
                    .Where(x => x.Email.IndexOf(partialEmail, StringComparison.OrdinalIgnoreCase) != -1)
                    .ToList();

                if (matchingContacts.Any())
                {
                    int selectedIndex = 0;

                    while (true)
                    {
                        Console.Clear();

                        Console.WriteLine("Select a contact to remove:");

                        for (int i = 0; i < matchingContacts.Count; i++)
                        {
                            Console.BackgroundColor = i == selectedIndex ? ConsoleColor.DarkGray : ConsoleColor.Black;
                            Console.ForegroundColor = i == selectedIndex ? ConsoleColor.Magenta : ConsoleColor.White;

                            Console.Write($"{(i == selectedIndex ? "  " : "  ")}{i + 1}. {matchingContacts[i].Email}");


                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine();
                        }

                        Console.BackgroundColor = selectedIndex == matchingContacts.Count ? ConsoleColor.DarkGray : ConsoleColor.Black;
                        Console.ForegroundColor = selectedIndex == matchingContacts.Count ? ConsoleColor.Magenta : ConsoleColor.White;
                        Console.WriteLine($"  {matchingContacts.Count + 1}. Remove none");


                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;

                        var key = Console.ReadKey().Key;

                        if (key == ConsoleKey.UpArrow)
                        {
                            selectedIndex = Math.Max(0, selectedIndex - 1);
                        }
                        else if (key == ConsoleKey.DownArrow)
                        {
                            selectedIndex = Math.Min(matchingContacts.Count, selectedIndex + 1);
                        }
                        else if (key == ConsoleKey.Enter)
                        {
                            if (selectedIndex == matchingContacts.Count)
                            {
                                Console.WriteLine("\nNo contact removed.");
                                break;
                            }

                            var contactToRemove = matchingContacts[selectedIndex];
                            _contactList.Remove(contactToRemove);
                            _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contactList));
                            Console.WriteLine("\nContact removed successfully!");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No matching contacts found. No contact removed.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// In this part you can search for a contact
        /// </summary>


        public void SearchForContact()
        {
            try
            {
                Console.Write("Who you looking for: ");
                string? searchTerm = Console.ReadLine()?.Trim();

                var searchResults = _contactList
                    .Where(contact =>
                        contact.FirstName.ToLower().Contains(searchTerm.ToLower()) ||
                        contact.LastName.ToLower().Contains(searchTerm.ToLower()) ||
                        contact.Email.ToLower().Contains(searchTerm.ToLower()))
                    .ToList();

                if (searchResults.Any())
                {
                    int selectedIndex = 0;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Select a contact to view:");

                        for (int i = 0; i < searchResults.Count; i++)
                        {
                            Console.ForegroundColor = i == selectedIndex ? ConsoleColor.Magenta : ConsoleColor.White;
                            Console.BackgroundColor = i == selectedIndex ? ConsoleColor.DarkGray : ConsoleColor.Black;
                            Console.WriteLine($"{i + 1}. {searchResults[i].FirstName} {searchResults[i].LastName} - {searchResults[i].Email}");
                            Console.ResetColor();
                        }

                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.Key == ConsoleKey.UpArrow && selectedIndex > 0)
                        {
                            selectedIndex--;
                        }
                        else if (key.Key == ConsoleKey.DownArrow && selectedIndex < searchResults.Count - 1)
                        {
                            selectedIndex++;
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                    } while (true);

                    Console.Clear();

                    var selectedContact = searchResults[selectedIndex];

                    if (!string.IsNullOrWhiteSpace(selectedContact.FirstName) &&
                        !string.IsNullOrWhiteSpace(selectedContact.LastName) &&
                        !string.IsNullOrWhiteSpace(selectedContact.Email))
                    {
                        Console.WriteLine($"Full information for {selectedContact.FirstName} {selectedContact.LastName}:");
                        Console.WriteLine($"\nFirst name: {selectedContact.FirstName}");
                        Console.WriteLine($"Last name: {selectedContact.LastName}");
                        Console.WriteLine($"Phone number: {selectedContact.PhoneNumber}");
                        Console.WriteLine($"Email: {selectedContact.Email}");
                    }
                    else
                    {
                        Console.WriteLine("Selected contact has incomplete information.");
                    }
                }
                else
                {
                    Console.WriteLine("No matching contacts found.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        public bool AddContactToList(IContact contact)
        {
            return true;
        }
    }
}
