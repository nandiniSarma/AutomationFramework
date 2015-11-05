using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationFramework
{
    public class BrowserUtility
    {
        //Wait for a minute for the page to load and the javascript ready state of the page to go to ready.
        public static void WaitForPageToLoad()
        {
            var scriptExecutor = (IJavaScriptExecutor)Browser.Current;
            WebDriverWait wait = new WebDriverWait(Browser.Current, TimeSpan.FromSeconds(60));
            wait.Until(driver1 => scriptExecutor.ExecuteScript("return document.readyState").Equals("complete"));
        }

        internal static List<IWebElement> GetElementCollection(By headlineCollection)
        {
            List<IWebElement> collection = new List<IWebElement>();
            try
            {
                var obj = Browser.Current.FindElements(headlineCollection);
                collection = new List<IWebElement>(obj);
                return collection;
            }
            catch(Exception e)
            {
                throw new Exception("Unable to find collection with expected identifier: " + headlineCollection + "<pre>" + e.StackTrace + "</pre>");
            }
        }
    }
}
