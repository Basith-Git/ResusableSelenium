using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

public class AlertHandler
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public AlertHandler(IWebDriver driver, int timeoutInSeconds = 10)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
    }

    /// <summary>
    /// Handles a simple alert by accepting it.
    /// </summary>
    public void AcceptAlert()
    {
        HandleAlert(AlertAction.Accept);
    }

    /// <summary>
    /// Handles a confirmation alert by dismissing it.
    /// </summary>
    public void DismissAlert()
    {
        HandleAlert(AlertAction.Dismiss);
    }

    /// <summary>
    /// Handles a prompt alert by entering text and accepting it.
    /// </summary>
    /// <param name="text">The text to enter in the prompt.</param>
    public void HandlePromptAlert(string text)
    {
        HandleAlert(AlertAction.Accept, text);
    }

    /// <summary>
    /// Checks if an alert is present.
    /// </summary>
    /// <returns>True if an alert is present, otherwise false.</returns>
    public bool IsAlertPresent()
    {
        try
        {
            wait.Until(ExpectedConditions.AlertIsPresent());
            return true;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Gets the text of the alert.
    /// </summary>
    /// <returns>The alert text.</returns>
    public string GetAlertText()
    {
        if (IsAlertPresent())
        {
            return driver.SwitchTo().Alert()?.Text ?? "Text not avilable";
        }
        throw new NoAlertPresentException("No alert is present.");
    }

    /// <summary>
    /// Handles the alert based on the specified action.
    /// </summary>
    /// <param name="action">The action to perform on the alert (Accept, Dismiss).</param>
    /// <param name="text">Optional text to enter in a prompt alert.</param>
    private void HandleAlert(AlertAction action, string? text = null)
    {
        try
        {
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();

            if (text != null)
            {
                alert.SendKeys(text); // For prompt alerts
            }

            switch (action)
            {
                case AlertAction.Accept:
                    alert.Accept();
                    break;
                case AlertAction.Dismiss:
                    alert.Dismiss();
                    break;
                default:
                    throw new ArgumentException("Invalid alert action.");
            }
        }
        catch (WebDriverTimeoutException)
        {
            throw new NoAlertPresentException("No alert appeared within the specified timeout.");
        }
    }

    private enum AlertAction
    {
        Accept,
        Dismiss
    }
}