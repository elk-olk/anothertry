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
            ContactData newcData = new ContactData("OLK");
            newcData.NickName = "olk";
            newcData.Address = "Kiev1";
            newcData.Address2 = "Kiev2";
            newcData.AnnivDay = "1";
            newcData.AnnivMonth = "December";
            newcData.AnnivYear = "2013";
            newcData.BirthDay = "1";
            newcData.BirthMonth = "August";
            newcData.BirthYear = "1977";
            newcData.Company = "Turbo";
            newcData.ContactGroup = "[none]";
            newcData.ContactNotes = "olk notes";
            newcData.EMail1 = "olk@gmail.com";
            newcData.EMail2 = "olk@rambler.ru";
            newcData.EMail3 = "olk@ukr.net";
            newcData.Fax = "+380444905512";
            newcData.FirstName = "Elena";
            //contact.Foto = "ava.jpg";
            newcData.HomePage = "www.olk.com";
            newcData.LastName = "Steblevska";
            newcData.MiddleName = "Vladimirovna";
            newcData.Phone2 = "+3804449055123";
            newcData.PhoneHome = "+380444905514";
            newcData.PhoneMobile = "380634905515";
            newcData.PhoneWork = "380444905516";
            newcData.Title = "Mrs";
            newcData.ContactGroup = null;

            app.Contacts.Modify("1", newcData);
        }

    }
}
