public class ContactManagerUI : IContactManagerUI
{
    public void DisplayMessages(string messages)
    {
        Console.WriteLine(messages);
    }
    public string UserInteractive(string opertionType)
    {
        DisplayMessages($"Write a file name you want to {opertionType} : ");
        string fileName;
        bool isValid;



        do
        {
            Console.Write("> ");
            fileName = Console.ReadLine()?.Trim() ?? string.Empty;
            isValid = false;

            if (string.IsNullOrWhiteSpace(fileName))
            {
                DisplayMessages("❌ File name cannot be empty or contain only spaces.");
                DisplayMessages("Please enter a valid file name:");
                continue;
            }


            // Add .json extension if not present
            if (!fileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
            {
                fileName += ".json";
            }

            // For save operations, check if file exists and ask for confirmation
            if (opertionType.Equals("Save", StringComparison.OrdinalIgnoreCase) && File.Exists(fileName))
            {
                if (!ConfirmAction($"File '{fileName}' already exists. Do you want to overwrite it?"))
                {
                    DisplayMessages("Please enter a different file name:");
                    continue;
                }
            }

            // For load operations, check if file exists
            if (opertionType.Equals("Load", StringComparison.OrdinalIgnoreCase) && !File.Exists(fileName))
            {
                DisplayMessages($"❌ File '{fileName}' does not exist.");
                DisplayMessages("Please enter an existing file name:");
                continue;
            }

            isValid = true;

        } while (!isValid);

        return fileName;

    }

    public bool ConfirmAction(string message)
    {
        Console.Write($"{message} (y/n): ");
        string? response = Console.ReadLine()?.Trim().ToLower();
        return response == "y" || response == "yes";
    }

}



