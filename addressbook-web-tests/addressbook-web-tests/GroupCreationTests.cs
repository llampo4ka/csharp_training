
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            OpenMainPage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData newgroup = new GroupData("Gr-name");
            newgroup.Header = "gr-header";
            newgroup.Footer = "gr-footer";
            FillGroupForm(newgroup);
            SubmitGroupButton();
            ReturnToGroupsPage();
            Logout();
        }

    }
}
