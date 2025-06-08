using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAProgramme.Utilities;

namespace TAProgramme.Pages
{
    public class TMPage
    {
        public void CreateTimeRecord(IWebDriver driver)
        {
            //Click on Create NewButton
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

           
            //Select the time form DropdownMenu
            IWebElement typecodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typecodeDropdown.Click();
            Thread.Sleep(3000);

           
            IWebElement timeOption = driver.FindElement(By.XPath("//div[@id='TypeCode-list']/ul/li[2]"));
            timeOption.Click();
            Wait.WaitImplicit(driver, 3000);
            
            //Type Code into Code textbox
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("TA Programme");

            //Type Description into Description TextBox
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("This is a description");

            //Type price into pricebox
            IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTagOverlap.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("12");

            Wait.WaitToBeClickable(driver, "Id", "SaveButton", 3);

            //Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            //Wait.WaitImplicit(driver, 3000);
            Thread.Sleep(3000);

            //Check if Time record has been Created Successfully 
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            if (newCode.Text == "TA Programme")
            {
                Console.WriteLine("Time record created successfully!");

            }
            else
            {
                Console.WriteLine("New time has not been Created");
            }
        }

        public void EditTimeRecord(IWebDriver driver)
        {
            //Edit Time Records 

            IWebElement editButton = driver.FindElement(By.XPath("//div[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            //Type Description into New Description TextBox
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.Clear();
            descriptionTextbox.SendKeys("This is a new description");

            Wait.WaitToBeClickable(driver, "Id", "SaveButton", 3);
            // lick on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(3000);

            //Check if Time record has been Created Successfully 
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            if (newDescription.Text == "This is a new description")
            {
                Console.WriteLine("Time record Edited successfully!");

            }
            else
            {
                Console.WriteLine("New time has not been Edited");
            }

        }

        public void DeleteTimeRecord(IWebDriver driver)
        {
            //Finding number of records
            String totalRecords = driver.FindElement(By.XPath("//div[@id=\"tmsGrid\"]/div[4]/span[2]")).Text;
        String[] splitTotalRecordsValues = totalRecords.Split(' ');
        Console.WriteLine(splitTotalRecordsValues[4]);


        //Delete Time Record
        IWebElement deleteButton = driver.FindElement(By.XPath("//div[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
        deleteButton.Click();

       // Wait.WaitImplicit(driver, 2000);
        IAlert alertBox = driver.SwitchTo().Alert();
        alertBox.Accept();
        Console.WriteLine("Records deleted successfully");
        Thread.Sleep(3000);

        String totalRecordsAfterDelete = driver.FindElement(By.XPath("//div[@id=\"tmsGrid\"]/div[4]/span[2]")).Text;
        String[] splitTotalRecordsValuesAfterDelete = totalRecordsAfterDelete.Split(' ');
        int actualNumberOfRecords = Int32.Parse(splitTotalRecordsValuesAfterDelete[4]);
        int expectedNumberOfRecords = Int32.Parse(splitTotalRecordsValues[4])-1;
        Console.WriteLine("Actual" + actualNumberOfRecords);
        Console.WriteLine("Expected" + expectedNumberOfRecords);
        if (actualNumberOfRecords == expectedNumberOfRecords)
        {
            Console.WriteLine(" Last record deleted successfully");
        }
        else
        {
            Console.WriteLine("Last records is not deleted");
        }
        
        }
    }
}
