using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResusableSelenium.Alerts.Tests
{
    internal class AlertsTests
    {

        [Test]
        public void AlertsConfirmPopUp() {


            var driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";

            driver.FindElement(By.XPath("//button[.='Click for JS Alert']")).Click();

            IAlert alert = driver.SwitchTo().Alert();

            var alerttext = alert.Text;

            alert.Accept();

            Console.WriteLine(  alerttext);

            driver.Close();
        }
    }
}
