using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace XUnitTestSelenium
{
    public class FirstTests
    {
        [Fact]
        public void TestStackOverFlowSearch()
        {
            //arrange
            IWebDriver driver = new ChromeDriver(); //driver creation
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //add more timeout to find an element when some page take slow to load
            try
            {
                //act
                driver.Navigate().GoToUrl("https://www.google.com");

                driver.FindElement(By.XPath("//input[@class='gLFyf gsfi']")).SendKeys("StackOverflow");

                driver.FindElement(By.XPath("//input[@value='Pesquisa Google']")).Click();

                var link = driver.FindElement(By.XPath("//a[@href='https://pt.stackoverflow.com/']"));

                //assert
                Assert.NotNull(link);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //finalize test
                TeardownTest(driver);
            }
           
        }

        
        private void TeardownTest(IWebDriver pDriver)
        {
            try
            {
                pDriver.Quit();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
