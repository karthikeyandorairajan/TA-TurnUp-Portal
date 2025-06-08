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

            //Idendify Username TextBox and Enter Valid Username
            IWebElement usernameTextBox = driver.FindElement(By.Id("UserName"));
            usernameTextBox.SendKeys("hari");

            Wait.WaitToBeVisible(driver, "Id", "Password", 2);

            //Identify Password TextBox and Enter Valid Password
            IWebElement PasswordTextBox = driver.FindElement(By.Id("Password"));
            PasswordTextBox.SendKeys("123123");

            //Identify Login Button and Click on it
            IWebElement LoginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            LoginButton.Click();
            Thread.Sleep(2000);
        }
    }
}
