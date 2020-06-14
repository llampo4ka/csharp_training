using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class DeleteGroupTests : TestBase
    {
        [Test]
        public void DeleteGroupTest()
        {
            app.Groups.DeleteGroup(2);
            app.LogoutHelper.Logout();
        }
    }
}
