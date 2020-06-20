using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class DeleteContactTests : AuthTestBase
    {
        [Test]
        public void DeleteContactTest()
        {
            app.Contacts.DeleteContact(1);
            app.Auth.Logout();

        }
    }
}
