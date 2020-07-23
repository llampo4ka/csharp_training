using System;
using System.Collections.Generic;
using OpenQA.Selenium;

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

        public GroupHelper EditGroup(GroupData newData, string id)
        {
            manager.Navigate.GoToGroupsPage();
            SelectGroupInList(id);
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

        public GroupHelper DeleteGroup(GroupData group)
        {
            manager.Navigate.GoToGroupsPage();
            SelectGroupInList(group.Id);
            PressDeleteButton();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper CheckGroupExisting()
        {
            manager.Navigate.GoToGroupsPage();

            if (IsElementPresent(By.Name("selected[]")) == false)
            {
                CreateGroup(new GroupData("gr-name"));
            }
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
            groupCache = null;
            return this;
        }

        public GroupHelper PressDeleteButton()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroupInList(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])["+ (index+1)+"]")).Click();
            return this;
        }

        public GroupHelper SelectGroupInList(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'and @value='" + id + "'])")).Click();
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
            groupCache = null;
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        private List<GroupData> groupCache = null;
        public List<GroupData> GetGroupsList()
        {
            if(groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigate.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text));
                }
            }

            return new List<GroupData>(groupCache);
        }

    }
}
