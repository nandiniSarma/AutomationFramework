using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using FluentAssertions;
using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;

namespace AutomationFramework
{
    [Binding]
    public sealed class StepDefinitions
    {
        GooglePage googlePage = new GooglePage();


        [Given(@"I launch the home page for '(.*)'")]
        public void GivenILaunchTheHomePageFor(string webPage)
        {
            string url = string.Empty;
            switch(webPage.ToLower())
            {
                case "google news":
                    url = ConfigurationManager.AppSettings["Google News"];
                    break;
                case "yahoo news":
                    url = ConfigurationManager.AppSettings["Yahoo News"];
                    break;
            }

            //Validate the input passed has been handled by the switch clause.
            url.Should().NotBeNullOrEmpty();

            //Clear cache and cookies
            Browser.Current.Manage().Cookies.DeleteAllCookies();
                        
            //Navigate to WebPage
            Browser.Current.Navigate().GoToUrl(url);
            Browser.Current.Manage().Window.Maximize(); 
            BrowserUtility.WaitForPageToLoad();
        }

        [When(@"I retrieve all the headlines for the day")]
        public void WhenIRetrieveAllTheHeadlinesForTheDay()
        {
            googlePage.GetHeadlinesForTheDay();
        }
    }
}
