public class MainProgramUI : ImainProgramUI
{


    public void displaMessages(string message)
    {
        Console.WriteLine(message);
    }


    public void displayData(List<Contact> contactsData)
    {
        foreach (Contact contact in contactsData)
        {
            Console.WriteLine($"{contact.Name}/{contact.Email}/{string.Join("/", contact.PhoneNumber)}");
        }
    }

    public string Userinteractive()
    {
        displaMessages("What Operation You want To do \n" +
                       "1 > Load existing file\n" +
                        "1 > Create A new Contact  \n");

        string userInput;

        while (true)
        {
            userInput = Console.ReadLine()!.Trim();

            // Fixed condition: use AND (&&) instead of OR (||)
            if (userInput == "1" || userInput == "2")
            {
                break; // Valid input, exit loop
            }

            displaMessages("Invalid Input. Try Again:");
        }

        return userInput;
    }
}



