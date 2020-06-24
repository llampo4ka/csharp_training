using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class CreateContactTests : AuthTestBase
    {
        [Test]
        public void CreateNewContactTest()
        {
            ContactData newcontact = new ContactData("onef-name", "twol-name");
            newcontact.MiddleName = "m-name";
            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.CreateContact(newcontact);

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.Add(newcontact);

            System.Console.WriteLine("Old List");
            foreach (var item in oldContacts)
            {
                System.Console.Write(item.FirstName + " - " + item.LastName);
            }

            System.Console.WriteLine();
            System.Console.WriteLine("New List");
            foreach (var item in newContacts)
            {
                System.Console.Write(item.FirstName + " - " + item.LastName);
            }

            oldContacts.Sort();
            newContacts.Sort();
           
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
