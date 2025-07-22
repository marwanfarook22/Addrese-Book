public record ContactRemover(IContactRemoverUI RemoverUI, List<Contact> Contacts) : IContactRemover
{
    public void RemoveContacts()
    {
        if (Contacts.Count == 0)
        {
            RemoverUI.displayMessage("no data Found");
        }
        else
        {
            RemoverUI.DisplayContacts(Contacts);
            var Index = RemoverUI.Userintractive("Which Contacts You Want To deleate", Contacts.Count);
            Contacts.RemoveAt(Index);
        }

    }
}

