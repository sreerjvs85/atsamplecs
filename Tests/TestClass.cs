using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace atsamplecs.Tests
{
    public class TestClass
    {
        public IWebDriver driver;

        [Test]
        public void FirstTest() {
            
            driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("www.google.com");
            Console.WriteLine("First Test Passed");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TestTearDown() {
            driver.Quit();
        }
    }
}