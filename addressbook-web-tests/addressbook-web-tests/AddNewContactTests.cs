
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class AddNewContactTests : TestBase
    {
        

        [Test]
        public void TheAddNewContactTest()
        {
            OpenMainPage();
            Login(new AccountData("admin", "secret"));
            GoToAddNewPage();
            ContactData newcontact = new ContactData("f-name", "l-name");
            newcontact.MiddleName = "m-name";
            EnterContactButton();
            Logout();
        }

    }
}
