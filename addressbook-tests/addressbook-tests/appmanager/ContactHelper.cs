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
            SubmitContactDelete();
            CloseAlertAndGetItsText();
            return this;
        }

        public ContactHelper Modify(ContactData newcData)
        {
            manager.Navigator.GoToContactsPage();
            ClickModifyContact();
            FillContactForm(newcData);
            SubmitContactUpdate();
            ReturnToHomePage();
            return this;
        }

        private ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        private ContactHelper SubmitContactUpdate()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            contactCache = null;
            return this;
        }

        private ContactHelper ClickModifyContact()
        {
           
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }

        public  int GetContactsListCount()
        {
            manager.Navigator.GoToContactsPage();
            return driver.FindElements(By.XPath("//tr[@name = 'entry']")).Count;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                List<ContactData> contactsList = new List<ContactData>();
                manager.Navigator.GoToContactsPage();

                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name = 'entry']//td"));

                for (int i = 2; i <= elements.Count;)

                {
                    contactCache.Add(new ContactData(elements.ElementAt(i).Text, elements.ElementAt(i - 1).Text));
                    i = i + 10;
                }

            }
            return new List<ContactData>(contactCache);
        }


        public ContactHelper SubmitContactDelete()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.LinkText("home")).Click();
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
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
            contactCache = null;
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
            ContactData firstContact = new ContactData("Elena", "Denega");
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
