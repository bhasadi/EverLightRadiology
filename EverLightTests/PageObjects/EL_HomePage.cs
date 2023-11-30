using CommonFeatures;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverLightTests.PageObjects
{    
    public class EL_HomePage: BasePage
    {
        IWebElement lnkHome { get { return SeleniumExtension.GetWebElement(By.CssSelector("li[class='nav-item link-active'] a[href='/']")); } }
        IWebElement lnkOrders { get { return SeleniumExtension.GetWebElement(By.CssSelector("a[href='/orders']")); } }

        //######################################################################################
        //######################################################################################
        public bool goToOrders()
        {
            lnkOrders.Click();                               
            return true;

        }//goToOrders      

        public bool goToHomePage()
        {
            lnkHome.Click();
            return true;

        }//goToOrders   


    }// end class
}//namespace
