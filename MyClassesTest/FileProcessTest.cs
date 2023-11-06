using MyClasses;

namespace MyClassesTest;

[TestClass]
public class FileProcessTest
{
    [TestMethod]
    public void FileNameDoesExist()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void FileNameDoesNotExist()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void FileNameNullOrEmpty_UsingTryCatch_ShouldReturnThrowArgumentNullException()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void FileNameNullOrEmpty_UsingExpectedExceptionAttribute()
    {
        Assert.Inconclusive();
    }
}