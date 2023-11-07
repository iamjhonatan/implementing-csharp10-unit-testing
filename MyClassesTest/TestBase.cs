using System.Reflection;

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

    #region GetAttribute Method
	protected T? GetAttribute<T>(Type typ)
	{
		// Get the currently executing test name
		string testName = GetTestName();

		// Retrieve the <TAttr> attribute if it exists
		Attribute? attr = typ.GetMethod(testName)?
			.GetCustomAttribute(typeof(T));

		if (attr is not null)
		{
			// Cast the attribute to a <TAttr> type
			return (T)Convert.ChangeType(attr, typeof(T));
		}
		else
		{
			return default;
		}
	}
    #endregion

    #region WriteDescription Method
	protected void WriteDescription(Type typ)
	{
		// Retrieve the [Description] attribute if it exists
		DescriptionAttribute? attr = GetAttribute<DescriptionAttribute>(typ);

		if (attr is not null)
		{
			// Output the test description
			TestContext?.Write($" Test Purpose: {attr.Description}.");
		}
	}
    #endregion

    #region WriteOwner Method
	protected void WriteOwner(Type typ)
	{
		// Retrieve the [Owner] attribute if it exists
		OwnerAttribute? attr = GetAttribute<OwnerAttribute>(typ);

		if (attr is not null)
		{
			// Output the test owner
			TestContext?.WriteLine($"\nTest Owner: {attr.Owner}.");
		}
	}
    #endregion
}
