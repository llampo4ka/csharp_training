
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class CreateGroupTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(15))
                {
                    Header = GenerateRandomString(30),
                    Footer = GenerateRandomString(26)
                });
            }
            return groups;
        }

       

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void CreateNewGroupTest(GroupData newgroup)
        {
            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups.CreateGroup(newgroup);

            oldGroups.Add(newgroup);
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            
        }

    }
}
