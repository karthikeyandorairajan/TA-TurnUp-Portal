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
    public class LoginPage
    {
        //Functions that allow users to Login to Turnup Portal
        public void LoginAction(IWebDriver driver)
        {
            //Launch Turnup Portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            try
            {
                //Identify Username TextBox and Enter Valid Username
                IWebElement usernameTextBox = driver.FindElement(By.Id("UserName"));
                usernameTextBox.SendKeys("hari");

            }

            catch (Exception ex)

            {
                Assert.Fail("Username TextBox not found"+ex.Message);

            }

           
            Wait.WaitToBeVisible(driver, "Id", "Password", 2);

            try
            {
                //Identify Password TextBox and Enter Valid Password
                IWebElement PasswordTextBox = driver.FindElement(By.Id("Password"));
                PasswordTextBox.SendKeys("123123");
            }

            catch (Exception ex)

            {
                Assert.Fail("Password TextBox not found" +ex.Message);
            }


            try
            {
                //Identify Login Button and Click on it
                IWebElement LoginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
                LoginButton.Click();

            }

            catch (Exception ex)
            {
                Assert.Fail("Login Button not found" +ex.Message);
            }
            Thread.Sleep(2000);
        }
    }
}
