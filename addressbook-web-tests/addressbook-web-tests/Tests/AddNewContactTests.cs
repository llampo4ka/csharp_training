
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class AddNewContactTests : TestBase
    {
        

        [Test]
        public void TheAddNewContactTest()
        {
            
            ContactData newcontact = new ContactData("f-name", "l-name");
            newcontact.MiddleName = "m-name";
            app.Contacts.CreateContact(newcontact);
            app.LogoutHelper.Logout();
        }

    }
}
