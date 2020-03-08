using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace UnitTest
{
    public class Browser_ops
    {
        IWebDriver webDriver;
        public void Init_Browser()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
        }
        public string Title
        {
            get { return webDriver.Title; }
        }
        public void Goto(string url)
        {
            webDriver.Url = url;
        }
        public void Close()
        {
            webDriver.Quit();
        }
        public IWebDriver getDriver
        {
            get { return webDriver; }
        }
    }
    class NUnit_Demo_1
    {
        Browser_ops brow = new Browser_ops();
        String test_url = "http://localhost:59729/";
        IWebDriver driver;
        IJavaScriptExecutor executor;

        [SetUp]
        public void start_Browser()
        {
            brow.Init_Browser();
        }

        [Test(Author = "Vasyl K", Description = "Lab 3 - test case #1 - add new Employee")]
        public void Test1()
        {
            // got to url
            brow.Goto(test_url);
            // ceck while url is loading
            System.Threading.Thread.Sleep(2000);

            driver = brow.getDriver;
            executor = (IJavaScriptExecutor)driver;

            PerformDelay();
            // Open employee list
            IWebElement element = driver.FindElement(By.Id("employees"));
            element.Click();

            PerformDelay();
            // Add new employee buton
            element = driver.FindElement(By.Id("AddEmployee"));
            element.Click();

            PerformDelay();
            // Input name of new employee
            element = driver.FindElement(By.Id("NameInput"));
            element.SendKeys("Володимир");

            PerformDelay();
            // Input LastName of new employee
            element = driver.FindElement(By.Id("LastName"));
            element.SendKeys("Зеленський");

            PerformDelay();
            // Input age of new employee
            element = driver.FindElement(By.Id("Age"));
            element.SendKeys("18");

            PerformDelay();
            // Input position of new employee
            element = driver.FindElement(By.Id("Position"));
            element.SendKeys("Президент");

            PerformDelay();
            // Input salary of new employee
            element = driver.FindElement(By.Id("Salary"));
            element.SendKeys("1000");

            PerformDelay();
            // Input birthDate of new employee
            element = driver.FindElement(By.Id("BirthDate"));
            element.SendKeys("01.01.2000");

            PerformDelay();
            element = driver.FindElement(By.Id("EmployeeSave"));
            element.Click();
            PerformDelay();

            executor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            PerformDelay();

        }

        [Test(Author = "Vasyl K", Description = "Lab 3 - test case #2 - add new Ice Cream")]
        public void Test2()
        {
            // got to url
            brow.Goto(test_url);
            // ceck while url is loading
            System.Threading.Thread.Sleep(2000);

            driver = brow.getDriver;
            executor = (IJavaScriptExecutor)driver;

            PerformDelay();
            // get iceCreams button
            IWebElement element = driver.FindElement(By.Id("iceCream"));
            element.Click();

            PerformDelay();
            // Add new ice cream buton
            element = driver.FindElement(By.Id("AddIceCream"));
            element.Click();

            PerformDelay();
            // Input name of new ice cream
            element = driver.FindElement(By.Id("Name"));
            element.SendKeys("Лімо львівське");

            PerformDelay();
            // Input amount of new ice cream
            element = driver.FindElement(By.Id("Amount"));
            element.SendKeys("20");

            PerformDelay();
            // Input price of new ice cream
            element = driver.FindElement(By.Id("Price"));
            element.SendKeys("20");

            PerformDelay();
            // Input description of new ice cream
            element = driver.FindElement(By.Id("Description"));
            element.SendKeys("Lab 3 test");

            PerformDelay();
            element = driver.FindElement(By.Id("IceCreamSave"));
            element.Click();
            PerformDelay();

            executor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            PerformDelay();

        }

        [Test(Author = "Vasyl K", Description = "Lab 3 - test case #3 - delete ice cream")]
        public void Test3()
        {
            // got to url
            brow.Goto(test_url);
            // ceck while url is loading
            System.Threading.Thread.Sleep(2000);

            driver = brow.getDriver;
            executor = (IJavaScriptExecutor)driver;

            PerformDelay();
            // get iceCreams button
            IWebElement element = driver.FindElement(By.Id("iceCream"));
            element.Click();

            PerformDelay();
            var lastRow = driver.FindElements(By.XPath("//table[@class='table']/tbody/tr/td")).LastOrDefault();
            lastRow.Click();

            PerformDelay();
            element = driver.FindElement(By.Id("deleteIceCream"));
            element.Click();

            PerformDelay();

            executor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            PerformDelay();
        }

        [TearDown]
        public void close_Browser()
        {
            brow.Close();
        }

        private void PerformDelay()
        {
            Thread.Sleep(delay);
        }

        private int delay = 2000;
    }
}