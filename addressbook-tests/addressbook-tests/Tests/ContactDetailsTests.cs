using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


// Compare Contact information from the  Edit Contact  page with Contact details page

namespace WebAddressBookTests
{
    [TestFixture]
    class ContactDetailsTests : AuthTestBase
    {
        [Test]

        public void TestContactInformation()
        {
            ContactData fromDetailsForm = app.Contacts.GetContactInfoFromDetailsForm(0);
            ContactData fromEditForm = app.Contacts.GetContactInfoFromEditFormCompareToDetails(0);

            Assert.AreEqual(fromDetailsForm.ContactDetailsInOneString, fromEditForm.ContactDetailsInOneString);
        }

    }
}
