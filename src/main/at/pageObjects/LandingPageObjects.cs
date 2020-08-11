using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using atsamplecs.src.main.at.CommonLibrary;

namespace atsamplecs.src.main.at.pageObjects
{
    public class LandingPageObjects
    {
        private IWebDriver driver;

        public LandingPageObjects(IWebDriver driver) {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        By linkLogin = By.LinkText("Log in");

        public LoginPageObjects ClickLinkLogin() {
            WebElementFunctions.ClickElement(linkLogin);
            return new LoginPageObjects(driver);
        }

    }
}