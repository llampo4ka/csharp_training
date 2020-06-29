using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace addressbook_web_tests
{
    [TestFixture]
    class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInformationFromTableTest()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromForm(0);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void ContactInformationFromContactPageTest()
        {
            ContactData fromForm = app.Contacts.GetContactInformationFromForm(0);
            string dd = fromForm.FirstName + " " + fromForm.LastName + fromForm.Address;

            if (fromForm.MiddleName != "")
            {
                dd = fromForm.FirstName + " " + fromForm.MiddleName + " " + fromForm.LastName + fromForm.Address;
            }
                        
            if (fromForm.HomePhone != "")
            {
                dd = dd + "H: " + fromForm.HomePhone;
            }
            if (fromForm.MobilePhone != "")
            {
                dd = dd + "M: " + fromForm.MobilePhone;
            }
            if (fromForm.WorkPhone != "")
            {
                dd = dd + "W: " + fromForm.WorkPhone;
            }
           
            dd += fromForm.Email + fromForm.Email2 + fromForm.Email3;

            System.Console.Out.Write(dd);
            string fromContPage = app.Contacts.GetContactInformationFromPage(0);
            fromContPage = Regex.Replace(fromContPage, "[\r\n]", "");
            System.Console.Out.Write(fromContPage);
            Assert.AreEqual(fromContPage, dd);
        }
    }
}
