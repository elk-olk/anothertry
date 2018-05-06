﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemoval : TestBase
    {

        [Test]
        public void ContactRemovalTests()
        {
            app.Contacts.Remove("1");
        }
    }
}