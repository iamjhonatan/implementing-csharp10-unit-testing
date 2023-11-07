
using MyClasses.PersonClasses;

namespace MyClassesTest;

[TestClass]
public class ObjectTypeTest
{
    [TestMethod]
    public void AreNotSameTest()
    {
        Person x = new();
        Person y = new();

        Assert.AreNotSame(x, y);
    }

    [TestMethod]
    public void AreSameTest()
    {
        Person x = new();
        Person y = x;

        Assert.AreSame(x, y);
    }

    [TestMethod]
    public void IsInstanceOfTypeTest()
    {
        Person person1 = new()
        {
            FirstName = "Craig",
            LastName = "Johnson",
        };

        Employee employee1 = new()
        {
            FirstName = "Mike",
            LastName = "Shinoda"
        };

        // person1 is a Person
        Assert.IsInstanceOfType(person1, typeof(Person));
        // person1 is not a Employee
        Assert.IsNotInstanceOfType(person1, typeof(Employee));
        // employee1 is a Person
        Assert.IsInstanceOfType(employee1, typeof(Person));
        // employee1 is a Employee
        Assert.IsInstanceOfType(employee1, typeof(Employee));
        // employee1 is not a Supervisor
        Assert.IsNotInstanceOfType(employee1, typeof(Supervisor));
    }

    [TestMethod]
    public void IsNullTest()
    {
        PersonManager personManager = new();
        Person? per;

        per = personManager.GetPerson(1);

        Assert.IsNull(per);

        per = new()
        {
            FirstName = "Joey",
            LastName = "Jordison"
        };

        Assert.IsNotNull(per);
    }
}
