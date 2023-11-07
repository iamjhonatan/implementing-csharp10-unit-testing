namespace MyClasses.PersonClasses;

public class PersonManager
{
    public Person? GetPerson(int id)
    {
        /* 
         Simulate looking up a person my their ID
         and not finding them
        */
        return null;
    }

    public List<Person> GetPeople()
    {
        return new()
        {
            new () { FirstName = "Jhonatan", LastName = "Medeiros", Age = 28},
            new () { FirstName = "Peter", LastName = "Parker", Age = 30},
            new () { FirstName = "Jay", LastName = "Weinberg", Age = 33}
        };
    }

    public List<Person> GetSupervisors()
    {
        return new()
        {
            new Supervisor() { FirstName = "Michael", LastName = "Kyle", Age = 55},
            new Supervisor() { FirstName = "Andrew", LastName = "Junior", Age = 25}
        };
    }

    public List<Person> GetEmployees()
    {
        return new()
        {
            new Employee () { FirstName = "Jhonatan", LastName = "Medeiros", Age = 28},
            new Employee () { FirstName = "Peter", LastName = "Parker", Age = 30},
            new Employee () { FirstName = "Vanessa", LastName = "Taylor", Age = 35}
        };
    }

    public List<Person> GetSupervisorsAndEmployees()
    {
        List<Person> person = new();

        person.AddRange(GetEmployees());
        person.AddRange(GetSupervisors());

        return person;
    }
}
