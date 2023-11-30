using CommonFeatures;
using EverLightTests.PageObjects;
using EverLightTests.TestHooks;
using OpenQA.Selenium;

namespace EverLightTests
{
    [TestClass]
    public class WebAppTest: BaseTestClass
    {
        [TestMethod]
        public void AddNewOrder()
        {
            try
            {     
                // create a unique number 
                var accessionNum = CommonVars.instance.unqTestNumber;

                //launch the application
                var tmp = CommonUtility.launchEverLight();

                var loginPage = BasePage.GetAutPageAs<EL_HomePage>();
                var ordersPage = BasePage.GetAutPageAs<EL_OrdersPage>();
                var newOrderPage = BasePage.GetAutPageAs<EL_NewOrderPage>();

                loginPage.goToOrders();
                ordersPage.createNewOrder();
                newOrderPage.createOrder(accessionNum);

            }
            catch(Exception exCpn) 
            {
                Assert.Fail(exCpn.Message);
            }
        }//Test


    }//class
}//namespace