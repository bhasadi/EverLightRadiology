using CommonFeatures;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharpApi;
using System.Net;

namespace EverLightApi
{
    public class OrdersApiUsage
    {
        public JsonApi apiJson;
        public InitVarsEverLightApi apiVars;        

        public OrdersApiUsage()
        {
            apiVars = new InitVarsEverLightApi();
            apiJson = new JsonApi(apiVars.apiEndPoint);
        }//OrdersApiUsage

        // ===================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessionNumber"></param>
        /// <returns></returns>
        public JArray GetOrdersWithAccessionNumber(string accessionNumber)
        {
            var apiParams = new Dictionary<string, string>
            {                
                //{ "id", Id },
                { "accessionNumber", accessionNumber }
            };

            JArray jsonResult = apiJson.GetServiceResponse<JArray>("GET", apiVars.apiOrdersAction, apiParams);
            if ((jsonResult == null) || (apiJson.restStatusCode != HttpStatusCode.OK))
            {
                CommonUtility.LogExecutionMessage("default", "Deserialization failed - Error Message - " + apiJson.restStatusDescription);
                return null;
            }
            return jsonResult;
        }// GetOrdersWithAccessionNumber


        // ===================================================================================================
        /// <summary>
        /// method  Deserialize
        /// created
        /// </summary>
        /// <param name="jsonArray"></param>
        /// <returns></returns>
        public IList<OrdersApiMain> DeserializeResultsJArray(JArray jsonArray)
        {
            List<OrdersApiMain> lstOrders = new List<OrdersApiMain>();
            foreach (var obj in jsonArray)
            {                
                try
                {
                    var orderItem = JsonConvert.DeserializeObject<OrdersApiMain>(obj.ToString());
                    if (orderItem != null)
                        lstOrders.Add(orderItem);
                }
                catch (Exception exCpn)
                {
                    CommonUtility.LogExecutionMessage("default", "Deserialization failed - Error Message - " + exCpn.Message);
                    return null;
                }
            }// end for loop           

           
            return lstOrders;
        }// DeserializeResultsJArray


    }//class
}//namespace
