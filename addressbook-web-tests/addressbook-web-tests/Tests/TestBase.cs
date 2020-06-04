using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;


namespace addressbook_web_tests
{
    public class TestBase
    {
        protected ApplicationManager app;
        protected IWebDriver driver;


        [SetUp]
        public void SetupTest()
        {

            app = new ApplicationManager();

            /*driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();

            loginHelper = new LoginHelper(driver);
            navigate = new NavigationHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);*/
        }

        [TearDown]
        public void TeardownTest()
        {
            app.StopTest();
        }
    }
}
