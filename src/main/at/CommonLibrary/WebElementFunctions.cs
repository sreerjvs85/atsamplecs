using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;
using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SeleniumExtras.PageObjects;


namespace atsamplecs.src.main.at.CommonLibrary
{
    public class WebElementFunctions : BrowserFactory.BrowserFunctions
    {

        public static double waitForElementTimeout = 30.0;

        public static void ClickElement(By by) {
            if (IsWebElementPresent(by)) {
                GetWebElement(by).Click();
            }
        }

        public static void ClickElement(IWebElement element) {
            if (IsWebElementPresent(element)) {
                element.Click();
            }
        }

        public static void FillField(By by, string str) {
            if (IsWebElementPresent(by)){
                GetWebElement(by).SendKeys(str);
            }
        }

        public static IWebElement GetWebElement(By by) {
            return driver.FindElement(by);
        }

        public static IList<IWebElement> GetWebElements (By by){
            if (IsWebElementPresent(by)) {
                return driver.FindElements(by).ToArray();
            } else
            {
                return null;
            }
        }

        public static String GetMessage(By by) {
            if (IsWebElementPresent(by)) {
                return GetWebElement(by).GetAttribute("inner-text");
            } else {
                return null;
            }
        }

        public static bool IsWebElementPresent(By by) {
            try{
                IWebElement element = WaitForElement().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return element.Displayed;
            }catch (ElementNotVisibleException){
                TakesScreenshot(driver);
                return false;
            }
        }

        public static bool IsWebElementPresent(IWebElement element) {
            try{
                WaitForElement().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(element));
                return element.Displayed;
            }catch (ElementNotVisibleException){
                TakesScreenshot(driver);
                return false;
            }
        }
        public static WebDriverWait WaitForElement(){
            return new WebDriverWait(driver, TimeSpan.FromSeconds(waitForElementTimeout));
        }

        //public static void TakesScreenshot() {
        //    Screenshot screenshot1 = new Screenshot("base64EncodedScreenshot");
        //    string destFilePath = SetFilePath()+"/"+DateTime.Now.Hour+DateTime.Now.Minute+DateTime.Now.Second;
        //    screenshot1.SaveAsFile(destFilePath, ScreenshotImageFormat.Jpeg);
        //}

        public static void TakesScreenshot(IWebDriver driver) {
            ITakesScreenshot screenshot = (ITakesScreenshot) driver;
            Screenshot screenshot1 = screenshot.GetScreenshot();
            string destFilePath = SetFilePath() + "/" + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            screenshot1.SaveAsFile(destFilePath, ScreenshotImageFormat.Jpeg);

        }

    private static string SetFilePath(){
            string path = "../../../test/at/";
            string screenshotsFolder = path +"screenshots/";
            string todayFolder = screenshotsFolder + DateTime.Today.Year +"/" + DateTime.Today.Month+"/"+DateTime.Today.Date;
            try {if (!Directory.Exists(todayFolder)) {
                Directory.CreateDirectory(todayFolder);
            }} catch (Exception e){
                Console.WriteLine(e.ToString());
            }
            return todayFolder;
        }
    }
}