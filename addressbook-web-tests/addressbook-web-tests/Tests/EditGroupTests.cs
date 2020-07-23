using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class EditGroupTests : GroupTestBase
    {
        [Test]
        public void EditGroupTest()
        {
            app.Groups.CheckGroupExisting();

            GroupData newData = new GroupData("Gr-name22");
            newData.Header = "gr-header22";
            newData.Footer = "gr-footer22";

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            app.Groups.EditGroup(newData, oldData.Id);

            List<GroupData> newGroups = GroupData.GetAll();
            //oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);


        }
    }
}
