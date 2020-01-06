using Framework_1.PageModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Framework_1.Pages
{
    public class LogPage
    {
        private const string signUpXPath = "//input[@class='signup-link buttonN']";
        private const string titleBoxXPath = "//select[@id='CONTROLGROUPREGISTERVIEW_PersonInputRegisterView_DropDownListTitle']";
        private const string titleXPath = "//option[3][@id='CONTROLGROUPREGISTERVIEW_PersonInputRegisterView_DropDownListTitle']";
        private const string nameBoxXPath = "//input[@id='CONTROLGROUPREGISTERVIEW_PersonInputRegisterView_TextBoxFirstName']";
        private const string surnameBoxXPath = "//input[@id='CONTROLGROUPREGISTERVIEW_PersonInputRegisterView_TextBoxLastName']";
        private const string passwordBoxXPath = "//input[@id='CONTROLGROUPREGISTERVIEW_MemberInputRegisterView_PasswordFieldAgentPassword']";
        private const string repeatPasswordXPath = "//input[@id='CONTROLGROUPREGISTERVIEW_MemberInputRegisterView_PasswordFieldPasswordConfirm']";
        private const string mailBoxXPath = "//input[@id='CONTROLGROUPREGISTERVIEW_PersonInputRegisterView_TextBoxEmail']";
        private const string numberRegionXPath = "//div[@class='selected-flag']";
        private const string numberBelarusXPath = "//span[@class='country-name']";
        private const string numberXPath = "//input[@id='CONTROLGROUPREGISTERVIEW_PersonInputRegisterView_TEXTBOXINTLMOBILENUMBER']";
        private const string dateBoxXPath = "//input[@id='CONTROLGROUPREGISTERVIEW_PersonInputRegisterView_TEXTBOXINPUTDOB']";
        private const string yearXPath = "//span[@id='datepicker_910']";
        private const string monthXPath = "//a[@id='datepicker_910']";
        private const string dayXPath = "//span[@id='datepicker_910']";
        private const string confirmXPath = "//input[@id='chkSpiceClubTnC']";
        private const string submitXPath = "//input[@id='CONTROLGROUPREGISTERVIEW_ButtonSubmit']";
        private const string messageXPath = "//div[@id='SpiceMoneyOT']";

        [FindsBy(How = How.XPath, Using = signUpXPath)]
        private readonly IWebElement signUp;

        [FindsBy(How = How.XPath, Using = titleBoxXPath)]
        private readonly IWebElement titleBox;

        [FindsBy(How = How.XPath, Using = titleXPath)]
        private readonly IWebElement title;

        [FindsBy(How = How.XPath, Using = nameBoxXPath)]
        private readonly IWebElement name;

        [FindsBy(How = How.XPath, Using = surnameBoxXPath)]
        private readonly IWebElement surname;

        [FindsBy(How = How.XPath, Using = passwordBoxXPath)]
        private readonly IWebElement password;

        [FindsBy(How = How.XPath, Using = repeatPasswordXPath)]
        private readonly IWebElement rPassword;

        [FindsBy(How = How.XPath, Using = mailBoxXPath)]
        private readonly IWebElement mail;

        [FindsBy(How = How.XPath, Using = numberRegionXPath)]
        private readonly IWebElement nRegion;

        [FindsBy(How = How.XPath, Using = numberBelarusXPath)]
        private readonly IWebElement nBel;

        [FindsBy(How = How.XPath, Using = numberXPath)]
        private readonly IWebElement number;

        [FindsBy(How = How.XPath, Using = dateBoxXPath)]
        private readonly IWebElement dateBox;

        [FindsBy(How = How.XPath, Using = yearXPath)]
        private readonly IWebElement year;

        [FindsBy(How = How.XPath, Using = monthXPath)]
        private readonly IWebElement month;

        [FindsBy(How = How.XPath, Using = dayXPath)]
        private readonly IWebElement day;

        [FindsBy(How = How.XPath, Using = confirmXPath)]
        private readonly IWebElement confirm;

        [FindsBy(How = How.XPath, Using = submitXPath)]
        private readonly IWebElement submit;

        [FindsBy(How = How.XPath, Using = messageXPath)]
        private readonly IWebElement message;

        [Obsolete] //For PageFactory
        public LogPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public LogPage GoSignUp()
        {
            signUp.Click();
            return this;
        }

        public LogPage InputData(ModelSignUp user)
        {
            titleBox.Click();
            title.Click();
            name.SendKeys(user.Name);
            surname.SendKeys(user.Surname);
            nRegion.Click();
            nBel.Click();
            number.SendKeys(user.Number);
            password.SendKeys(user.Password);
            rPassword.SendKeys(user.RPassword);
            mail.SendKeys(user.Mail);
            dateBox.Click();
            year.Click();
            month.Click();
            day.Click();
            confirm.Click();
            return this;
        }

        public LogPage SubmitSignUp()
        {
            submit.Click();
            return this;
        }

        public string GetMessage()
        {
            return message.Text;
        }
    }
}
