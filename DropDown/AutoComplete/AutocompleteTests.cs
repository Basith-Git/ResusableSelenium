using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResusableSelenium.DropDown.AutoComplete
{
    internal class AutocompleteTests 
    {
        WebDriverWait wait = null;
        WebDriver driver;

        [OneTimeSetUp]
        public void Setup() {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

        }
        [Test]
        public void AutoCompletedTestone() { 
        
    

            driver.Url = "https://ej2.syncfusion.com/react/demos/#/tailwind3/auto-complete/default";

            SearchableAutocompleteDropDown(By.CssSelector("#games"),"t",By.CssSelector("#games_options li"),"Football");

        }

        [OneTimeTearDown]
        public void CloseDriver() { 
        
            driver.Close();
            driver.Dispose();
            driver = null;
        
        }

        private void SearchableAutocompleteDropDown(By inputelement, string texttotype,By SuggetionElement,string optiontoselect) {
            try
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                IWebElement input = wait.Until(ExpectedConditions.ElementIsVisible(inputelement));

                input.Clear();
                input.SendKeys(texttotype);

                wait.Until(ExpectedConditions.ElementIsVisible(SuggetionElement));

                var suggetions = driver.FindElements(SuggetionElement);

                var option = suggetions.FirstOrDefault(s => s.Text.Equals(optiontoselect, StringComparison.OrdinalIgnoreCase));

                if (option != null)
                {

                    option.Click();
                }
                else
                {

                    throw new NoSuchElementException();

                }
            }
            catch{


                throw new Exception();            
            }

        
        }
    }
}
