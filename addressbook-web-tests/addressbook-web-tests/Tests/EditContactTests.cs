using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class EditContactTests : ContactTestBase
    {
        [Test]
        public void EditContactTest()
        {
            app.Contacts.CheckContactExisting();

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldContact = oldContacts[0];

            ContactData newData = new ContactData("f-name123", "l-name123");
            newData.MiddleName = "m-name123";

            app.Contacts.EditContact(newData, oldContact.Id);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContact.FirstName = newData.FirstName;
            oldContact.LastName = newData.LastName;

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
