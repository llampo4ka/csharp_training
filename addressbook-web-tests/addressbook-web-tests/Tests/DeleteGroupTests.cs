using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class DeleteGroupTests : AuthTestBase
    {
        [Test]
        public void DeleteGroupTest()
        {
            app.Groups.DeleteGroup(2);
            app.Auth.Logout();
        }
    }
}
