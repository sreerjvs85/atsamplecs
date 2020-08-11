using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using atsamplecs.src.main.at.CommonLibrary;

namespace atsamplecs.src.main.at.pageObjects
{
    public class MyAtPageObjects
    {
        IWebDriver driver;

        public MyAtPageObjects(IWebDriver driver) {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        By TxtWelcomeMessage = By.ClassName("welcome_text");

        public string GetTxtWelcomeMessage() {
            return WebElementFunctions.GetMessage(TxtWelcomeMessage);
        }

    }
}