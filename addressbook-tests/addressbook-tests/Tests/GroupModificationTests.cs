using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("111");
            newData.Header = null;
            newData.Footer = null;

            if (!app.Groups.GroupExists())
            {
                app.Groups.CreateFirstGroup();
            }

            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData toBeModified = oldGroups[0];

            app.Groups.Modify(toBeModified, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupsCount());

            List<GroupData> newGroups = GroupData.GetAll(); 
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeModified.Id)
                {
                    Assert.AreEqual(toBeModified.Name, group.Name);
                }
            }
        }

    }
}
