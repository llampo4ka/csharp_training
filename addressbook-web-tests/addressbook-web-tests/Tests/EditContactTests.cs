using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class EditContactTests : AuthTestBase
    {
        [Test]
        public void EditContactTest()
        {
            app.Contacts.CheckContactExisting();

            ContactData newData = new ContactData("f-name123", "l-name123");
            newData.MiddleName = "m-name123";

            app.Contacts.EditContact(newData, 1);
            app.Auth.Logout();
        }

    }
}
