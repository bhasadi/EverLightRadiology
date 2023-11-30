using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System.Reflection;

namespace CommonFeatures
{
    public static class SeleniumBrowserExtension
    {
        //######################################################################################################################
        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        public static void BrowerWaitForReadyState(IWebDriver driver)
        {
            WebDriverWait driverWaitObj = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driverWaitObj.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }//BrowerWaitForReadyState

        //######################################################################################################################
        /// <summary>
        /// 
        /// </summary>
        /// <param name="browserType"></param>
        /// <returns></returns>
        public static IWebDriver GetBrowserObject(string browserType)
        {
            IWebDriver webDriver = null;
            string webDriverfolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            switch (browserType.ToLower())
            {
                case "firefox":
                    //brsObject = new FirefoxDriver();
                    break;

                case "edge":
                    webDriver = new EdgeDriver(webDriverfolder);
                    break;

                //default is Chrome Browser
                default:
                    ChromeOptions crBrowserOptions = new ChromeOptions();
                    crBrowserOptions.AddArguments("--start-maximized");
                    webDriver = new ChromeDriver(webDriverfolder, crBrowserOptions);
                    break;
            }

            CommonVars.instance.webDriver = webDriver;
            return webDriver;

        } //GetBrowserObject


        //######################################################################################################################
        /// <summary>
        /// 
        /// </summary>
        /// <param name="browserType"></param>
        /// <param name="UrlString"></param>
        /// <returns></returns>
        public static IWebDriver BrowserLaunch(string browserType, string UrlString)
        {
            IWebDriver webDriver = GetBrowserObject(browserType);
            webDriver.Navigate().GoToUrl(UrlString);
            
            return webDriver.CurrentWindowHandle == null ? null : webDriver;   
            
        } //BrowserLaunch





    }//class
}//namespace
