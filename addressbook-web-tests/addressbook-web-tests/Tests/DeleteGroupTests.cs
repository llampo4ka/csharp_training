using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class DeleteGroupTests : AuthTestBase
    {
        [Test]
        public void DeleteGroupTest()
        {
            app.Groups.CheckGroupExisting();
            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups.DeleteGroup(0);

            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
