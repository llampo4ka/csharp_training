
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class AddNewContactTests : TestBase
    {
        

        [Test]
        public void TheAddNewContactTest()
        {
            app.Navigate.OpenMainPage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigate.GoToAddNewPage();
            ContactData newcontact = new ContactData("f-name", "l-name");
            newcontact.MiddleName = "m-name";
            app.Contacts.EnterContactButton();
            app.LogoutHelper.Logout();
        }

    }
}
