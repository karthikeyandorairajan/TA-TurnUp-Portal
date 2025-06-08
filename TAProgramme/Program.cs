using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V135.WebAuthn;
using OpenQA.Selenium.Interactions;
using System.Numerics;
using TAProgramme.Pages;
using static System.Net.Mime.MediaTypeNames;

public class Program
{
    public static void Main(string[] args)
    {


        ChromeOptions options = new ChromeOptions();
        options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
        IWebDriver driver = new ChromeDriver(options);

        //LoginPage Object initialization and definition
        LoginPage LoginPageObj = new LoginPage();
        LoginPageObj.LoginAction(driver);

        //HomePage Object Initialization and definition
        HomePage homePageObj = new HomePage();
        homePageObj.NavigateToHomepage(driver);

        // TMPage Object initialization and definition
        TMPage tMPageObj = new TMPage();
        tMPageObj.CreateTimeRecord(driver);

        //Edit Time Record
        tMPageObj.EditTimeRecord(driver);

        //Delet Time Record
        tMPageObj.DeleteTimeRecord(driver);
        driver.Close();

    }
}


        