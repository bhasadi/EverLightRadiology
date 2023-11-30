using CommonFeatures;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverLightTests.PageObjects
{
    public class EL_OrdersPage: BasePage
    {
        IWebElement btnCreateNew { get { return SeleniumExtension.GetWebElement(By.CssSelector("app-orders button")); } }
        IWebElement tblOrders { get { return SeleniumExtension.GetWebElement(By.CssSelector("table")); } }

        //######################################################################################
        //######################################################################################
        public bool createNewOrder()
        {
            btnCreateNew.Click();
            return true;

        }//goToOrders      



    }//class
}//namespace
