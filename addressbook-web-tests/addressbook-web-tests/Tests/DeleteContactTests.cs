using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class DeleteContactTests : TestBase
    {
        [Test]
        public void DeleteContactTest()
        {
            app.Contacts.DeleteContact(1);
            app.LogoutHelper.Logout();

        }
    }
}
