using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using FluentAssertions;

namespace AutomationFramework
{
    class GooglePage
    {
        //Page Objects for the google Page Class
        public static By headlineCollection = By.ClassName("esc-lead-article-title");

        internal void GetHeadlinesForTheDay()
        {
            var headlinesCollectionObj = BrowserUtility.GetElementCollection(headlineCollection);
            headlinesCollectionObj.Should().NotBeNull();

            Console.WriteLine("Headlines Displayed today on google are: ");
            foreach(var headline in headlinesCollectionObj)
            {
                Console.WriteLine(headline.Text);
            }
        }
    }
}
