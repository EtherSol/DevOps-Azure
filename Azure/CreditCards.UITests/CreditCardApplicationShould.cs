using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CreditCards.UITests
{
    /*
    In this file are Application Tests for each functions. Automated Application Tests are used for functions:
    BeInitiatedFromHomePage_NewLowRate(), BeInitiatedFromHomePage_EasyApplication(). 
    
    In this test, web inspect is needed to use the names, ids from the html code.
    
    Selenium is needed to run variables with IWebDriver, 
    Xunit extension is needed for [Fact],[Traits]
    */
    [Trait("Category", "Applications")]
    public class CreditCardApplicationShould

    {
        private const string HomeUrl = "http://localhost:5258/";
        private const string ApplyUrl = "http://localhost:5258/Apply";

        [Fact]
        public void BeInitiatedFromHomePage_NewLowRate()
        /*
        The variable 'driver' uses Selenium's Environment to create an automated Chrome Driver.

        This Application function tests if there is no internal problems with the onClick of the page.
        The new page's title should match with the driver's title to pass.

        This test will fail if variable ApplyUrl does not match with the driver's Url
        */

        {

            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();

                IWebElement applyLink = driver.FindElement(By.Name("ApplyLowRate"));
                applyLink.Click();

                DemoHelper.Pause();

                // Passes if the string and ApplyUrl matches with Chrome driver's Title and Url
                Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
                Assert.Equal(ApplyUrl, driver.Url);

            }
        }

        [Fact]
        public void BeInitiatedFromHomePage_EasyApplication()
        /*
        The variable 'bestDriver' uses Selenium's Environment to create an automated Chrome Driver.

        This Application function tests if there is no internal problems with the onClick of the page while
        on the carousel. The new page's title should match with the driver's title to pass.

        This test will fail if the carousel isn't switch intime for the test. This will cause the test to fail.
        A way to counter the problem is to have the page to wait 11 seconds with DemoHelper.Pause(11000)
        */
        {
            using (IWebDriver bestDriver = new ChromeDriver())
            {
                bestDriver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause(11000);

                IWebElement applyLink = bestDriver.FindElement(By.LinkText("Easy: Apply Now!"));
                applyLink.Click();

                DemoHelper.Pause();

                // Passes if the string and ApplyUrl matches with Chrome driver's Title and Url
                Assert.Equal("Credit Card Application - Credit Cards", bestDriver.Title);
                Assert.Equal(ApplyUrl, bestDriver.Url);
            }
        }
    }
}