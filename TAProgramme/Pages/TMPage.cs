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
    public class TMPage
    {
        public void CreateTimeRecord(IWebDriver driver)
        {
            try
            {
                //Click on Create NewButton
                IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
                createNewButton.Click();
            }
            
            catch (Exception ex) 
            {
                Assert.Fail("Create New Button not found" + ex.Message);
            }

            try
            {
                //Select the time form DropdownMenu
                IWebElement typecodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
                typecodeDropdown.Click();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                Assert.Fail("TypeCode Dropdown Menu not found" +ex.Message);
            }

            try
            {
                IWebElement timeOption = driver.FindElement(By.XPath("//div[@id='TypeCode-list']/ul/li[2]"));
                timeOption.Click();
                Wait.WaitImplicit(driver, 3000);

            }

            catch (Exception ex)

            {

                Assert.Fail("Timeoption Button not found "+ex.Message);
            }

            try
            {
                //Type Code into Code textbox
                IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
                codeTextbox.SendKeys("TA Programme");
            } 
            catch (Exception ex)
            {
                Assert.Fail("Code Textbox not found"+ex.Message);
            }

            try
            {
                //Type Description into Description TextBox
                IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
                descriptionTextbox.SendKeys("This is a description");
            }
            catch(Exception ex)
            {
                Assert.Fail("Description TextBox not found "+ex.Message);
            }

            try
            {
                //Type price into pricebox
                IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
                priceTagOverlap.Click();

                IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
                priceTextbox.SendKeys("12");

                Wait.WaitToBeClickable(driver, "Id", "SaveButton", 3);
            }
            catch(Exception ex)
            {
                Assert.Fail("Price Box not found "+ex.Message);
            }
           
            try
            {
                //Click on save button
                IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
                saveButton.Click();
            }
            catch(Exception ex)
            {
                Assert.Fail("Save button not found"+ex.Message);
            }
            
            Thread.Sleep(3000);

            //Check if Time record has been Created Successfully 
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(newCode.Text == "TA Programme", "New Time record has not been Created ");
            
        }

        public void EditTimeRecord(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Wait.WaitImplicit(driver, 3000);
            try
            {
                //Edit Time Records 
                IWebElement editButton = driver.FindElement(By.XPath("//div[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Edit button not found" + ex.Message);

            }

            try
            {
                //Type Description into New Description TextBox
                IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
                descriptionTextbox.Clear();
                descriptionTextbox.SendKeys("This is a new description");
            }
            catch(Exception ex)
            {
                Assert.Fail("Description Textbox not found" +ex.Message);
            }
          
            try
            {
                Wait.WaitToBeClickable(driver, "Id", "SaveButton", 3);
                // lick on save button
                IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
                saveButton.Click();
              
            }
            catch(Exception ex)
            {
                Assert.Fail("Savebutton not found" +ex.Message);
            }
            Thread.Sleep(3000);
            
            //Check if Time record has been Created Successfully 
            IWebElement goToLastPageButtonAgain = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButtonAgain.Click();
            Thread.Sleep(3000);
            IWebElement newDescription = driver.FindElement(By.XPath("//div[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            Assert.That(newDescription.Text == "This is a new description", "New Time record has not been Edited ");
        }

        public void DeleteTimeRecord(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            //Finding number of records
            String totalRecords = driver.FindElement(By.XPath("//div[@id=\"tmsGrid\"]/div[4]/span[2]")).Text;
            String[] splitTotalRecordsValues = totalRecords.Split(' ');
            
            Console.WriteLine("Array Values"+splitTotalRecordsValues[4]);

            Wait.WaitImplicit(driver, 3000);
            try
            {
                //Delete Time Record
                IWebElement deleteButton = driver.FindElement(By.XPath("//div[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteButton.Click();
            }

            catch (Exception ex)
            { 
            Assert.Fail("Delete Button not found" +ex.Message );
            }

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
        Assert.That(actualNumberOfRecords == expectedNumberOfRecords, " Last record is not deleted");
        }
    }
}
