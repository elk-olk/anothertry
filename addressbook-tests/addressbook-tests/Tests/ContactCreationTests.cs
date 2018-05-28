using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
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

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void AddContact(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactsListCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
