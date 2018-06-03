using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactData (GenerateRandomString(10), GenerateRandomString(10))
                {
                    Address = GenerateRandomString(10),
                    Address2 = GenerateRandomString(10),
                    AnnivDay = "1",
                    AnnivMonth = "December",
                    AnnivYear = "2013",
                    BirthDay = "1",
                    BirthMonth = "August",
                    BirthYear = "1977",
                    ContactGroup = "[none]",
                    ContactNotes = GenerateRandomString(10),
                    EMail1 = "olk@gmail.com",
                    EMail2 = "olk@rambler.ru",
                    EMail3 = "olk@ukr.net",
                    Fax = GenerateRandomString(10),
                    HomePage = "www.olk.com",
                    NickName = GenerateRandomString(10),
                    MiddleName = GenerateRandomString(10),
                    Title = "Mrs",
                    Company = "Turbo",
                    Phone2 = "+3804449055123",
                    PhoneHome = "+380444905514",
                    PhoneMobile = "380634905515",
                    PhoneWork = "380444905516"
                });
            }
            return contact;
        }

        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1])
                {
                    FirstName = parts[0],
                    LastName = parts[1],
                    Address = parts[2],
                    Address2 = parts[3],
                    AnnivDay = parts[4],
                    AnnivMonth = parts[5],
                    AnnivYear = parts[6],
                    BirthDay = parts[7],
                    BirthMonth = parts[8],
                    BirthYear = parts[9],
                    ContactGroup = parts[10],
                    ContactNotes = parts[11],
                    EMail1 = parts[12],
                    EMail2 = parts[13],
                    EMail3 = parts[14],
                    Fax = parts[15],
                    HomePage = parts[16],
                    NickName = parts[17],
                    MiddleName = parts[18],
                    Title = parts[19],
                    Company = parts[20],
                    Phone2 = parts[21],
                    PhoneHome = parts[22],
                    PhoneMobile = parts[23],
                    PhoneWork = parts[24]
                });
            }
            return contacts;

        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            List<ContactData> groups = new List<ContactData>();
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
        public void AddContact(ContactData contact)
        {
            List<ContactData> oldContacts = ContactData.GetAll();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactsListCount());
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
