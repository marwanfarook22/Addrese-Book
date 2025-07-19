using static Addrese_Book.ContactSearchingFolder.ContactSearching;

public class ContactSearchUI : IContactSearchUI
{
    public ContactDetail UserInteractive(string message)
    {
        Console.WriteLine(message);
        UserInterface();
        string userInput = Console.ReadLine()!.Trim();
        switch (userInput)
        {
            case "1":
                Console.WriteLine("You have selected to search by Name.");
                return ContactDetail.userName;
            case "2":
                Console.WriteLine("You have selected to search by Email.");
                return ContactDetail.email;
            case "3":
                Console.WriteLine("You have selected to search by Phone Number.");
                return ContactDetail.phoneNumber;
            default:
                return ContactDetail.userName; // Default case if input is invalid
        }

    }

    public void UserInterface()
    {
        int index = 1;
        foreach (var Data in Enum.GetValues(typeof(ContactDetail)))
        {
            Console.WriteLine($"{index}:{Data}");
            index++;
        }

    }


    public void DisplaySearchResults(List<Contact> contacts)
    {
        foreach (var item in contacts)
        {
            Console.WriteLine($"Data Found: {item.Name}|{item.Email}|{string.Join("|", item.PhoneNumber)}");
        }
    }
    public void DisplayNoResultsFound() => Console.WriteLine("No data found.");

    public void DisplayError(string message)
    {
        Console.WriteLine(message);
    }
}







