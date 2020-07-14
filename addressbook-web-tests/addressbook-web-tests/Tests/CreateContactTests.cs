using NUnit.Framework;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace addressbook_web_tests
{
    [TestFixture]
    public class CreateContactTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(15), GenerateRandomString(15))
                {
                    MiddleName = GenerateRandomString(30)
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)
                 new XmlSerializer(typeof(List<ContactData>))
                     .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void CreateNewContactTest(ContactData newcontact)
        {
            /*ContactData newcontact = new ContactData("23f-name", "23l-name")
            {
                MiddleName = "m-name23",
                Address = "Str SGhd 12, ap 36",
                MobilePhone = "+7 (2374) 2-4-5",
                WorkPhone = "9(938) 2-3-4",
                Email = "test@tse.ted"
            };*/
            
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
