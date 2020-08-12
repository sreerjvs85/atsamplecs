using System.Xml.Linq;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using atsamplecs.src.main.at.CommonLibrary;


namespace atsamplecs.src.main.at.pageObjects
{
    public class MyTransactionsPageObjects
    {
        IWebDriver driver;

        public MyTransactionsPageObjects(IWebDriver driver) {
            this.driver = driver;
            RetryingElementLocator retryingElementLocator = new RetryingElementLocator(driver, TimeSpan.FromSeconds(30.0));
            PageFactory.InitElements(retryingElementLocator.SearchContext, this);
        }

        By tableTransactions = By.XPath("//table[@class='transactions-table ng-scope']");

        private IList<IWebElement> GetTableTransactions(){
            return WebElementFunctions.GetWebElements(tableTransactions);
        }

        By nextPages = By.XPath("//pagination[@class='hidden-small-dwn ng-isolate-scope']/div[@class='pagination']/div[@class='page ng-scope']");

        private IList<IWebElement> GetNextPages() {
            return WebElementFunctions.GetWebElements(nextPages);
        }

        private string[] Transactions(IWebElement element) {
            string[] transactions;
            transactions = element.Text.Split("\n");
            return transactions;
        }

        public string[] TargettedTransactions(string transaction) {
            string[] targetStringList;
            int index = 0;
            switch (transaction.ToLower()) {
                case "first":
                    index = 0;
                    break;
                case "second":
                    index = 1;
                    break;
                case "third":
                    index = 2;
                    break;
                case "fourth":
                    index = 3;
                    break;
                case "fifth":
                    index = 4;
                    break;
                case "sixth":
                    index = 5;
                    break;
            }
            targetStringList = Transactions(GetTableTransactions()[index]);
            return targetStringList;
        }

        public void NavigateToPage(string page){
            foreach (IWebElement element in GetNextPages()) {
                string nextPageNumber;
                nextPageNumber = element.GetAttribute("inner-text");
                if (nextPageNumber.Equals(page.Substring(page.Length-1))){
                    WebElementFunctions.ClickElement(element);
                }
            }
        }

    }
}