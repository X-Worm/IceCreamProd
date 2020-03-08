using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTest_Lab3
{
    class SDriver
    {
        IWebDriver driver;
        private string url = "http://localhost:59729/";

        public void Test()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incognito");
            driver = new ChromeDriver(Directory.GetCurrentDirectory(), options);

            driver.Navigate().GoToUrl(url);


            Thread.Sleep(2000);
            // get iceCreams button
            IWebElement element = driver.FindElement(By.Id("iceCream"));
            element.Click();

            Thread.Sleep(2000);
            var lastRow = driver.FindElements(By.XPath("//table[@class='table']/tbody/tr/td")).LastOrDefault();

            string identifier = lastRow.GetAttribute("id");
            lastRow.Click();

            Thread.Sleep(2000);
            element = driver.FindElement(By.Id("deleteIceCream"));
            element.Click();

            Thread.Sleep(2000);

            Thread.Sleep(2000);
        }

    }

}
