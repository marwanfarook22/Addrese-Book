using static Addrese_Book.ContactSearchingFolder.ContactSearching;

 
 public class EditContactsUI : IEditContactUi
{
    public int GetContactIndex(string messages, List<Contact> contacts)
    {
        Console.WriteLine(messages);
        int.TryParse(Console.ReadLine(), out int R);
        do
        {
            if (R < 0 || R > contacts.Count())
            {
                Console.WriteLine("Invalid Index ");
                int.TryParse(Console.ReadLine(), out R);
            }
        } while (R < 0 || R > contacts.Count());

        return R;

    }
    public void UserInterfaceContactDetail()
    {
        int index = 1;
        foreach (var Data in Enum.GetValues(typeof(ContactDetail)))
        {
            Console.WriteLine($"{index}:{Data}");
            index++;
        }

    }

    public void DataDisplay(List<Contact> contacts)
    {
        for (int i = 0; i < contacts.Count(); i++)
        {
            Console.WriteLine($" {i} : {contacts[i].Name}: {contacts[i].Email}| {string.Join(",", contacts[i].PhoneNumber)}");

        }
    }

    public string UserInteractiveChossenDetail()
    {
        UserInterfaceContactDetail();
        string userInput = Console.ReadLine()!.Trim();
        switch (userInput)
        {
            case "1":
                Console.WriteLine($"You have selected to edit  Name.");
                return "name";
            case "2":
                Console.WriteLine("You have selected to edit Email.");
                return "email";
            case "3":
                Console.WriteLine("You have selected to edit Phone Number.");
                return "phoneNumber";

            default:
                return "name"; // Default case if input is invalid
        }
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void displayPhoneNumbers(List<string> PhoneNumbers)
    {
        for (int i = 0; i < PhoneNumbers.Count; i++)
        {
            ShowMessage($" {i}:{PhoneNumbers[i]}");
        }
    }

    public int GetPhoneNumberIndex(int count)
    {
        int phoneNumberIndex;
        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out phoneNumberIndex) ||
                phoneNumberIndex < 0 || phoneNumberIndex >= count)
            {
                Console.WriteLine("Invalid index. Please enter a valid phone number index:");
            }
            else
            {
                break;
            }
        }
        return phoneNumberIndex;
    }
}


