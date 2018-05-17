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
        [Test]
        public void AddContact()
        {
            ContactData contact = new ContactData("Tamila", "Steblevska");
            contact.NickName = "stv";
            contact.Address = "Kiev1";
            contact.Address2 = "Kiev2";
            contact.AnnivDay = "1";
            contact.AnnivMonth = "December";
            contact.AnnivYear = "2013";
            contact.BirthDay = "1";
            contact.BirthMonth = "August";
            contact.BirthYear = "1977";
            contact.Company = "Turbo";
            contact.ContactGroup = "[none]";
            contact.ContactNotes = "olk notes";
            contact.EMail1 = "olk@gmail.com";
            contact.EMail2 = "olk@rambler.ru";
            contact.EMail3 = "olk@ukr.net";
            contact.Fax = "+380444905512";
            contact.FirstName = "Tamila";
            //contact.Foto = "ava.jpg";
            contact.HomePage = "www.olk.com";
            contact.LastName = "Steblevska";
            contact.MiddleName = "Vladimirovna";
            contact.Phone2 = "+3804449055123";
            contact.PhoneHome = "+380444905514";
            contact.PhoneMobile = "380634905515";
            contact.PhoneWork = "380444905516";
            contact.Title = "Mrs";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
