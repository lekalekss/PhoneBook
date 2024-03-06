using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace PhoneBook;

public class PhoneBook
{
    public PhoneBook(List<Contact> contacts)
    {
        Contacts = contacts;
    }

    public PhoneBook()
    {
        Contacts = new List<Contact>();
    }
    public List<Contact> Contacts { get; set; }
    public IConsoleReader ConsoleReader = new ConsoleReader();
    
    public void AddContact()
    {
        Contact contact = new Contact();

        ConsoleReader.Write("\nEnter Name: ");
        contact.FirstName = ConsoleReader.ReadLine();

        ConsoleReader.Write("Enter Lastname: ");
        contact.LastName = ConsoleReader.ReadLine();


        ConsoleReader.Write("Enter phone number: ");
        contact.PhoneNumber = ConsoleReader.ReadLine();
        
        Contacts.Add(contact);
        
        Console.ForegroundColor = ConsoleColor.Green;
        ConsoleReader.WriteLine("\nContact added.");
        Console.ResetColor();


    }

    public void ViewContacts()
    {
        
        int countContacts = Contacts.Count();

        if (countContacts == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            ConsoleReader.WriteLine("Contacts list is empty.");
            Console.ResetColor();
        }

        if (countContacts > 0) 
        {
            
            foreach (Contact contact in Contacts)
            {
                ConsoleReader.WriteLine($"Name: {contact.FirstName}" +
                    $" Lastname: {contact.LastName} Phone number: {contact.PhoneNumber}");
            }

        }

    }

    public void UpdateContact()
    {

        ConsoleReader.Write("\nEnter contacts phone number, Name or Lastname, which would like to update: ");
        string dataForSearch = ConsoleReader.ReadLine();

        //bool isNumberContains = Contacts.Contains(numberForSearch);

        //foreach (Contact contact in Contacts)
        //{
        //    bool isNumberContains = Contacts.Contains(numberForSearch);
        //}


        //Console.WriteLine($"\nExists: Part with {numberForSearch}: {0}",
        //Contacts.Exists(x => x.PhoneNumber == numberForSearch));


        Contact contact = Contacts.Find(x => x.PhoneNumber == dataForSearch || 
        x.FirstName == dataForSearch || x.LastName == dataForSearch);
            

            if (contact != null)
            {
                ConsoleReader.Write("\nEnter new Name: ");
                contact.FirstName = ConsoleReader.ReadLine();

                ConsoleReader.Write("Enter new Lastname: ");
                contact.LastName = ConsoleReader.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;
                ConsoleReader.WriteLine("Contact updated.");
                Console.ResetColor();

            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                ConsoleReader.WriteLine("\nContact not found.");
                Console.ResetColor();
            }
                    
    }

    public void DeleteContact()
    {
        ConsoleReader.Write("\nEnter contacts phone number, Name or Lastname, which would like to delete: ");
        string dataForSearch = ConsoleReader.ReadLine();

        Contact contact = Contacts.Find(x => x.PhoneNumber == dataForSearch ||
        x.FirstName == dataForSearch || x.LastName == dataForSearch);

        if (contact != null)
        {
            Contacts.Remove(contact);

            Console.ForegroundColor = ConsoleColor.Blue;
            ConsoleReader.WriteLine("Contact deleted.");
            Console.ResetColor();
        }

        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            ConsoleReader.WriteLine("\nContact not found.");
            Console.ResetColor();
        }

    }

    public void SearchContact()
    {
        ConsoleReader.Write("\nEnter contacts phone number, Name or Lastname for search: ");

        string forSearch = ConsoleReader.ReadLine();

        List<Contact> contacts = Contacts.FindAll(x => x.PhoneNumber.Contains(forSearch) ||
        x.FirstName.Contains(forSearch) || x.LastName.Contains(forSearch));

        foreach (Contact contact in contacts)
        {


            if (contacts != null)
            {
                Console.WriteLine($"\nFound: {forSearch}: \nName: {contact.FirstName} Lastname: {contact.LastName} " +
                   $"Phone number: {contact.PhoneNumber}");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                ConsoleReader.WriteLine("\nContact not found.");
                Console.ResetColor();
            }
        }
    }

    public void SaveBook()
    {
        using (StreamWriter writer = new StreamWriter("contacts.txt"))
        {
            foreach (Contact contact in Contacts)
            {
                writer.WriteLine(contact.FirstName+ "," +contact.LastName + "," + contact.PhoneNumber);
            }
        }

        ConsoleReader.WriteLine("Книга сохранена.");
    }

    public void LoadBook()
    {
        try
        {
            // Open the text file using a stream reader.
            using (var sr = new StreamReader("contacts.txt"))
            {
                // Read the stream as a string, and write the string to the console.
                Console.WriteLine(sr.ReadToEnd());
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }

        //if (File.Exists("contacts.txt"))
        //{
        //    string[] lines = File.ReadAllLines("contacts.txt");
        //    foreach (string line in lines)
        //    {
        //        string[] parts = line.Split(',');
        //        if (parts.Length == 3)
        //        {
        //            Contacts.Add(new Contact
        //            {
        //                FirstName = parts[0],
        //                LastName = parts[1],
        //                PhoneNumber = parts[2]
        //            });
        //        }
        //    }
        //    ConsoleReader.WriteLine("Книга загружена.");
        //}
        //else
        //{
        //    ConsoleReader.WriteLine("Файл с контактами не найден.");
        //}
    }

    
}
