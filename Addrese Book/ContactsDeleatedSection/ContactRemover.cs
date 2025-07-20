public record ContactRemover(IContactRemoverUI RemoverUI, List<Contact> Contacts)
{
    public void RemoveContacts()
    {
        RemoverUI.DisplayContacts(Contacts);
        var Index = RemoverUI.Userintractive("Which Contacts You Want To deleate", Contacts.Count);
        Contacts.RemoveAt(Index);

    }
}

