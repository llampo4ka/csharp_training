using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class DeleteContactTests : ContactTestBase
    {
        [Test]
        public void DeleteContactTest()
        {
            app.Contacts.ExistingContactsCheck();

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.DeleteContact(toBeRemoved);
            
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }
    }
}
