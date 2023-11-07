
namespace MyClassesTest;

[TestClass]
public class AssemblyInitCleanup
{
    [AssemblyInitialize()]
    public static void AssemblyInitialize(TestContext testContext)
    {
        // This code runs once before all tests in this assembly
        testContext.WriteLine("In MyClassesTest.AssemblyInitCleanup.Assembly");
    }

    [AssemblyCleanup()]
    public static void AssemblyCleanup()
    {
        // This code runs once after all tests have run in this assembly
        // NOTE: TestContext is not available in here
    }
}
