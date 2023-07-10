using System;
using System.Collections.Generic;

namespace PhoneBook
{
    internal class Program
    {
        static Dictionary<string, string> contacts = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Phone Book");

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("####################################");
                Console.WriteLine("1 - Add Contact");
                Console.WriteLine("2 - Show Contact by Number");
                Console.WriteLine("3 - Show All Contacts");
                Console.WriteLine("4 - Search Contacts by Name");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("####################################");
                Console.WriteLine("");

                Console.WriteLine("Please enter the number of the action: ");
                string? input = Console.ReadLine();

                Console.Clear(); // Clear the console

                switch (input)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        ShowContactByNumber();
                        break;
                    case "3":
                        ShowAllContacts();
                        break;
                    case "4":
                        SearchContactsByName();
                        break;
                    case "0":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
        }

        static void AddContact()
        {
            Console.WriteLine("Enter the name of the contact: ");
            string? name = Console.ReadLine();

            Console.WriteLine("Enter the phone number of the contact: ");
            string? phoneNumber = Console.ReadLine();

            contacts.Add(phoneNumber, name);

            Console.WriteLine("Contact added successfully.");
        }

        static void ShowContactByNumber()
        {
            Console.WriteLine("Enter the phone number of the contact: ");
            string? phoneNumber = Console.ReadLine();

            if (contacts.ContainsKey(phoneNumber))
            {
                string name = contacts[phoneNumber];
                Console.WriteLine($"Contact found - Name: {name}, Phone Number: {phoneNumber}");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        static void ShowAllContacts()
        {
            Console.WriteLine("All Contacts:");

            foreach (KeyValuePair<string, string> contact in contacts)
            {
                string phoneNumber = contact.Key;
                string name = contact.Value;
                Console.WriteLine($"Name: {name}, Phone Number: {phoneNumber}");
            }
        }

        static void SearchContactsByName()
        {
            Console.WriteLine("Enter the name to search for: ");
            string? searchName = Console.ReadLine();

            bool found = false;

            foreach (KeyValuePair<string, string> contact in contacts)
            {
                string? phoneNumber = contact.Key;
                string? name = contact.Value;

                if (name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Contact found - Name: {name}, Phone Number: {phoneNumber}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No contacts found with the given name.");
            }
        }
    }
}
