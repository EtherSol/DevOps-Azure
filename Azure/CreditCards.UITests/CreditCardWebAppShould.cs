using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CreditCards.UITests
{
    /*
    Welcome to the Test code for CreditCards.csproj ! 🌟🌟

    In this file are Smoke Tests for each functions. Automated Smoke Tests are used for functions:
    LoadApplicationPage(), ReloadHomePages(), ReloadHomePageOnBack(), ReloadHomePageForward()

    Selenium is needed to run variables with IWebDriver, 
    Xunit extension is needed for [Fact],[Traits]
    */
    public class CreditCardWebAppShould
    {
        private const string HomeUrl = "http://localhost:5258/";
        private const string AboutUrl = "http://localhost:5258/Home/About";
        private const string HomeTitle = "Home Page - Credit Cards";


        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadApplicationPage()
        /*
        The variable 'driver' uses Selenium's Environment to create an automated Chrome Driver.

        This Smoke function tests if variable 'HomeTitle' and 'HomeUrl'
        matches with the 'driver' variables. The Smoke test will fail if your C# environment within
        VSCode is not running/set up properly with .NET v2.1, Xunit, or Selenium.

        DemoHelper function has been called from /CreditCards.UITests/DemoHelper.cs to give the 
        code reviewer a 3 second glance of the test. If not used, then the automated test will 
        quickly test the code.
        */
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);

                DemoHelper.Pause();

                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePage()
        /*
        The variable 'driver' uses Selenium's Environment to create an automated Chrome Driver.

        This Smoke function tests if variable 'HomeTitle' and 'HomeUrl'
        matches with the 'driver' variables. Test will fail if the page does not reload. If page 
        doesn't reload, the HomeUrl and HomeTitle variable would not match with the driver. Thus,
        causing the Assert to throw a failed test.

        This test will fail, since I did not allow the driver to go to the HomeUrl.
        */
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
        /*
        The variable 'driver' uses Selenium's Environment to create an automated Chrome Driver.

        This Smoke function tests if variable 'HomeTitle' and 'HomeUrl'
        matches with the 'driver' variables

        DemoHelper function has been called from /CreditCards.UITests/DemoHelper.cs to give the 
        code reviewer a 3 second glance of the test. If not used, then the automated test will 
        quickly test the code.
        */
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