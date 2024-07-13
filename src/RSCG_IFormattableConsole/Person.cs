
namespace RSCG_IFormattableConsole;
[RSCG_IFormattableCommon.AddIFormattable]
internal partial class Person
{
    public Person(string lastName)
    {
        LastName = lastName;
    }
    public string? FirstName { get; set; }
    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public Person[]? Children { get; set; }
    public int Age
    {
        get
        {
            return DateTime.Now.Year - DateOfBirth.Year;
        }
    }

}


