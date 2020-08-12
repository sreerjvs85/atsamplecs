using System.Runtime.InteropServices;
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
        public MyTransactionsPageObjects myTransactionsPageObjects;

        [Given(@"I'm on login screen of at using (.*)")]
        public void GivenImOnLoginScreenOfAtUsing(string browser) {
            Console.WriteLine("****************************");
            Console.WriteLine("TC Started: "+ DateTime.Now);
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
        public void ThenIfIGetErrorMessageCaptureIt(){
            if (myAtPageObjects.GetTxtWelcomeMessage().Contains("Sreevathsan")) {
                Console.WriteLine("Login Success");
                Assert.Pass();
            } else { 
                Console.WriteLine("Login failed");
                Assert.Fail();
            }
        }

        [Then(@"I click on View Transactions button to see all my previous travels")]
        public void ThenIClickOnViewTransactionsButtonToSeeAllMyPreviousTravels(){
            myTransactionsPageObjects = myAtPageObjects.ClickBtnViewTransactions();
        }

        [Then(@"Verify the (.*) details like tag on, tag off and hop balance")]
        public void ThenVerifyTheDetailsLikeTagOnTagOffAndHopBalance(string transaction){
            string[] transactions = myTransactionsPageObjects.TargettedTransactions(transaction);
            double hopBalance = 0, previousBalance = 0, debit = 0, credit = 0;
            string destination = null, source = null, journeyDate = null;
            int totalJourneys = 0;
            int destStartIndex = 10, destEndIndex = 35, srcStartIndex = 9, srcEndIndexRef = 34, srcEndIndex = 19,
                    autoStartIndex = 14, autoEndIndex = 22;

            foreach (string str in transactions) {
            int index = str.LastIndexOf("$");
            if (index<0 && !str.StartsWith("Tag")) {
                journeyDate = str;
            }
            if (index>0 && str.StartsWith("Tag off")) {
                hopBalance = Double.Parse(str.Substring(index+1));
                index = str.IndexOf("$");
                debit = Double.Parse(str.Substring(str.IndexOf("$") + 1, str.LastIndexOf("$") - 2 - str.IndexOf("$")));
                destination = str.Substring(destStartIndex,str.Length-destEndIndex);
            }
            if (index >0 && str.StartsWith("Tag on")) {
                if (str.Contains("refund")) {
                    source = str.Substring(srcStartIndex, str.Length - srcEndIndexRef - srcStartIndex);
                } else {
                    source = str.Substring(srcStartIndex, str.Length - srcEndIndex - srcStartIndex);
                }
                previousBalance = Double.Parse(str.Substring(index + 1));
                totalJourneys++;
                Assert.AreEqual(hopBalance, Math.Round((previousBalance - debit),2));
            }
            if (str.StartsWith("Auto")) {
                source = destination = str.Substring(autoStartIndex, str.Length-autoEndIndex-autoStartIndex);
                hopBalance = Double.Parse(str.Substring(index+1));
                index = str.IndexOf("$");
                credit = Double.Parse(str.Substring(str.IndexOf("$") + 1, str.Length - str.LastIndexOf("$") - 1));
                  Assert.AreEqual(hopBalance, previousBalance);
            }
            if (source!= null && destination!= null) {
                Console.WriteLine("Journey date: " + journeyDate
                        + " Hop Balance: " + hopBalance
                        + " Debit: " + debit
                        + " Credit: " + credit
                        + " Previous Balance: " + previousBalance
                        + " Source: " + source
                        + " Destination: " + destination
                        + " Total journeys: " + totalJourneys);
                source=destination=null;
                debit=credit=0;
            }
            }
        }

        [Then("Verify the (.*) details like tag on, tag off and hop balance on (.*)")]
        public void ThenVerifyTheDetailsLikeTagOnTagOffAndHopBalanceOn(string transaction, string page){
            myTransactionsPageObjects.NavigateToPage(page);
            ThenVerifyTheDetailsLikeTagOnTagOffAndHopBalance(transaction);
        }

        [After]
        public void TearDown()
        {
            myAtPageObjects.ClickLinkLogout();
            WebElementFunctions.QuitDriver();
            Console.WriteLine("TC Stopped: "+ DateTime.Now);
            Console.WriteLine("****************************");
        }

    }
}