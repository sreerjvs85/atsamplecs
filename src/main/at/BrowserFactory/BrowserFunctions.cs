using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace atsamplecs.src.main.at.BrowserFactory
{
    public class BrowserFunctions
    {
        public static IWebDriver driver;

        public static IWebDriver GetDriver(string browser, string url){
             if(browser.ToLower().Contains("chrome")){
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Url = url;
                return driver;
             } else {
                 return driver = new ChromeDriver();
             }
        }

        public static void QuitDriver(){
            driver.Quit();
        }

    }
}