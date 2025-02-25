using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResusableSelenium.Windows
{
    internal class WindowsHandling
    {
        WebDriverWait wait = null;
        WebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

        }

        [Test]
        public void WindowsHandlingTestOne() { 
        
      

            driver.Url = "https://the-internet.herokuapp.com/windows";

            driver.FindElement(By.XPath("//a[.='Click Here']")).Click();
            WindowsReusable("New Window");

            Console.WriteLine(driver.Title);

            WindowsReusable("The Internet");
            Console.WriteLine(driver.Title);

            driver.FindElement(By.XPath("//a[.='Elemental Selenium']")).Click();
            WindowsReusable("Home | Elemental Selenium");
            Console.WriteLine(driver.Title);

            WindowsReusable("The Internet");
            Console.WriteLine(driver.Title);




        }

        [Test]

        [OneTimeTearDown]
        public void CloseDriver() { 
        
            driver.Close();
            driver.Dispose();
            driver = null;
        
        }

        private void WindowsReusable(string title) {

            var windows = driver.WindowHandles;

            foreach (var win in windows) {

                driver.SwitchTo().Window(win);

                if (driver.Title == title) {

                    
                    return;
                }
            
            }

        
        }
    }
}
