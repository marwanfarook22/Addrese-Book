public interface IAddContactClass
{
    List<string> PhonesCollictionValidtion();
    string ValidateSinglePhoneNumber();
    Contact CreateValidatedContact();
    string ValidateEmail();
    string ValidateName();
}





