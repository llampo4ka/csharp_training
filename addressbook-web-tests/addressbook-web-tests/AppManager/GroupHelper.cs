using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace addressbook_web_tests
{
    public class GroupHelper : HelperBase
    {
        
        public GroupHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public GroupHelper CreateGroup(GroupData group)
        {
            manager.Navigate.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupButton();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper EditGroup(GroupData newData, int p)
        {
            manager.Navigate.GoToGroupsPage();
            SelectGroupInList(p);
            SubmitEditGroup();
            FillGroupForm(newData);
            SubmitModification();
            manager.Navigate.GoToGroupsPage();
            return this;
        }

        public GroupHelper DeleteGroup (int p)
        {
            manager.Navigate.GoToGroupsPage();

            

            SelectGroupInList(p);
            PressDeleteButton();
            ReturnToGroupsPage();
            return this;

        }

        public GroupHelper SubmitEditGroup()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper PressDeleteButton()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SelectGroupInList(int index)
        {
            if (IsElementPresent(By.Name("selected[]")) == false)
            {
                CreateGroup(new GroupData("gr-name"));
                manager.Navigate.GoToGroupsPage();
            }
            driver.FindElement(By.XPath("(//input[@name='selected[]'])["+index+"]")).Click();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }


        public GroupHelper FillGroupForm(GroupData group)
        {
            
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        

        public GroupHelper SubmitGroupButton()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }
        
    }
}
