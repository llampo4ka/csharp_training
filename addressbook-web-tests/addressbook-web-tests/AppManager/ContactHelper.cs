using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        
        public ContactHelper CreateContact (ContactData contact)
        {
            manager.Navigate.GoToAddNewPage();
            ContactData(contact);
            PressEnterContactButton();
            return this;
        }

        

        public ContactHelper EditContact(ContactData newData, int p)
        {
            manager.Navigate.OpenMainPage();
            PressEditIcon(p);
            ContactData(newData);
            PressUpdateButton();
            manager.Navigate.OpenMainPage();
            return this;
        }

        

        public ContactHelper DeleteContact(int p)
        {
            manager.Navigate.OpenMainPage();
            SelectContact(p);
            PressDeleteButton();
            ConfirmDeleting();
            return this;

        }

        

        public ContactHelper ContactData(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            /*driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys("nick");
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys("title");
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys("company");
            driver.FindElement(By.Name("fax")).Click();
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys("0293847");
            driver.FindElement(By.Name("homepage")).Click();
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys("site.ru");
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("16");
            driver.FindElement(By.Name("bday")).Click();
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("January");
            driver.FindElement(By.Name("bmonth")).Click();
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys("1987");
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("16");
            driver.FindElement(By.Name("aday")).Click();
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("January");
            driver.FindElement(By.Name("amonth")).Click();
            driver.FindElement(By.Name("ayear")).Click();
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys("1111");
            driver.FindElement(By.Name("new_group")).Click();
            driver.FindElement(By.Name("new_group")).Click();
            driver.FindElement(By.Name("new_group")).Click();
            new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText("Gr-name");
            driver.FindElement(By.Name("new_group")).Click();
            driver.FindElement(By.Name("new_group")).Click();
            new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText("[none]");
            driver.FindElement(By.Name("new_group")).Click();
            driver.FindElement(By.Name("address2")).Click();
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys("second addresssss");
            driver.FindElement(By.Name("phone2")).Click();
            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys("home");
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys("notes");*/
            return this;
        }

        public ContactHelper CheckContactExisting()
        {
            manager.Navigate.OpenMainPage();
            if (driver.FindElement(By.Id("search_count")).Text == "0")
            {
                CreateContact(new ContactData("name1", "surname1"));
            }
            return this;
        }

        public ContactHelper PressEnterContactButton()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper ConfirmDeleting()
        {
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper PressDeleteButton()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public ContactHelper PressUpdateButton()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper PressEditIcon(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index+1) + "]")).Click();
            return this;
        }

        private void PressManIcon(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
           
        }

        private List<ContactData> contactCache = null;
        public List<ContactData> GetContactsList()
        {
            if(contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigate.OpenMainPage();

                ICollection<IWebElement> listAllEntryTr = driver.FindElements(By.XPath("//tr[@name='entry']"));
                
                foreach (IWebElement element in listAllEntryTr)
                {
                    ReadOnlyCollection<IWebElement> eaa = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(eaa[2].Text, eaa[1].Text));
                }
               
            }

            return new List<ContactData>(contactCache);
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigate.OpenMainPage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };
        }

        public ContactData GetContactInformationFromForm(int index)
        {
            manager.Navigate.OpenMainPage();
            PressEditIcon(index);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");


            return new ContactData(firstName, lastName) {
                MiddleName = middleName,
                Address = address,
                HomePhone = homePhone,                
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public string GetContactInformationFromPage(int index)
        {
            manager.Navigate.OpenMainPage();
            PressManIcon(index);
            var datas = driver.FindElement(By.Id("content"));
            string datasText = datas.Text; 
            return datasText;
        }

        
    }
}
