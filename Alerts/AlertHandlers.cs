using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

public class AlertHandlers
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public AlertHandlers(IWebDriver driver, WebDriverWait wait)
    {
            this.driver = driver;
        this.wait = new WebDriverWait(driver,TimeSpan.FromMilliseconds(30));

    }

    private bool IsAlertPresent() {

        try
        {
            wait.Until(ExpectedConditions.AlertIsPresent());
            return true;
        }
        catch(WebDriverTimeoutException) {

            return false;
        }
        
    }

    private void HandleAlerts(AlertAction action, string? text = null) {
        try
        {


            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert? alert = driver.SwitchTo().Alert();


            if (text != null)
            {
                alert.SendKeys(text);
            }

            switch (action)
            {

                case AlertAction.ACCEPT:
                    alert.Accept();
                    break;
                case AlertAction.DISMISS:
                    alert.Dismiss();
                    break;
                default:
                    throw new ArgumentException("Invalid Alert Action");

            }
        }
        catch (WebDriverTimeoutException) {

            throw new NoAlertPresentException();
        }
       



    }

    private enum AlertAction { 
    
    ACCEPT,
    DISMISS
    
    }
}