using MyClasses;

namespace MyClassesTest;

[TestClass]
public class FileProcessTest : TestBase
{
    #region Class Initialize and Cleanup Methods
    [ClassInitialize()]
    public static void ClassInitialize(TestContext testContext)
    {
        // This code runs once before all tests run in this class
        testContext.WriteLine("In FileProcessTest.ClassInitialize() method");
    }

    [ClassCleanup()]
    public static void ClassCleanup()
    {
        // This code runs once after all tests in this class have run
        // NOTE: TestContext is not available here
    }
    #endregion

    #region Test Initialize and Cleanup Methods
    [TestInitialize()]
    public void TestInitialize()
    {
        WriteOutput("in FileProcessTest.TestInitialize() method");
        WriteDescription(GetType());
        WriteOwner(GetType());

        // Check to see which test we are running
        if (GetTestName().Equals("FileNameDoesExist"))
        {
            // Get Good File Name
            string fileName = GetFileName("GoodFileName", TestConstants.GOOD_FILE_NAME);

            // Create the Good File
            File.AppendAllText(fileName, "Some Text");
        }
    }

    [TestCleanup()]
    public void TestCleanup()
    {
        // Check to see which test we are running
        if (GetTestName().Equals("FileNameDoesExist"))
        {
            // Get Good File Name
            string fileName = GetFileName("GoodFileName", TestConstants.GOOD_FILE_NAME);

            // Delete the Good File if it Exists
            if (File.Exists(fileName))
                File.Delete(fileName);
        }
    }
    #endregion

    [TestMethod]
    [Ignore]
    [Timeout(3000)]
    public void SimulateTimeout()
    {
        Thread.Sleep(4000);    
    }

    [TestMethod]
    [DeploymentItem("FileToDeploy.txt")]
    [Description("Check to see if a file exists using the [DeploymentItem] attribute.")]
    [Owner("JhonatanM")]
    [Priority(3)]
    [TestCategory("NoException")]
    public void FileNameDoesExistUsingDeploymentItem()
    {
        // Arrange
        FileProcess fileProcess = new();
        FileName = "FileToDeploy.txt";
        bool fromCall;

        // Add Messages to Test Output
        WriteOutput($"Checking for File: '{FileName}' in folder '{TestContext?.DeploymentDirectory}'");

        // Act
        fromCall = fileProcess.FileExists(FileName);

        // Assert
        Assert.IsTrue(fromCall, "File {0} does NOT exist.", FileName);
    }

    [TestMethod]
    [DeploymentItem("FileDataRow.txt")]
    [DeploymentItem("FileDataRow2.txt")]
    [DataRow("FileDataRow.txt")]
    [DataRow("FileDataRow2.txt")]
    [Description("Check to see if a file exists using the [DataRow] attribute.")]
    [Owner("JhonatanM")]
    [Priority(3)]
    [TestCategory("NoException")]
    public void FileNameDoesExistUsingDataRow(string fileName)
    {
        // Arrange
        FileProcess fileProcess = new();
        bool fromCall;

        // Add Messages to Test Output
        WriteOutput($"Checking for File: '{fileName}' in folder '{TestContext?.DeploymentDirectory}'");

        // Act
        fromCall = fileProcess.FileExists(fileName);

        // Assert
        Assert.IsTrue(fromCall, "File {0} does NOT exist.", fileName);
    }

    [TestMethod]
    [DeploymentItem("FileDynamic.txt")]
    [DeploymentItem("FileDynamic2.txt")]
    [DynamicData("FileNames", typeof(TestData), DynamicDataSourceType.Method)]
    [Description("Check to see if a file exists using the [DynamicData] attribute.")]
    [Owner("JhonatanM")]
    [Priority(3)]
    [TestCategory("NoException")]
    public void FileNameDoesExistUsingDynamicData(string fileName)
    {
        // Arrange
        FileProcess fileProcess = new();
        bool fromCall;

        // Add Messages to Test Output
        WriteOutput($"Checking for File: '{fileName}' in folder '{TestContext?.DeploymentDirectory}'");

        // Act
        fromCall = fileProcess.FileExists(fileName);

        // Assert
        Assert.IsTrue(fromCall, "File {0} does NOT exist.", fileName);
    }

    [TestMethod]
    [Description("Check to see if a file exists")]
    [Owner("JhonatanM")]
    [Priority(3)]
    [TestCategory("NoException")]
    public void FileNameDoesExist()
    {
        // Arrange
        FileProcess fileProcess = new();
        FileName = GetFileName("GoodFileName", TestConstants.GOOD_FILE_NAME);
        bool fromCall;

        // Add Messages to Test Output
        WriteOutput($"Checking for File: '{FileName}'.");

        // Act
        fromCall = fileProcess.FileExists(FileName);

        // Assert
        Assert.IsTrue(fromCall, "File {0} does NOT exist.", FileName);
    }

    [TestMethod]
    [Description("Check to see if file does not exist")]
    [Owner("JhonatanM")]
    [Priority(3)]
    [TestCategory("NoException")]
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
    [Description("Check for a thrown ArgumentNullException using ExpectedException")]
    [Owner("JhonatanM")]
    [Priority(2)]
    [TestCategory("Exception")]
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
    [Description("Check for a thrown ArgumentNullException using ExpectedException")]
    [ExpectedException(typeof(ArgumentNullException))]
    [Owner("JhonatanM")]
    [Priority(1)]
    [TestCategory("Exception")]
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