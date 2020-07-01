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
            string dd = fromForm.FirstName + " " + fromForm.LastName;

            if (fromForm.MiddleName != "")
            {
                dd = fromForm.FirstName + " " + fromForm.MiddleName + " " + fromForm.LastName;
            }

            if (fromForm.Address != "")
            {
                dd += "\r\n" + fromForm.Address;
            }

            dd += "\r\n\r\n"; 


            if (fromForm.HomePhone != "")
            {
                dd = dd + "H: " + fromForm.HomePhone + "\r\n";
            }
            if (fromForm.MobilePhone != "")
            {
                dd = dd + "M: " + fromForm.MobilePhone + "\r\n";
            }
            if (fromForm.WorkPhone != "")
            {
                dd = dd + "W: " + fromForm.WorkPhone + "\r\n";
            }

            if (fromForm.HomePhone != "" || fromForm.MobilePhone != "" || fromForm.WorkPhone != "")
            {
                dd += "\r\n";
            }

            if (fromForm.Email != "")
            {
                dd += fromForm.Email + "\r\n";
            }

            if (fromForm.Email2 != "")
            {
                dd += fromForm.Email2 + "\r\n";
            }

            if (fromForm.Email3 != "")
            {
                dd += fromForm.Email3 + "\r\n";
            }

            dd = dd.Trim();

            //System.Console.Out.Write(dd);
            string fromContPage = app.Contacts.GetContactInformationFromPage(0);
            
           // System.Console.Out.Write(fromContPage);
            Assert.AreEqual(fromContPage, dd);
        }
    }
}
