using CommonFeatures;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverLightTests.PageObjects
{
    public class EL_NewOrderPage: BasePage
    {
        
        IWebElement edtMrn { get { return SeleniumExtension.GetWebElement(By.CssSelector("input[formcontrolname='patientMrn']")); } }
        IWebElement edtFirstName { get { return SeleniumExtension.GetWebElement(By.CssSelector("input[formcontrolname='patientFirstName']")); } }

        IWebElement edtLastName { get { return SeleniumExtension.GetWebElement(By.CssSelector("input[formcontrolname='patientLastName']")); } }

        IWebElement edtAccessionNum { get { return SeleniumExtension.GetWebElement(By.CssSelector("input[formcontrolname='accessionNumber']")); } }

        IWebElement drpOrganisation { get { return SeleniumExtension.GetWebElement(By.CssSelector("select[formcontrolname='orgCode']")); } }

        IWebElement drpSiteID { get { return SeleniumExtension.GetWebElement(By.CssSelector("select[formcontrolname='siteId']")); } }

        IWebElement drpModality { get { return SeleniumExtension.GetWebElement(By.CssSelector("select[formcontrolname='modality']")); } }

        IWebElement edtStudyDateTime { get { return SeleniumExtension.GetWebElement(By.CssSelector("input[formcontrolname='studyDateTime']")); } }

        IWebElement btnSubmit { get { return SeleniumExtension.GetWebElement(By.CssSelector("button[type='submit']")); } }

        //######################################################################################
        //######################################################################################


        public void createOrder(string unqNumber)
        {
            edtMrn.editSetText("P102");
            edtFirstName.editSetText("John");
            edtLastName.editSetText("Doe");
            edtAccessionNum.editSetText(unqNumber);

            drpOrganisation.comboSelectBySendKeys("LUM");
            drpSiteID.comboSelectBySendKeys("Baulkham");
            drpModality.comboSelectBySendKeys("MRI");

            edtStudyDateTime.setDateTime("11/11/2023", "08:45 PM");
            btnSubmit.Click();

        }



    }//class
}//namespace
