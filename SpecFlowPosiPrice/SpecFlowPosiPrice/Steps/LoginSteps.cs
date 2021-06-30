using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowPosiPrice.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        public static IWebDriver Instance { get; set; }
        //Step definitions
        [Given(@"I enter to the loginpage")]
        public void GivenIEnterToTheLoginpage()
        {
            Instance = new ChromeDriver();
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Instance.Url = "http://posiprice.com/LoginSteps.html";
        }

        [When(@"I enter my username (.*) and password (.*)")]
        public void WhenIEnterMyUsernameAndPassword(string username, string password)
        {
            Instance.FindElement(By.Name("user")).Click();
            Instance.FindElement(By.Name("user")).Clear();
            Instance.FindElement(By.Name("user")).SendKeys(username);
            Instance.FindElement(By.Name("password")).SendKeys(password);
        }

        [When(@"I click the login  button")]
        public void WhenIClickTheLoginButton()
        {
            Instance.FindElement(By.XPath("/html/body/center/div/form/table/tbody/tr[]"));
        }

        [Then(@"I should enter to the home page")]
        public void ThenIShouldSeeHello(string p0, Table table)
        {
            Instance.Quit();
        }


    }
}
