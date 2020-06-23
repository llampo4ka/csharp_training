using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class EditContactTests : AuthTestBase
    {
        [Test]
        public void EditContactTest()
        {
            app.Contacts.CheckContactExisting();
            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            ContactData newData = new ContactData("f-name123", "l-name123");
            newData.MiddleName = "m-name123";

            app.Contacts.EditContact(newData, 0);

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
