using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class EditGroupTests : TestBase
    {
        [Test]
        public void EditGroupTest()
        {
            GroupData newData = new GroupData("Gr-name22");
            newData.Header = "gr-header22";
            newData.Footer = "gr-footer22";

            app.Groups.EditGroup(newData, 1);
            app.LogoutHelper.Logout();

        }
    }
}
