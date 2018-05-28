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

        public ContactData GetContactInfoFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        public ContactData GetContactInfoFromDetailsForm(int index)
        {
            manager.Navigator.GoToHomePage();
            ClickContactDetails(index);

            IWebElement block = driver.FindElement(By.Id("content"));
            string details = block.Text; 
            return new ContactData(details);
        }



        public ContactData GetContactInfoFromEditFormCompareToDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            ClickModifyContact(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string birthDay = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string birthMonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string birthYear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string annivDay = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string annivMonth = driver.FindElement(By.Name("amonth")).GetAttribute("value");
            string annivYear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");
            int age = (DateTime.Today - Convert.ToDateTime(birthYear + birthMonth + birthDay)).Days/365;
            int anniv = (DateTime.Today - Convert.ToDateTime(annivYear + annivMonth + annivDay)).Days/365;

            string contactDetails = (firstName + middleName + lastName).Trim() 
                                  + nickName 
                                  + title
                                  + company 
                                  + address 
                                  + homePhone 
                                  + mobilePhone 
                                  + workPhone
                                  + fax
                                  + email1  
                                  + email2
                                  + email3 
                                  + homePage  
                                  + birthDay + (".")+ birthMonth + birthYear 
                                  + age
                                  + annivDay + (".")+ annivMonth + annivYear 
                                  + anniv
                                  + address2 
                                  + phone2 
                                  + notes;

            return new ContactData(contactDetails);

        }

        public ContactData GetContactInfoFromEditFormCompareToTable(int index)
        {
            manager.Navigator.GoToHomePage();
            ClickModifyContact(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                PhoneHome = homePhone,
                PhoneMobile = mobilePhone,
                PhoneWork = workPhone,
                Phone2 = phone2,
                EMail1 = email1,
                EMail2 = email2,
                EMail3 = email3
            }; 

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

        public ContactHelper Modify(ContactData newcData, int index)
        {
            manager.Navigator.GoToContactsPage();
            ClickModifyContact(index);
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

        private ContactHelper ClickModifyContact(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a"))
                .Click();
            return this;
        }

        private ContactHelper ClickContactDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                  .FindElements(By.TagName("td"))[6]
                  .FindElement(By.TagName("a"))
                  .Click();
            return this;
        }
        public  int GetContactsListCount()
        {
            manager.Navigator.GoToContactsPage();
            return driver.FindElements(By.Name("entry")).Count;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                IList<ContactData> contactsList = new List<ContactData>();
                manager.Navigator.GoToContactsPage();

                IList<IWebElement> rows = driver.FindElements(By.Name("entry"));

                foreach (IWebElement row in rows)
                {
                    IList<IWebElement> cells = row.FindElements(By.TagName("td"));
                    string lastName = cells[1].Text;
                    string firstName = cells[2].Text;
                    contactCache.Add(new ContactData(firstName, lastName));
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
