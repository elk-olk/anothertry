using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        private bool acceptNextAlert = true;

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToAddNewContact();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper Remove(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(index);
            DeleteContact();
            CloseAlertAndGetItsText();
            return this;
        }

        public ContactHelper Modify(string id, ContactData newcData)
        {
            manager.Navigator.GoToContactsPage();
            ClickModifyContact();
            FillContactForm(newcData);
            ClickUpdateContact();
            ReturnToHomePage();
            return this;
        }

        private ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        private ContactHelper ClickUpdateContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }

        private ContactHelper ClickModifyContact()
        {
           
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.LinkText("home")).Click();
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("nickname"), contact.NickName);
            Type(By.Name("photo"), contact.Foto);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.PhoneHome);
            Type(By.Name("mobile"), contact.PhoneMobile);
            Type(By.Name("work"), contact.PhoneWork);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.EMail1);
            Type(By.Name("email2"), contact.EMail2);
            Type(By.Name("email3"), contact.EMail3);
            Type(By.Name("homepage"), contact.HomePage);
            SelectElements(By.Name("bday"), contact.BirthDay);
            SelectElements(By.Name("bmonth"), contact.BirthMonth);
            Type(By.Name("byear"), contact.BirthYear);
            SelectElements(By.Name("aday"), contact.AnnivDay);
            SelectElements(By.Name("amonth"), contact.AnnivMonth);
            Type(By.Name("ayear"), contact.AnnivYear);
            SelectElements(By.Name("new_group"), contact.ContactGroup);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.ContactNotes);
            return this;

        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Enter']")).Click();
            return this;
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        public bool ContactExists()
        {
            manager.Navigator.GoToContactsPage();
            return IsElementPresent(By.CssSelector("img[alt=\"Edit\"]"));
        }

        public ContactHelper CreateFirstContact()
        {
            ContactData firstContact = new ContactData("ART");
            firstContact.NickName = "ART";
            firstContact.FirstName = "Elena";
            firstContact.MiddleName = "Igorevna";
            firstContact.LastName = "Denega";
            firstContact.ContactNotes = "first test contact";
            manager.Navigator.GoToAddNewContact();
            FillContactForm(firstContact);
            SubmitContactCreation();
            return this;
        }

    }
}
