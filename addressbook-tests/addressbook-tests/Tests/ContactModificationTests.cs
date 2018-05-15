using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData modifData = new ContactData("Maria", "Zueva");
                        modifData.NickName = "olk";
                        modifData.Address = "Kiev1";
                        modifData.Address2 = "Kiev2";
                        modifData.AnnivDay = "1";
                        modifData.AnnivMonth = "December";
                        modifData.AnnivYear = "2013";
                        modifData.BirthDay = "1";
                        modifData.BirthMonth = "August";
                        modifData.BirthYear = "1977";
                        modifData.Company = "Turbo";
                        modifData.ContactGroup = "[none]";
                        modifData.ContactNotes = "modyfied contact";
                        modifData.EMail1 = "olk@gmail.com";
                        modifData.EMail2 = "olk@rambler.ru";
                        modifData.EMail3 = "olk@ukr.net";
                        modifData.Fax = "+380444905512";
                        modifData.FirstName = "Maria";
                        //contact.Foto = "ava.jpg";
                        modifData.HomePage = "www.olk.com";
                        modifData.LastName = "Zueva";
                        modifData.MiddleName = "Vladimirovna";
                        modifData.Phone2 = "+3804449055123";
                        modifData.PhoneHome = "+380444905514";
                        modifData.PhoneMobile = "380634905515";
                        modifData.PhoneWork = "380444905516";
                        modifData.Title = "Mrs";
                        modifData.ContactGroup = null;

            if (!app.Contacts.ContactExists())
            {
                app.Contacts.CreateFirstContact();
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(modifData);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].FirstName = modifData.FirstName;
            oldContacts[0].LastName = modifData.LastName;

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
