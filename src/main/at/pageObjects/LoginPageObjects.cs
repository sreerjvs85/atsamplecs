using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using atsamplecs.src.main.at.CommonLibrary;

namespace atsamplecs.src.main.at.pageObjects
{
    public class LoginPageObjects
    {
        IWebDriver driver;

        public LoginPageObjects(IWebDriver driver) {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        By TxtUserName = By.Name("UserName");
        By TxtPassword = By.Name("Password");
        By BtnSubmit = By.XPath("//span[@id='submitButton']");
        By TxtErrorMessage = By.ClassName("loginErrMsg");

        public void SetTxtUserName(string username)
        {
            WebElementFunctions.FillField(TxtUserName ,username);
        }

        public void SetTxtPassword(string password)
        {
            WebElementFunctions.FillField(TxtPassword, password);
        }
        public MyAtPageObjects ClickBtnSubmit()
        {
            WebElementFunctions.ClickElement(BtnSubmit);
            return new MyAtPageObjects(driver);
        }

        public bool IsElementErrorMessageVisible(){
            return WebElementFunctions.IsWebElementPresent(TxtErrorMessage);
        }
    
    }
}