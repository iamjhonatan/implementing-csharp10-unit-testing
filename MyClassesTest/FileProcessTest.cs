using MyClasses;

namespace MyClassesTest;

[TestClass]
public class FileProcessTest
{
    [TestMethod]
    public void FileNameDoesExist()
    {
        // Arrange
        FileProcess fileProcess = new();
        string fileName = @"C:\Windows\Regedit.exe";
        bool fromCall;

        // Act
        fromCall = fileProcess.FileExists(fileName);

        // Assert
        Assert.IsTrue(fromCall);
    }

    [TestMethod]
    public void FileNameDoesNotExist()
    {
        // Arrange
        FileProcess fileProcess = new();
        string fileName = @"C:\DoesNotExist.txt";
        bool fromCall;

        // Act
        fromCall = fileProcess.FileExists(fileName);

        // Assert
        Assert.IsFalse(fromCall);
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