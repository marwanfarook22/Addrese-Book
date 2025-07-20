namespace Addrese_Book.ContactSearchingFolder;

public partial class ContactSearching : IContactSearching
{
    public IContactSearchUI _contactSearchUI;

    public ContactSearching(IContactSearchUI contactSearchUI)
    {
        _contactSearchUI = contactSearchUI;
    }

    public void FilteringList(List<Contact> contacts)
    {
        Dictionary<ContactDetail, Func<string, List<Contact>>> Filters = new Dictionary<ContactDetail, Func<string, List<Contact>>>()
        {
            [ContactDetail.userName] = input => contacts
   .Where(x => x.Name.Replace(" ", "").Equals(
            input.Replace(" ", ""),
            StringComparison.OrdinalIgnoreCase))/*IgnoreCase: Treats "A" and "a" as equal.*/
        .ToList(),

            [ContactDetail.email] = input => contacts
    .Where(x => x.Email.Equals(input, StringComparison.OrdinalIgnoreCase)) /*IgnoreCase: Treats "A" and "a" as equal.*/
     .ToList(),
            [ContactDetail.phoneNumber] = input => contacts.Where(x => x.PhoneNumber?.Any(p => p.Contains(input)) ?? false).ToList(),
        };

        ContactDetail UserInput = _contactSearchUI.UserInteractive("Please select the type of contact you want to search for:");
        while (!Filters.ContainsKey(UserInput))
        {
            UserInput = _contactSearchUI.UserInteractive("Invalid Key Try Again");
        }
        SearchContacts(UserInput, Filters);
    }



    private void SearchContacts(ContactDetail userInput,
        Dictionary<ContactDetail, Func<string, List<Contact>>> Filters)
    {
        Console.WriteLine("Please enter the value you want to search for:");
        string searchValue = Console.ReadLine()!.Trim();
        List<Contact> SearchedList = Filters[userInput](searchValue);

        if (string.IsNullOrWhiteSpace(searchValue))
        {
            _contactSearchUI.DisplayError("Search term cannot be empty.");
        }
        else if (SearchedList.Count() == 0)
        {
            _contactSearchUI.DisplayNoResultsFound();
        }
        else
        {
            _contactSearchUI.DisplaySearchResults(SearchedList);
        }
    }
}