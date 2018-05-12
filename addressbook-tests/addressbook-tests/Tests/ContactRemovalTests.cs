using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemoval : AuthTestBase
    {

        [Test]
        public void ContactRemovalTests()
        {
            if (!app.Contacts.ContactExists())
            {
                app.Contacts.CreateFirstContact();
            }
            app.Contacts.Remove(1);
        }
    }
}
