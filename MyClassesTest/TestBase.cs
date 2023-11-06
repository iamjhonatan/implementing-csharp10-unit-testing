namespace MyClassesTest;

public class TestBase
{
    public TestContext? TestContext { get; set; }

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
}
