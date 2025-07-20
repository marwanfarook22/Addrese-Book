

using Addrese_Book.ContactSearchingFolder;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

var addContact = new Addcontacts();
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





//new ContactSearching(new ContactSearchUI()).FilteringList(Contacts);
//Console.WriteLine();
//var editContact = new ContactEditor(new Addcontacts(), Contacts, new EditContactsUI());
//editContact.EditedRunSection();
//new ContactRemover(new ContactRemoverUI(), Contacts).RemoveContacts();

for (int i = 0; i < Contacts.Count(); i++)
{
    Console.WriteLine($"{i + 1}-{Contacts[i].Email} | {Contacts[i].Name} | {string.Join("-", Contacts[i].PhoneNumber)} ");

}




Console.WriteLine("press Any Key To Esc");
Console.ReadKey();

