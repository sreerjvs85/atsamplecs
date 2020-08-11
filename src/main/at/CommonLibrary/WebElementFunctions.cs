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

        public static void ClickElement(By by) {
            if (IsWebElementPresent(by)) {
                GetWebElement(by).Click();
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

        public static String GetMessage(By by) {
            if (IsWebElementPresent(by)) {
                return GetWebElement(by).GetAttribute("inner-text");
            } else {
                return null;
            }
        }

        public static bool IsWebElementPresent(By by) {
            try{
                if (WaitForElement().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by)).Displayed) {
                    return true;
                }
                return false;
            }catch (ElementNotVisibleException){
                // TakesScreenshot();
                return false;
            }
        }

        public static WebDriverWait WaitForElement(){
            return new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public static void TakesScreenshot() {
            Screenshot screenshot1 = new Screenshot("base64EncodedScreenshot");
            string destFilePath = SetFilePath()+"/"+DateTime.Now.Hour+DateTime.Now.Minute+DateTime.Now.Second;
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