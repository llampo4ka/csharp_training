
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigate.OpenMainPage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigate.GoToGroupsPage();
            app.Groups.InitGroupCreation();
            GroupData newgroup = new GroupData("Gr-name");
            newgroup.Header = "gr-header";
            newgroup.Footer = "gr-footer";
            app.Groups.FillGroupForm(newgroup);
            app.Groups.SubmitGroupButton();
            app.Groups.ReturnToGroupsPage();
            app.LogoutHelper.Logout();
        }

    }
}
