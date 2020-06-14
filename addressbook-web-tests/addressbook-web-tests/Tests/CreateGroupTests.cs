
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class CreateGroupTests : TestBase
    {
        [Test]
        public void CreateNewGroupTest()
        {
            
            
            GroupData newgroup = new GroupData("Gr-name");
            newgroup.Header = "gr-header";
            newgroup.Footer = "gr-footer";
            app.Groups.CreateGroup(newgroup);
            app.LogoutHelper.Logout();
        }

    }
}
