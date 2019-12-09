using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumWebdriver
{
    static public class WaitCheckIn
    {
        static public DefaultWait<IWebDriver> GetWaitCheckIn(IWebDriver driver)
        {
            DefaultWait<IWebDriver> fWait = new DefaultWait<IWebDriver>(driver);
            fWait.Timeout = TimeSpan.FromSeconds(20);
            fWait.PollingInterval = TimeSpan.FromSeconds(5);
            fWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return fWait;
        }
    }
}
