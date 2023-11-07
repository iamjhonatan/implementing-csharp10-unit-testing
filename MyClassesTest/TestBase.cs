namespace MyClassesTest;

public class TestBase
{
    public TestContext? TestContext { get; set; }
	public string OutputMessage { get; set; } = string.Empty;
	public string FileName { get; set; } = string.Empty;

    protected T GetTestSetting<T>(string name, T defaultValue)
    {
        T ret = defaultValue;

		try
		{
			var temp = TestContext?.Properties[name];
			if (temp is not null)
				ret = (T)Convert.ChangeType(temp, typeof(T));
		}
		catch (Exception)
		{
			// Ignore exception, return the defaultValue
		}

		return ret;
    }

	protected void WriteOutput(string output)
	{
		TestContext?.WriteLine(output);
    }

    #region GetTestName Method
	protected string GetTestName()
	{
		var ret = TestContext?.TestName;
		if (ret is null)
			return string.Empty;
		else
			return ret.ToString();
	}
    #endregion

    #region GetFileName Method
	protected string GetFileName(string name, string defaultValue)
	{
		string fileName = GetTestSetting<string>(name, defaultValue);
		fileName = fileName.Replace("[AppDataPath]",
			Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

		return fileName;
	}
    #endregion
}
