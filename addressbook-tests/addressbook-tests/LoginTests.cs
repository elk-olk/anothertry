using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            //app.Auth.Logout();

            AccountData account = new AccountData("admin","secret");
            app.Auth.Login(account);

            //Assert.IsTrue(app.Auth.IsLoggedIn());
        }

        [Test]
        public void LoginWithInalidCredentials()
        {
            //app.Auth.Logout();

            AccountData account = new AccountData("admin", "132231");

            app.Auth.Login(account);
            //Assert.IsFalse(app.Auth.IsLoggedIn());
        }
    }
}
