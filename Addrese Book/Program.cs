

using Addrese_Book.ContactSearchingFolder;



new MainProgram(new Addcontacts(), new ContactSearching(new ContactSearchUI()), new MainProgramUI(), new ContactManager(new ContactManagerUI())).appliction();

Console.WriteLine("press Any Key To Esc");
Console.ReadKey();



public class MainProgram(IAddContactClass addContactClass, IContactSearching searching, ImainProgramUI _ImainProgramUI, IContactManager contactManager)
{
    private List<Contact> MainDatacontacts = new List<Contact>();
    public void appliction()
    {
        if (_ImainProgramUI.Userinteractive() == "1")
        {
            MainDatacontacts.AddRange(contactManager.ReadContactsToJsonFile());
            ExistingData();
            contactManager.SaveContactsToJsonFile(MainDatacontacts);
        }
        else
        {
            CreateNewData();
            contactManager.SaveContactsToJsonFile(MainDatacontacts);
        }

        _ImainProgramUI.displaMessages("Data Loaded...");
        Thread.Sleep(1500);
        _ImainProgramUI.displayData(MainDatacontacts);

    }

    private void ExistingData()
    {
        CreateNewData();


    }
    private void CreateNewData()
    {
        bool isExit = false;
        while (!isExit)
        {

            switch (AvailableOperation())
            {
                case "1":
                    MainDatacontacts.Add(addContactClass.CreateValidatedContact());
                    break;
                case "2":
                    searching.FilteringList(MainDatacontacts);
                    break;
                case "3":
                    new ContactEditor(addContactClass, MainDatacontacts, new EditContactsUI()).EditedRunSection();
                    break;
                case "4":
                    new ContactRemover(new ContactRemoverUI(), MainDatacontacts).RemoveContacts();
                    break;
                default:
                    isExit = true;
                    break;
            }

        }

    }

    private string AvailableOperation()
    {
        _ImainProgramUI.displaMessages("Select What kind Of Operation You want ");
        _ImainProgramUI.displaMessages("1 > Add Contact");
        _ImainProgramUI.displaMessages("2 > Seraching Contact");
        _ImainProgramUI.displaMessages("3 > Edit Contact");
        _ImainProgramUI.displaMessages("4 > Deleated contact ");
        _ImainProgramUI.displaMessages("5 > Exit");
        return Console.ReadLine()!;
    }

}



