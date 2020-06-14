using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class EditContactTests : TestBase
    {
        [Test]
        public void EditContactTest()
        {
            ContactData newData = new ContactData("f-name123", "l-name123");
            newData.MiddleName = "m-name123";
            app.Contacts.EditContact(newData, 1);
            app.LogoutHelper.Logout();
        }

    }
}
