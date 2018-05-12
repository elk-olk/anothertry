using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTest: AuthTestBase
    {
 
        [Test]
        public void GroupRemovalTests()
        {
            if (!app.Groups.GroupExists())
            {
                app.Groups.CreateFirstGroup();
            }
            app.Groups.Remove(1);
        }
    }
}
