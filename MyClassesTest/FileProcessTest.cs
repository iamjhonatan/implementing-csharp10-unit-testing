using MyClasses;

namespace MyClassesTest;

[TestClass]
public class FileProcessTest : TestBase
{
    [TestMethod]
    public void FileNameDoesExist()
    {
        // Arrange
        FileProcess fileProcess = new();
        FileName = GetTestSetting<string>("GoodFileName", TestConstants.GOOD_FILE_NAME);
        bool fromCall;

        // Add Messages to Test Output
        FileName = FileName.Replace("[AppDataPath]",
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        WriteOutput($"Checking for File: '{FileName}'.");

        // Create the Good File
        File.AppendAllText(FileName, "Some Text");

        // Act
        fromCall = fileProcess.FileExists(FileName);

        // Delete the Good File if it Exists
        if (File.Exists(FileName))
            File.Delete(FileName);

        // Assert
        Assert.IsTrue(fromCall);
    }

    [TestMethod]
    public void FileNameDoesNotExist()
    {
        // Arrange
        FileProcess fileProcess = new();
        string fileName = GetTestSetting<string>("BadFileName", TestConstants.BAD_FILE_NAME);
        bool fromCall;

        // Add Messages to Test Output
        WriteOutput($"Checking for File: '{fileName}' does NOT exist.");

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
        bool fromCall = false;

        try
        {
            // Act
            fileProcess = new();

            // Add Messages to Test Output
            OutputMessage = GetTestSetting<string>("EmptyFileMsg", TestConstants.EMPTY_FILE_MSG);
            WriteOutput(TestConstants.EMPTY_FILE_MSG);

            fromCall = fileProcess.FileExists(FileName);

            // Assert: Fail as we should not get here
            OutputMessage = GetTestSetting<string>("EmptyFileFailMsg", TestConstants.EMPTY_FILE_FAIL_MSG);
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
        bool fromCall;

        // Add Messages to Test Output
        OutputMessage = GetTestSetting<string>("EmptyFileMsg", TestConstants.EMPTY_FILE_MSG);
        WriteOutput(OutputMessage);

        // Act
        fromCall = fileProcess.FileExists(FileName);

        // Assert: Fail as we should not get here
        OutputMessage = GetTestSetting<string>("EmptyFileFailMsg", TestConstants.EMPTY_FILE_FAIL_MSG);
        Assert.Fail(OutputMessage);
    }
}