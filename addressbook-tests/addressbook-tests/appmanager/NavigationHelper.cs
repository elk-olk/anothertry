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
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL)
            :base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/groups.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToHomePage()
        {

            if (driver.Url == baseURL + "/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        public void GoToAddNewContact()
        {
            if (driver.Url == baseURL + "/addressbook/edit.php")
            {
                return;
            }
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void GoToContactsPage()
        {
            if (driver.Url == baseURL + "/addressbook/index.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/index.php");
        }
    }
}
