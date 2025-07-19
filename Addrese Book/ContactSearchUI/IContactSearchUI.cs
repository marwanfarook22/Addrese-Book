using static Addrese_Book.ContactSearchingFolder.ContactSearching;

public interface IContactSearchUI
{
    ContactDetail UserInteractive(string message);
    void UserInterface();
    void DisplaySearchResults(List<Contact> contacts);
    void DisplayNoResultsFound();
    void DisplayError(string message);
}







