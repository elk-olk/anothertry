using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTest:TestBase
    {
 
        [Test]
        public void GroupRemovalTests()
        {
            app.Groups.Remove(1);
        }
    }
}
