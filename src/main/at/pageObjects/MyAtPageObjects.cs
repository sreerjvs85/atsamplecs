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

        By txtWelcomeMessage = By.ClassName("welcome_text");
        By btnViewTransactions = By.LinkText("View transactions");
        By txtMyAtBalance = By.XPath("//span[@class='default-hop-balance']");
        By lnkLogout = By.LinkText("Log out");

        public string GetTxtWelcomeMessage() {
            return WebElementFunctions.GetMessage(txtWelcomeMessage);
        }

        public bool IsElementWelcomeMessageVisible(){
            return WebElementFunctions.IsWebElementPresent(txtWelcomeMessage);
        }

        public string GetMyAtBalance () {
            return WebElementFunctions.GetMessage(txtMyAtBalance);
        }

        public void ClickLinkLogout(){
            WebElementFunctions.ClickElement(lnkLogout);
        }

        public MyTransactionsPageObjects ClickBtnViewTransactions(){
            WebElementFunctions.ClickElement(btnViewTransactions);
            return new MyTransactionsPageObjects(driver);
        }

    }
}