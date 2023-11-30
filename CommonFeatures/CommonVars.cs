using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System.Collections.Specialized;
using System.Configuration;

namespace CommonFeatures
{
    public sealed class CommonVars
    {
        // ThreadStatic instance is created 
        // So that test can be executed Parallely
        // call the static constructor or use the Lazy implimentation for 
        // thread-safty and you have to use the old fashin Lock and anti-pattern.
        private static readonly object _criticalArea = new object();

        [ThreadStatic]
        private static CommonVars _instance;
        public static CommonVars instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_criticalArea)
                    {
                        if (_instance == null)
                        {
                            _instance = new CommonVars();
                        }
                    }
                }
                return _instance;
            }
        }

        private CommonVars()
        {
            IConfigurationSection appSettings = CommonUtility.fGetConfigSection("appsettings", "appsettings.json");
            appName = appSettings["appName"];
            browserType = appSettings["browserType"];
            everLightUrl = appSettings["everLightUrl"];

        }

        public string appName { get; set; }
        public string unqTestNumber { get; set; }
        public string browserType { get; set; }
        public string everLightUrl { get; set; }
        public IWebDriver webDriver { get; set; }
        

    }//class
}//namespace
