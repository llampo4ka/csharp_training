using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class CreateContactTests : AuthTestBase
    {
        [Test]
        public void CreateNewContactTest()
        {
            ContactData newcontact = new ContactData("f-name", "l-name");
            newcontact.MiddleName = "m-name";
            app.Contacts.CreateContact(newcontact);
            app.Auth.Logout();
        }

    }
}
