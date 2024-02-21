namespace GladsonEF.Domain;

public class Name
{
    public Name(string fullName)
    {
        FullName = fullName;
    }

    public string FullName { get; set; }
}