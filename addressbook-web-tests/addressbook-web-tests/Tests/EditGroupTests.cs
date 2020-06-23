using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class EditGroupTests : AuthTestBase
    {
        [Test]
        public void EditGroupTest()
        {
            app.Groups.CheckGroupExisting();

            GroupData newData = new GroupData("Gr-name22");
            newData.Header = "gr-header22";
            newData.Footer = "gr-footer22";
            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups.EditGroup(newData, 0);

            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);


        }
    }
}
