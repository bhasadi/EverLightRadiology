using CommonFeatures;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverLightTests.PageObjects
{
    public class BasePage
    {
        public static IWebDriver driver = CommonVars.instance.webDriver;

        // #############################################################################
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetAutPageAs<T>()
        {
            dynamic pagePbject = null;
            var type = typeof(T);

            // getiing the default constructor
            var ctor = type.GetConstructor(Type.EmptyTypes);
            if (ctor != null)
            {
                pagePbject = (T)ctor.Invoke(new object[] { });
            }

            return pagePbject;
        }// TestMethod


    }//class
}//namespace
