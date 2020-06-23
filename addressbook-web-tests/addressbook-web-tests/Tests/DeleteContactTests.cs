using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class DeleteContactTests : AuthTestBase
    {
        [Test]
        public void DeleteContactTest()
        {
            app.Contacts.CheckContactExisting();
            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.DeleteContact(0);
            
            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.RemoveAt(0);

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
