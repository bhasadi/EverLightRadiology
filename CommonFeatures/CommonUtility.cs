using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace CommonFeatures
{
    public class CommonUtility
    {
        private static CommonVars commonInstance = CommonVars.instance;

        //######################################################################################################################
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool launchEverLight()
        {
            //var tmp = SeleniumBrowserExtension.BrowserLaunch("Chrome", "https://localhost:44449/");
            var tmp = SeleniumBrowserExtension.BrowserLaunch(commonInstance.browserType, commonInstance.everLightUrl);   
            return true;
        }//launchEverLight

        // ===================================================================================================
        /// <summary>
        /// to log execution message
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="exeMessage"></param>
        public static void LogExecutionMessage(string logType, string exeMessage)
        {
            switch (logType.ToLower())
            {
                default: //case "EqualTo":
                    Console.WriteLine(exeMessage);
                    break;
            }
        }// LogExecutionMessage

        //=================================================================================
        /// <summary>
        /// This method loads a json file
        /// </summary>
        /// <param name="qualFilePath"></param>
        /// <returns></returns>
        public static JObject LoadJsonFile(string qualFilePath)
        {
            JObject jsonObject;
            try
            {
                jsonObject = JObject.Parse(File.ReadAllText(qualFilePath));
            }
            catch (Exception exCpn)
            {
                LogExecutionMessage("default", "Couldn't parse the file as Json - Error Message - " + exCpn.Message);
                return null;
            }

            return jsonObject;
        }// LoadJsonFile

        //XX 	######################################################################################################################
        //XX 	######################################################################################################################
        public static IConfigurationSection fGetConfigSection(string sectionName, string fileName, string filePath = "default")
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory());

            var builder = new ConfigurationBuilder()
            .SetBasePath(filePath)
            .AddJsonFile(fileName, optional: false, reloadOnChange: true);
            //.AddEnvironmentVariables();

            IConfiguration appConfig = builder.Build();           
            var section = appConfig.GetSection(sectionName);

            return section;
        }//fGetConfigSection

    }//class
}//namespace
