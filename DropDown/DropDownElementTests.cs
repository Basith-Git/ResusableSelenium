using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResusableSelenium.DropDown
{
    internal class DropDownElementTests
    {

        [Test]
        public void DropdownListTest() {

            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

            driver.Url = "https://ej2.syncfusion.com/demos/#/tailwind3/drop-down-list/default.html";
            var ele = driver.FindElement(By.XPath("//input[@placeholder='Select a game']"));
            IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
            ex.ExecuteScript("arguments[0].value='Football';",ele);



            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var element = driver.FindElement(By.XPath("//*[@id='games']"));


            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.display = 'block';", element);
            // ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.visibility = 'visible';", element);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].removeAttribute('aria-disabled');", element);

           

            SelectElement se = new SelectElement(element);
            var s1 = se.AllSelectedOptions;
            string s = se.SelectedOption.Text;
            Console.WriteLine(s1);

            // Set aria-disabled to false (if needed)
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].setAttribute('aria-disabled', 'false');",element);


        }
    }
}
