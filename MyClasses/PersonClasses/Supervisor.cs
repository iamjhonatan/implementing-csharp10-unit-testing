namespace MyClasses.PersonClasses;

public class Supervisor : Person
{
    public Supervisor()
    {
        Employess = new();
    }

    public List<Employee> Employess { get; set; }
}
