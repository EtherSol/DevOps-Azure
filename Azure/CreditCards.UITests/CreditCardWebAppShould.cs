using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CreditCards.UITests
{

    public class CreditCardWebAppShould
    {
        private const string HomeUrl = "http://localhost:5258/";
        private const string AboutUrl = "http://localhost:5258/Home/About";
        private const string HomeTitle = "Home Page - Credit Cards";


        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadApplicationPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                // driver.Navigate().GoToUrl(HomeUrl);

                DemoHelper.Pause();

                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {

                // driver.Navigate().GoToUrl(HomeUrl);

                DemoHelper.Pause();

                // driver.Navigate().Refresh();

                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePageOnBack()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                IWebElement generationTokenElement =
                    driver.FindElement(By.Id("GenerationToken"));
                string initialToken = generationTokenElement.Text;
                DemoHelper.Pause();
                driver.Navigate().GoToUrl(AboutUrl);
                DemoHelper.Pause();
                driver.Navigate().Back();
                DemoHelper.Pause();

                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);

                string reloadedToken = driver.FindElement(By.Id("GenerationToken")).Text;
                Assert.NotEqual(initialToken, reloadedToken);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]

        public void ReloadHomePageForward()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(AboutUrl);
                DemoHelper.Pause();
                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();
                driver.Navigate().Forward();
                DemoHelper.Pause();

                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);
            }
        }
    }
};