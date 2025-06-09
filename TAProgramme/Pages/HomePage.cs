using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAProgramme.Utilities;

namespace TAProgramme.Pages
{
     public class HomePage
    {
        public void NavigateToHomepage(IWebDriver driver)
        {

            try
            {
                //Navigate to Time and Materials page
                IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span"));
                administrationTab.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(" Administration Tab not found" + ex.Message);
            
            }

            try
            {
                IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
                timeAndMaterialOption.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Time and Materials page not found" +ex.Message); 
            }

                       
        }
    }
}
