using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    class DeleteContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void DeleteContactFromGroupTest()
        {
            app.Groups.CheckGroupExisting();
            app.Contacts.ExistingContactsCheck();
            
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            if (oldList.Count == 0)
            {
                ContactData cont = ContactData.GetAll()[0];
                app.Contacts.AddContactToGroup(cont, group);
                oldList = group.GetContacts();
            }

            ContactData contact = oldList.First();
            System.Console.Out.WriteLine(group.Name);
            System.Console.Out.WriteLine(contact.FirstName);

            app.Contacts.DeleteContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();

            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);

            foreach (ContactData cont in newList)
            {
                Assert.AreNotEqual(cont.Id, contact.Id);
            }


        }
    }
}
