

using Addrese_Book.ContactSearchingFolder;

var Validator = new ValiditorClass();
List<Contact> Contacts = new List<Contact>()
{
    new Contact
    {
        Name = "Alice Johnson",
        Email = "alice.johnson@example.com",
        PhoneNumber = new List<string> { "555-1234", "555-5678" }
    },
    new Contact
    {
        Name = "Bob Smith",
        Email = "bob.smith@example.com",
        PhoneNumber = new List<string> { "555-8765" }
    },
    new Contact
    {
        Name = "Carol Lee",
        Email = "carol.lee@example.com",
        PhoneNumber = new List<string> { "555-4321", "555-6789", "01020483849" }
    },
    new Contact
    {
        Name = "David Brown",
        Email = "david.brown@example.com",
        PhoneNumber = new List<string> { "555-2468" ,"01020483849" }
    }
};


new ContactSearching(new ContactSearchUI()).FilteringList(Contacts);



Console.ReadKey();







