using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;

namespace AutomationFramework
{
    [Binding]
    public sealed class SpecflowHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [AfterScenario]
        public static void AfterScenario()
        {
            var testErrorStatus = ScenarioContext.Current.TestError;
            if (testErrorStatus != null)
            {
                Screenshot screenshot = ((ITakesScreenshot)Browser.Current).GetScreenshot();
                var path = System.IO.Path.GetFullPath(@"../ScreenCapture/") + ScenarioContext.Current.ScenarioInfo.Title + "+" + DateTime.Now.ToString("dd-MM-yyyy-- h-mm-ss") + ".jpg";
                screenshot.SaveAsFile(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                Console.WriteLine("Failure Screenshot saved at location {0}", new Uri(path));
            }
        }
    }
}
