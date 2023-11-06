namespace MyClassesTest;

internal class TestConstants
{
    public const string GOOD_FILE_NAME = @"C:\Windows\Regedit.exe";
    public const string BAD_FILE_NAME = @"C:\NotExists.txt";
    public const string EMPTY_FILE_FAIL_MSG = @"The Call to the FileExists() method did NOT throw an ArgumentNullException and it should have.";
}
