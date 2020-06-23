
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class CreateGroupTests : AuthTestBase
    {
        [Test]
        public void CreateNewGroupTest()
        {
            GroupData newgroup = new GroupData("Gr-name");
            newgroup.Header = "gr-header";
            newgroup.Footer = "gr-footer";

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
