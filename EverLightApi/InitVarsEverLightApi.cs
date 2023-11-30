using CommonFeatures;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverLightApi
{
    public class InitVarsEverLightApi
    {
        public string apiKey;
        public string apiOrdersAction;
        public string apiPatientsAction;
        public string apiEndPoint;

        public InitVarsEverLightApi() 
        {
            //apiKey = "TBA";
            //apiOrdersAction = "api/orders";
            //apiPatientsAction = "api/patients";
            //apiEndPoint = "https://localhost:44449/";

            IConfigurationSection appSettings = CommonUtility.fGetConfigSection("appsettings", "appsettings.json");
            apiKey = appSettings["apiKey"];
            apiOrdersAction = appSettings["apiOrdersAction"];
            apiPatientsAction = appSettings["apiPatientsAction"];
            apiEndPoint = appSettings["apiEndPoint"];

        }//InitVarsEverLightApi


    }//class
}//namespace
