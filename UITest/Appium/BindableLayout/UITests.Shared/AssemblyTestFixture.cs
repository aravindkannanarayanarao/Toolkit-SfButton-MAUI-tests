using NUnit.Framework;
using Syncfusion.UITestHelpers.Appium; 
using Syncfusion.UITestHelpers.Screenshot;
using Syncfusion.UITestHelpers.NUnit;
using Syncfusion.UITestHelpers.ExtendReport; 
using Syncfusion.UITestHelpers.Core;

[assembly: Parallelizable(ParallelScope.Fixtures)]

// SetupFixture runs once for all tests under the same namespace, if placed outside the namespace it will run once for all tests in the assembly
public class AssemblySetupFixture : UITestContextSetupFixture
{
	AppiumServerContext? _appiumServerContext;
	
	public override IConfig GetTestConfig()
	{
		throw new NotImplementedException("This method should not be called. Use the Initialize method instead.");
	}

	public override void Initialize()
	{
		_appiumServerContext = new AppiumServerContext();
		_appiumServerContext.CreateAndStartServer();
		_serverContext = _appiumServerContext;
	}
}