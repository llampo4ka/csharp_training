
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

            app.Groups.CreateGroup(newgroup);

            //List<GroupData> groups = app.Groups.GetGroupsList();
            
        }

    }
}
