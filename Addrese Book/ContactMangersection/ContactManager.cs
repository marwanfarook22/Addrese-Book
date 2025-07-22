using Newtonsoft.Json;

public class ContactManager(IContactManagerUI managerUI) : IContactManager
{
    public bool SaveContactsToJsonFile(List<Contact> contacts)
    {
        // Validate input
        if (contacts == null)
        {
            managerUI.DisplayMessages("Error: Contacts list cannot be null.");
            return false;
        }

        try
        {
            string filePath = managerUI.UserInteractive("Save");

            // Additional validation for file path
            if (string.IsNullOrWhiteSpace(filePath))
            {
                managerUI.DisplayMessages("Error: Invalid file path provided.");
                return false;
            }

            // Create directory if it doesn't exist
            string? directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            };

            string jsonString = JsonConvert.SerializeObject(contacts, jsonSettings);
            File.WriteAllText(filePath, jsonString);

            managerUI.DisplayMessages($"Successfully saved {contacts.Count} contacts to {filePath}");
            return true;
        }
        catch (UnauthorizedAccessException ex)
        {
            managerUI.DisplayMessages($"Access denied: {ex.Message}");
            return false;
        }
        catch (DirectoryNotFoundException ex)
        {
            managerUI.DisplayMessages($"Directory not found: {ex.Message}");
            return false;
        }
        catch (JsonSerializationException ex)
        {
            managerUI.DisplayMessages($"Serialization error: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {
            managerUI.DisplayMessages($"Unexpected error saving file: {ex.Message}");
            return false;
        }
    }
    public List<Contact> ReadContactsToJsonFile()
    {
        try
        {
            string filePath = managerUI.UserInteractive("Load");

            if (string.IsNullOrWhiteSpace(filePath))
            {
                managerUI.DisplayMessages("Error: Invalid file path provided.");
                return new List<Contact>();
            }

            if (!File.Exists(filePath))
            {
                managerUI.DisplayMessages($"File '{filePath}' does not exist.");
                return new List<Contact>();
            }

            // Check if file is empty
            var fileInfo = new FileInfo(filePath);
            if (fileInfo.Length == 0)
            {
                managerUI.DisplayMessages($"File '{filePath}' is empty.");
                return new List<Contact>();
            }

            string jsonString = File.ReadAllText(filePath);

            // Handle empty or whitespace-only JSON
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                managerUI.DisplayMessages($"File '{filePath}' contains no valid data.");
                return new List<Contact>();
            }

            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            };

            List<Contact>? contacts = JsonConvert.DeserializeObject<List<Contact>>(jsonString, jsonSettings);

            if (contacts == null)
            {
                managerUI.DisplayMessages($"Could not parse data from '{filePath}'. File may be corrupted.");
                return new List<Contact>();
            }

            managerUI.DisplayMessages($"Successfully loaded {contacts.Count} contacts from {filePath}");
            return contacts;
        }
        catch (UnauthorizedAccessException ex)
        {
            managerUI.DisplayMessages($"Access denied: {ex.Message}");
            return new List<Contact>();
        }
        catch (FileNotFoundException ex)
        {
            managerUI.DisplayMessages($"File not found: {ex.Message}");
            return new List<Contact>();
        }
        catch (JsonReaderException ex)
        {
            managerUI.DisplayMessages($"Invalid JSON format: {ex.Message}");
            return new List<Contact>();
        }
        catch (JsonSerializationException ex)
        {
            managerUI.DisplayMessages($"Deserialization error: {ex.Message}");
            return new List<Contact>();
        }
        catch (Exception ex)
        {
            managerUI.DisplayMessages($"Unexpected error reading file: {ex.Message}");
            return new List<Contact>();
        }
    }
}



