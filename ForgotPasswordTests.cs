using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace autotest_test
{
    [TestFixture]
    public class ForgotPasswordTests
    {
        private ChromeDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
            driver.Dispose();
        }

        [Test]
        public void GoToRecoveryPasswordFormTest()
        {
            driver.Navigate().GoToUrl("https://www.gosuslugi.ru/");

            PressLoginButton();
            WaitUntilPageLoad("https://esia.gosuslugi.ru/login/");
            PressCantLoginButton();
            PressRecoveryPasswordButton();
            WaitUntilPageLoad("https://esia.gosuslugi.ru/login/recovery");

            Assert.That(driver.Url, Is.EqualTo("https://esia.gosuslugi.ru/login/recovery"));
        }

        public void PressLoginButton()
        {
            IWebElement loginBtn = wait.Until(ExpectedConditions.ElementToBeClickable(
               By.XPath("//html//body//portal-root//div[2]//header//lib-header//div//div//div[2]//div//lib-header-auth//button")));
            loginBtn.Click();
        }

        public void PressCantLoginButton()
        {
            IWebElement cantLoginBtn = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("/html/body/esia-root/div/esia-login/div/div[1]/form/div[5]/button")));
            cantLoginBtn.Click();
        }

        public void PressRecoveryPasswordButton()
        {
            IWebElement recoveryBtn = driver.FindElement(
               By.XPath("/html/body/esia-root/esia-modal/div/div[2]/div/esia-modal-login-faq/div/ul/li[2]/button"));
            recoveryBtn.Click();
        }

        public void WaitUntilPageLoad(string url)
        {
            wait.Until(ExpectedConditions.UrlToBe(url));
        }
    }

}