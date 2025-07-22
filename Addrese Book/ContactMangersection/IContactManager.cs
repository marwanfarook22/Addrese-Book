public interface IContactManager
{
    List<Contact> ReadContactsToJsonFile();
    bool SaveContactsToJsonFile(List<Contact> contacts);
}



