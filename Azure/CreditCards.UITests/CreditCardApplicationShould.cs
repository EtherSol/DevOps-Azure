using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CreditCards.UITests
{
    [Trait("Category", "Applications")]
    public class CreditCardApplicationShould
    {
        private const string HomeUrl = "http://localhost:5258/";
        private const string ApplyUrl = "http://localhost:5258/Apply";

        [Fact]
        public void BeInitiatedFromHomePage_NewLowRate()
        {

            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();

                IWebElement applyLink = driver.FindElement(By.Name("ApplyLowRate"));
                applyLink.Click();

                DemoHelper.Pause();

                Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
                Assert.Equal(ApplyUrl, driver.Url);

            }
        }
    }
}