using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace atsamplecs.src.main.at.BrowserFactory
{
    public class BrowserFunctions
    {
        public static IWebDriver driver;

        public static IWebDriver GetDriver(string browser, string url){
             if(browser.ToLower().Contains("chrome")){
                driver = new ChromeDriver();
             } else {
                driver = new FirefoxDriver();
             }
            driver.Manage().Window.Maximize();
            driver.Url = url;
            return driver;
        }

        public static void QuitDriver(){
            driver.Quit();
        }

    }
}