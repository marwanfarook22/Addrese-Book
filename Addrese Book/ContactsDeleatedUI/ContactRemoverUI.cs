public class ContactRemoverUI : IContactRemoverUI
{
    public void DisplayContacts(List<Contact> Contacts)
    {

        for (int i = 0; i < Contacts.Count(); i++)
        {
            Console.WriteLine($"{i + 1}-{Contacts[i].Email} | {Contacts[i].Name} | {string.Join("-", Contacts[i].PhoneNumber)} ");

        }
    }

    public void displayMessage(string message)
    {
        Console.WriteLine(message);
    }

    public int Userintractive(string message, int ContactsLength)
    {
        Console.WriteLine(message);
        int.TryParse(Console.ReadLine(), out int Index);
        while (Index - 1 < 0 || Index - 1 >= ContactsLength)
        {
            Console.WriteLine("Valid Index Try Again");
            int.TryParse(Console.ReadLine(), out Index);

        }
        return Index - 1
            ;
    }

}

