using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework_1.Pages
{
    public class GiftCardsPage
    {
        private const string currentGiftCardXPath = "//*[@class='ng-binding']";
        private const string checkBalanceXPath = "//input[id='idchkBalance']";
        private const string errorBalanceXPath = "//*[@id='numbervalidation']";

        [FindsBy(How = How.XPath, Using = checkBalanceXPath)]
        private readonly IWebElement checkBalance;

        [FindsBy(How = How.XPath, Using = currentGiftCardXPath)]
        private readonly IWebElement currentGiftCard;

        [FindsBy(How = How.XPath, Using = errorBalanceXPath)]
        private readonly IWebElement errorBalance;

        [Obsolete] //For PageFactory
        public GiftCardsPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public GiftCardsPage CheckBalance()
        {
            currentGiftCard.Click();
            checkBalance.Click();
            return this;
        }

        public string GetErrorBalance()
        {
            return errorBalance.Text;
        }
    }
}
