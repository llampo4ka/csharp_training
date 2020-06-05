
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            
            app.Navigate.GoToGroupsPage();
            GroupData newgroup = new GroupData("Gr-name");
            newgroup.Header = "gr-header";
            newgroup.Footer = "gr-footer";
            app.Groups
                .InitGroupCreation()
                .FillGroupForm(newgroup)
                .SubmitGroupButton()
                .ReturnToGroupsPage();
            app.LogoutHelper.Logout();
        }

    }
}
