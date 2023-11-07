
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
}
