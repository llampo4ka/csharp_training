using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class DeleteGroupTests : AuthTestBase
    {
        [Test]
        public void DeleteGroupTest()
        {
            app.Groups.DeleteGroup(1);
            app.Auth.Logout();
        }
    }
}
