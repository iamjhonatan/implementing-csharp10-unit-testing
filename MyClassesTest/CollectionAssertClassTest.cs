
using MyClasses.PersonClasses;

namespace MyClassesTest;

[TestClass]
public class CollectionAssertClassTest
{
    [TestMethod]
    public void AreCollectionsEqualTestNumbers()
    {
        List<int> expected = new() { 1, 2, 3, 4 };
        List<int> actual = new() { 1, 2, 3, 4 };

        // Compares each item in the two collections
        // to see if they are equal
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AreCollectionsEqualTest() 
    {
        PersonManager pmg = new();
        List<Person> expected;
        List<Person> actual;

        actual = pmg.GetPeople();
        expected = actual;

        /*
         * Compares each item in the two collections
         * to see if they are equal
         * ie. they refer to the same object
         */
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AreCollectionsNotEqual()
    {
        PersonManager pmg = new();
        List<Person> expected = new();
        List<Person> actual;

        expected.Add(new Person() { FirstName = "Jon", LastName = "Jones" });
        expected.Add(new Person() { FirstName = "Rob", LastName = "Lawler" });
        expected.Add(new Person() { FirstName = "Mike", LastName = "Stepario" });

        actual = pmg.GetPeople();

        /*
         * Compares each item in the two collections
         * to see if they are equal
         * ie. they refer to the same object
         */
        CollectionAssert.AreNotEqual(expected, actual);
    }

    [TestMethod]
    public void AreCollectionsEquivalentTest()
    {
        PersonManager pmg = new();
        List<Person> expected = new();
        List<Person> actual;

        // Get collection of people
        actual = pmg.GetPeople();

        // Add same Person objects to new collection
        // but in a diferent order
        expected.Add(actual[1]);
        expected.Add(actual[2]);
        expected.Add(actual[0]);

        // Checks for same objects, buut in any order
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [TestMethod]
    public void AreCollectionsEqualWithComparerTest() 
    {
        PersonManager pmg = new();
        List<Person> expected = new();
        List<Person> actual;

        // Get collection of people
        actual = pmg.GetPeople();

        // Create same exact objects as those returned
        // from the pmg.GetProple method
        expected.Add(new Person() { FirstName = "Jhonatan", LastName = "Medeiros", Age = 28 });
        expected.Add(new Person() { FirstName = "Peter", LastName = "Parker", Age = 30 });
        expected.Add(new Person() { FirstName = "Jay", LastName = "Weinberg", Age = 33 });

        // Add an anonymous Comparer method to determine equality
        CollectionAssert.AreEqual(expected, actual,
            Comparer<Person>.Create((x, y) =>
                x.FirstName == y.FirstName &&
                x.LastName == y.LastName && 
                x.Age == y.Age ? 0 : 1));
    }

    [TestMethod]
    public void IsCollectionOfTypeTest()
    {
        PersonManager pmg = new();
        List<Person> actual;

        actual = pmg.GetSupervisors();

        // Check if all objects in the collection
        // are of the type Supervisor
        CollectionAssert.AllItemsAreInstancesOfType(actual, typeof(Supervisor));
    }
}
