public interface IEditContactUi
{
    int GetContactIndex(string messages, List<Contact> contacts);
    void UserInterfaceContactDetail();
    void DataDisplay(List<Contact> contacts);
    string UserInteractiveChossenDetail();
    void ShowMessage(string message);

    void displayPhoneNumbers(List<string> PhoneNumbers);
    int GetPhoneNumberIndex(int count);
}


