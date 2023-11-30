using EverLightApi;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverLightTests
{
    [TestClass]
    public class ApiOrdersTests
    {        
        [TestMethod]
        public void TestAccessionNumber_00486()
        {
            // Call the api to get the results in Json
            OrdersApiUsage ordersApiUsage = new OrdersApiUsage();
            JArray jsonResult = ordersApiUsage.GetOrdersWithAccessionNumber("00486");
            if (jsonResult == null)
            {
                Assert.Fail("Exiting - Couldn't retrieve results from Everlight Orders Api");
            }

            // Deserialize Results
            var lstOrders = ordersApiUsage.DeserializeResultsJArray(jsonResult);
            

        }// TestAccessionNumber_00486

    }//class
}//namespace
