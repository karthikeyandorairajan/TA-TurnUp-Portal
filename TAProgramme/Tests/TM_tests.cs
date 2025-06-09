using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAProgramme.Pages;
using TAProgramme.Utilities;

namespace TAProgramme.Tests
{
    [TestFixture]
    public class TM_tests : CommonDriver
    {
        [SetUp]
        public void SetUpSteps()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            driver = new ChromeDriver(options);

            //LoginPage Object initialization and definition
            LoginPage LoginPageObj = new LoginPage();
            LoginPageObj.LoginAction(driver);


        }
        [Test]
        public void CreatTime_Test()
        {
            //HomePage Object Initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToHomepage(driver);

            // TMPage Object initialization and definition
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTimeRecord(driver);

        }
        [Test]
        public void EditTime_Test()
        {
            //HomePage Object Initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToHomepage(driver);

            //Edit Time Record
            TMPage tMPageObj = new TMPage();
            tMPageObj.EditTimeRecord(driver);
        }
        [Test]
        public void DeleteTime_Test()
        {
            //HomePage Object Initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToHomepage(driver);

            //Delet Time Record
            TMPage tMPageObj = new TMPage();
            tMPageObj.DeleteTimeRecord(driver);
            driver.Close();
        }
        [TearDown]
        public void CloseTestRun()
        {
         driver.Quit();
        }

    }
}
