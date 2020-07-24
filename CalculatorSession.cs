//******************************************************************************
//Calculator Initialization
//******************************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace CalculatorTest
{
	public class CalculatorSession
	{
		// Declaration
		private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
		private const string CalculatorAppId = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";

		protected static WindowsDriver<WindowsElement> session;

		public static void Setup(TestContext context)
		{
			// Launch Calculator application if it is not yet launched
			if (session == null)
			{
				// Create a new session to bring up an instance of the Calculator application
				// Note: Multiple calculator windows (instances) share the same process Id
				AppiumOptions options = new AppiumOptions();
				options.AddAdditionalCapability("deviceName", "WindowsPC");
				options.AddAdditionalCapability("platformName", "Windows");
				options.AddAdditionalCapability("app", CalculatorAppId);

				session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), options);
				Assert.IsNotNull(session);

				// Set implicit timeout to 1.5 seconds to make element search to retry every 500 ms for at most three times
				session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
			}
		}

		public static void TearDown()
		{
			// Close the application and delete the session
			if (session != null)
			{
				session.Quit();
				session = null;
			}
		}
	}
}
