using PhoneBook.Models;
using System;
using System.Collections.Generic;



namespace PhoneBook.Services
{
    public class MenuService
    {
        public static void MenuStart()
        {
            ContactService contactService = new(); // Create an instance of ContactService

            string[] menuItems = ["Show All", "Add", "Remove", "Search", "Exit"];
            int selectedItemIndex = 0;

            ConsoleKeyInfo key;
            bool exitRequested = false;

            do
            {
                Console.Clear();

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedItemIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }

                    Console.WriteLine(menuItems[i]);

                    Console.ResetColor();
                }

                key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow && selectedItemIndex > 0)
                {
                    selectedItemIndex--;
                }
                else if (key.Key == ConsoleKey.DownArrow && selectedItemIndex < menuItems.Length - 1)
                {
                    selectedItemIndex++;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    switch (selectedItemIndex)
                    {
                        case 0:
                            
                            IEnumerable<Contact> contacts = contactService.GetAllContactsFromList();
                            Console.WriteLine("My contacts\n-------------");

                            foreach (var contact in contacts)
                            {
                                Console.WriteLine($"{contact.FirstName} {contact.LastName}, {contact.PhoneNumber}, <{contact.Email}>");
                            }
                            Console.ReadKey();
                            break;

                        case 1:
                            contactService.AddContactToList();
                            Console.ReadKey(true);
                            break;
                        case 2:
                            contactService.RemoveContactFromList();
                            Console.ReadKey(true);
                            break;
                        case 3:
                            contactService.SearchForContact();
                            Console.ReadKey(true);
                            break;
                        case 4:
                            Console.WriteLine("Exiting the program");
                            exitRequested = true;
                            Console.ReadKey();
                            break;
                    }
                }

            } while (!exitRequested);
        }

    }
}
