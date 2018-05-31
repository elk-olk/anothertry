using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressBookTests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];
            string typeofdata = args[3];
            if (typeofdata == "groups")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(100),
                        Footer = TestBase.GenerateRandomString(100)
                    });
                }
                if (format == "csv")
                {
                    WriteGroupsToCsvFile(groups, writer);
                }
                else if (format == "json")
                {
                    WriteGroupsToJsonFile(groups, writer);
                }
                else if (format == "xml")
                {
                    WriteGroupsToXmlFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }
            }

            else if (typeofdata == "contacts")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10))
                    {
                        Address = TestBase.GenerateRandomString(10),
                        Address2 = TestBase.GenerateRandomString(10),
                        AnnivDay = "1",
                        AnnivMonth = "December",
                        AnnivYear = "2013",
                        BirthDay = "1",
                        BirthMonth = "August",
                        BirthYear = "1977",
                        ContactGroup = "[none]",
                        ContactNotes = TestBase.GenerateRandomString(10),
                        EMail1 = "olk@gmail.com",
                        EMail2 = "olk@rambler.ru",
                        EMail3 = "olk@ukr.net",
                        Fax = TestBase.GenerateRandomString(10),
                        HomePage = "www.olk.com",
                        NickName = TestBase.GenerateRandomString(10),
                        MiddleName = TestBase.GenerateRandomString(10),
                        Title = "Mrs",
                        Company = "Turbo",
                        Phone2 = "+3804449055123",
                        PhoneHome = "+380444905514",
                        PhoneMobile = "380634905515",
                        PhoneWork = "380444905516"
                    });
                }
                if (format == "csv")
                {
                    WriteContactsToCsvFile(contacts, writer);
                }
                //else if (format == "json")
                //{
                //    WriteContactsToCsvFile(contacts, writer);
                //}
                //else if (format == "xml")
                //{
                //    WriteContactsToCsvFile(contacts, writer);
                //}
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }
            }
            else
            {
                System.Console.Out.Write("Unrecognized type of data " + typeofdata);
            }



            writer.Close();
        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                            group.Name, group.Header, group.Footer));
            }
        }

        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${3},${4},${5},${6},${7},${8},${9},${10},${11},${12},${13},${14},${15},${16},${17}${18},${19},${20},${21},${22}",
                    contact.Address,
                    contact.Address2,
                    contact.AnnivDay,
                    contact.AnnivMonth,
                    contact.AnnivYear,
                    contact.BirthDay,
                    contact.BirthMonth,
                    contact.BirthYear,
                    contact.ContactGroup,
                    contact.ContactNotes,
                    contact.EMail1,
                    contact.EMail2,
                    contact.EMail3,
                    contact.Fax,
                    contact.HomePage,
                    contact.NickName,
                    contact.MiddleName,
                    contact.Title,
                    contact.Company,
                    contact.Phone2,
                    contact.PhoneHome,
                    contact.PhoneMobile,
                    contact.PhoneWork
                    ));
            }
        }

    }
}
