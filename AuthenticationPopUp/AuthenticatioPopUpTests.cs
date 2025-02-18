using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V130.Accessibility;
using OpenQA.Selenium.DevTools.V130.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnableCommandSettings = OpenQA.Selenium.DevTools.V130.Network.EnableCommandSettings;

namespace ResusableSelenium.AuthenticationPopUp
{
    internal class AuthenticatioPopUpTests
    {

        [Test]
        public void AuthenticatioPopUpTest() {

            var driver = new ChromeDriver();

            

            var devtools = driver.GetDevToolsSession();

            devtools.SendCommand(new EnableCommandSettings());
            var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes("admin:admin"));
            var headers = new Headers();

            headers.Add("Authorization","Basic " +$"{credentials}");
           

            devtools.SendCommand(new SetExtraHTTPHeadersCommandSettings
            {

                Headers = headers

            });

            driver.Url = "https://the-internet.herokuapp.com/basic_auth";

            var text = driver.FindElement(By.XPath("//h3[.='Basic Auth']")).Text;

            Console.WriteLine(text);

        }
    }
}
