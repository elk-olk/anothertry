using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemoval : ContactTestBase
    {

        [Test]
        public void ContactRemovalTests()
        {
            if (!app.Contacts.ContactExists())
            {
                app.Contacts.CreateFirstContact();
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove(toBeRemoved);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsListCount());
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

   }
}
