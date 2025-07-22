public class ContactEditor : IContactEditor
{
    private IAddContactClass _addContact;
    private IEditContactUi _ui;
    private List<Contact> _contacts { get; }

    public ContactEditor(IAddContactClass addContact,
        List<Contact> contacts,
        IEditContactUi ui)
    {
        _addContact = addContact;
        _contacts = contacts;
        _ui = ui;
    }


    public void EditedRunSection()
    {
        _ui.ShowMessage("Please enter the value you want to Edit for:");
        if (_contacts.Count == 0)
        {
            _ui.ShowMessage("no data Found ");
        }
        else
        {

            _ui.DataDisplay(_contacts);
            var index = _ui.GetContactIndex("Enter Your Chossen data number ", _contacts);
            string fieldToEdit = _ui.UserInteractiveChossenDetail();
            _contacts[index] = EditContactField(index, fieldToEdit);
            _ui.DataDisplay(_contacts);
        }
    }

    private Contact EditContactField(int index, string fieldToEdit)
    {
        switch (fieldToEdit)
        {
            case "name":
                return EditName(index);
            case "email":
                return EditEmail(index);
            case "phoneNumber":
                return EditPhoneNumber(index);
            default:
                return EditName(index); /*Edited name Is default choosen*/
        }
    }

    Contact EditName(int index)
    {
        var contact = _contacts[index];
        var newName = _addContact.ValidateName();
        _ui.ShowMessage("Name edited successfully");

        return contact with { Name = newName }; // Creates new instance with updated name

    }

    private Contact EditEmail(int index)
    {
        var contact = _contacts[index];
        var newEmail = _addContact.ValidateEmail();
        _ui.ShowMessage("Email edited successfully");
        return contact with { Email = newEmail }; // Creates new instance with updated email
    }
    private Contact EditPhoneNumber(int index)
    {
        var contact = _contacts[index];
        _ui.ShowMessage("Which number would you like to edit?");
        _ui.displayPhoneNumbers(contact.PhoneNumber);

        var phoneIndex = _ui.GetPhoneNumberIndex(contact.PhoneNumber.Count);
        var newNumber = _addContact.ValidateSinglePhoneNumber();

        // Create a new list with the updated number
        var updatedNumbers = contact.PhoneNumber.ToList();
        updatedNumbers[phoneIndex] = newNumber;

        _ui.ShowMessage("Phone number edited successfully");
        return contact with { PhoneNumber = updatedNumbers }; // New instance with updated numbers
    }
}


