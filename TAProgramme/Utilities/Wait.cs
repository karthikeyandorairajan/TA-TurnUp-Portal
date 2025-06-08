using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAProgramme.Utilities
{
    public class Wait
    {

        //Generic function to wait for an element to be clickable
        public static void WaitToBeClickable(IWebDriver driver, string LocatorType, string LocatorValue, int seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));

            if (LocatorType == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(LocatorValue)));
            }
            if (LocatorType == "Id") ;
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(LocatorValue)));
            }
        }
        public static void WaitToBeVisible(IWebDriver driver, string LocatorType, string LocatorValue, int seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            if (LocatorType == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(LocatorValue)));
            }
            if (LocatorType == "Id") ;
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(LocatorValue)));
            }
        }

        public static void WaitImplicit(IWebDriver driver , int milliSeconds)
        {
            //Applying Implicit Wait command for given seconds

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(milliSeconds);
        }
    }
}
