public abstract class ValidatorBase
{
    public abstract string ValidateName();
    public abstract string ValidateEmail();

    protected static string GetUserInput(string prompt)
    {
        Console.WriteLine(prompt);
        return Console.ReadLine()!;
    }
}





