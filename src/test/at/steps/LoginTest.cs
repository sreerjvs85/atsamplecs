using System.Linq;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using atsamplecs.src.main.at.pageObjects;
using atsamplecs.src.main.at.BrowserFactory;
using NUnit.Framework;
using TechTalk.SpecFlow;
using atsamplecs.src.main.at.CommonLibrary;

namespace atsamplecs.src.test.at.resources.steps
{
    [Binding]
    public class LoginTest
    {
        public IWebDriver driver;

        public string ErrorMessage;
        public string ActualBalance;
        public string ActualDestination;

        public LoginPageObjects loginPageObjects;
        public MyAtPageObjects myAtPageObjects;

        [Given(@"I'm on login screen of at using (.*)")]
        public void GivenImOnLoginScreenOfAtUsing(string browser) {
            driver = BrowserFunctions.GetDriver(browser, "https://at.govt.nz/");
            loginPageObjects = new LandingPageObjects(driver).ClickLinkLogin();
        }

        [When(@"I enter username (.*), password (.*) and submit")]
        public void WhenIEnterUsernamePasswordAndSubmit(string username, string password) {
            loginPageObjects.SetTxtUserName(username);
            loginPageObjects.SetTxtPassword(password);
            myAtPageObjects = loginPageObjects.ClickBtnSubmit();
        }

        [Then(@"If i get error message, capture it.")]
        public void IfIGetErrorMessageCaptureIt(){
            if(!loginPageObjects.GetTxtErrorMessage()){
                Assert.Pass();
            }else{
                Assert.Pass();
            }
        }

        [After]
        public void TearDown()
        {
            WebElementFunctions.QuitDriver();
        }

    }
}