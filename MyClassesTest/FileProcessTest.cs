using MyClasses;

namespace MyClassesTest;

[TestClass]
public class FileProcessTest
{
    public TestContext? TestContext { get; set; }

    [TestMethod]
    public void FileNameDoesExist()
    {
        // Arrange
        FileProcess fileProcess = new();
        string fileName = TestContext?.Properties?["GoodFileName"]?.ToString() ?? TestConstants.GOOD_FILE_NAME;
        bool fromCall;

        // Add Messages to Test Output
        TestContext?.WriteLine($"Checking for File: '{fileName}'.");

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
        string fileName = TestContext?.Properties?["BadFileName"]?.ToString() ?? TestConstants.BAD_FILE_NAME;
        bool fromCall;

        // Add Messages to Test Output
        TestContext?.WriteLine($"Checking for File: '{fileName}' does NOT exist.");

        // Act
        fromCall = fileProcess.FileExists(fileName);

        // Assert
        Assert.IsFalse(fromCall);
    }

    [TestMethod]
    public void FileNameNullOrEmpty_UsingTryCatch_ShouldReturnThrowArgumentNullException()
    {
        // Arrange
        FileProcess fileProcess;
        string fileName = string.Empty;
        bool fromCall = false;
        string OutputMessage;

        try
        {
            // Act
            fileProcess = new();

            // Add Messages to Test Output
            OutputMessage = TestContext?.Properties?["EmptyFileMsg"]?.ToString() ?? TestConstants.EMPTY_FILE_MSG;
            TestContext?.WriteLine(TestConstants.EMPTY_FILE_MSG);

            fromCall = fileProcess.FileExists(fileName);

            // Assert: Fail as we should not get here
            OutputMessage = TestContext?.Properties?["EmptyFileFailMsg"]?.ToString() ?? TestConstants.EMPTY_FILE_FAIL_MSG;
            Assert.Fail(OutputMessage);
        }
        catch (ArgumentNullException) 
        {
            // Assert: Test was a success
            Assert.IsFalse(fromCall);
        }
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void FileNameNullOrEmpty_UsingExpectedExceptionAttribute()
    {
        // Arrange
        FileProcess fileProcess = new();
        string fileName = string.Empty;
        bool fromCall;
        string OutputMessage;

        // Add Messages to Test Output
        OutputMessage = TestContext?.Properties?["EmptyFileMsg"]?.ToString() ?? TestConstants.EMPTY_FILE_MSG;
        TestContext?.WriteLine(OutputMessage);

        // Act
        fromCall = fileProcess.FileExists(fileName);

        // Assert: Fail as we should not get here
        OutputMessage = TestContext?.Properties?["EmptyFileFailMsg"]?.ToString() ?? TestConstants.EMPTY_FILE_FAIL_MSG;
        Assert.Fail(OutputMessage);
    }
}