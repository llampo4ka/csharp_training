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
            ContactData newcontact = new ContactData("23f-name", "23l-name")
            {
                MiddleName = "m-name23",
                Address = "Str SGhd 12, ap 36",
                MobilePhone = "+7 (2374) 2-4-5",
                WorkPhone = "9(938) 2-3-4",
                Email = "test@tse.ted"
            };
            
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
