using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace XUnitTestSelenium
{
    public class FirstTests
    {
        [Fact]
        public void Test1()
        {
            //arrange
            IWebDriver driver = new ChromeDriver();
            try
            {
                //act
                driver.Navigate().GoToUrl("https://www.google.com");

                driver.FindElement(By.XPath("//input[@class='gLFyf gsfi']")).SendKeys("StackOverflow");

                driver.FindElement(By.XPath("//input[@value='Pesquisa Google']")).Click();

                var link = driver.FindElement(By.XPath("//a[@href='https://pt.stackoverflow.com/']"));

                //assert
                Assert.NotNull(link);

                //finalize test
                TeardownTest(driver);
            }
            catch (Exception)
            {
                TeardownTest(driver);
                throw;
            }
           
        }

        public void TeardownTest(IWebDriver pDriver)
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
