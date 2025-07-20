






using System.Text.RegularExpressions;

public class Addcontacts : ValidatorBase, IAddContactClass
{

    public Contact CreateValidatedContact()
    {
        List<Contact> contacts = new List<Contact>();
        string contactName = ValidateName();
        string ContectEmail = ValidateEmail();
        List<string>? PhonesColliction = PhonesCollictionValidtion();


        return new Contact
        {
            Name = contactName,
            Email = ContectEmail,
            PhoneNumber = PhonesColliction
        };

    }

    public List<string> PhonesCollictionValidtion()
    {
        List<string> phoneNumbers = new List<string>();
        bool addMore = true;

        while (addMore)
        {
            string phoneNumber = ValidateSinglePhoneNumber();
            phoneNumbers.Add(phoneNumber);

            Console.WriteLine("Do you want to add another phone number? (yes/no)");
            string response = Console.ReadLine()?.Trim().ToLower()!;
            addMore = response == "yes" || response == "y";
        }

        return phoneNumbers;

    }
    public string ValidateSinglePhoneNumber()
    {
        string phoneNumber;
        bool isValid = false;

        do
        {
            phoneNumber = GetUserInput("Enter phone number (10-15 digits):");

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                Console.WriteLine("Phone number cannot be empty. Try again:");
                continue;
            }

            // Remove common formatting characters
            string cleanedNumber = Regex.Replace(phoneNumber, @"[\s\-\(\)]", "");

            // Check if it contains only digits (optionally starting with +)
            if (cleanedNumber.StartsWith("+"))
            {
                cleanedNumber = cleanedNumber.Substring(1);
            }

            if (!Regex.IsMatch(cleanedNumber, @"^\d+$"))
            {
                Console.WriteLine("Phone number must contain only digits. Try again:");
                continue;
            }

            if (cleanedNumber.Length < 10 || cleanedNumber.Length > 15)
            {
                Console.WriteLine("Phone number must be between 10 and 15 digits. Try again:");
                continue;
            }

            isValid = true;
            phoneNumber = cleanedNumber; // Store cleaned version

        } while (!isValid);

        return phoneNumber;
    }

    public override string ValidateName()
    {
        bool isValid = false;
        string userName = GetUserInput("Enter User Name");

        do
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                Console.WriteLine("Name cannot be empty. Try again:");
                userName = GetUserInput("Enter your name:");
            }
            else if (userName.Length < 3 || userName.Length > 20)
            {
                Console.WriteLine("Name must be 3-20 characters. Try again:");
                userName = GetUserInput("Enter your name:");
            }
            else
            {
                isValid = true;
            }
        } while (!isValid);

        return userName;
    }

    public override string ValidateEmail()
    {
        string email;
        do
        {
            email = GetUserInput("Enter Email Address:");
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email cannot be empty. Try again:");
                continue;
            }
            try
            {
                var result = new System.Net.Mail.MailAddress(email);
                if (result.Address != email)
                {
                    Console.WriteLine("Invalid email format. Try again:");
                    continue;
                }
                return email;
            }
            catch
            {
                Console.WriteLine("Invalid email format. Try again:");
            }
        } while (true);
    }
}





