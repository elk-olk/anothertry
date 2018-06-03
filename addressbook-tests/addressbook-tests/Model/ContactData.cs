using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WebAddressBookTests
{
    public class ContactData : IEquatable <ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string contactDetailsInOneString;
        private string address;

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return LastName == other.LastName & FirstName == other.FirstName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (LastName.CompareTo(other.LastName) == 0)
            {
                return(FirstName.CompareTo(other.FirstName));

            }

            return LastName.CompareTo(other.LastName);
        }


        //public override int GetHashCode()
        //{
        //    return FirstName.GetHashCode() & LastName.GetHashCode(); 
        //}

        public ContactData()
        {
        }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public ContactData(string contactDetailsInOneString)
        {
            ContactDetailsInOneString = contactDetailsInOneString;
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Foto { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get { return CleanUp(address); } set { address = value; } }
        public string PhoneHome { get; set; }
        public string PhoneMobile { get; set; }
        public string PhoneWork { get; set; }
        public string Fax { get; set; }
        public string EMail1 { get; set; }
        public string EMail2 { get; set; }
        public string EMail3 { get; set; }
        public string HomePage { get; set; }
        public string BirthDay { get; set; }
        public string BirthMonth { get; set; }
        public string BirthYear { get; set; }
        public string AnnivDay { get; set; }
        public string AnnivMonth { get; set; }
        public string AnnivYear { get; set; }
        public string ContactGroup { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; }
        public string ContactNotes { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(PhoneHome) + CleanUp(PhoneMobile) + CleanUp(PhoneWork)+CleanUp(Phone2)).Trim();
                }
            }

            set
            {
                allPhones = value;
            }
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(EMail1) + CleanUp(EMail2) + CleanUp(EMail3)).Trim();
                }
            }

            set
            {
                allEmails = value;
            }
        }

        public string ContactDetailsInOneString
        {
            get
            {
                return CleanUpDetails(contactDetailsInOneString);       
            }

            set
            {
                contactDetailsInOneString = value;
            }
        }

        private string CleanUpDetails(string contactDetailsInOneString)
        {

            return contactDetailsInOneString.Replace(" ", "")
                                            .Replace("-", "")
                                            .Replace("(", "")
                                            .Replace(")", "")
                                            .Replace("H:", "")
                                            .Replace("W:", "")
                                            .Replace("M:", "")
                                            .Replace("F:", "")
                                            .Replace("P:", "")
                                            .Replace("Homepage:", "")
                                            .Replace("Birthday", "")
                                            .Replace("Anniversary", "")
                                            .Replace("\r\n", "")
                                            ;

        }

        private string CleanUp(string inputData)
        {
            if (inputData == null || inputData == "")
            {
                return "";
            }
            else
            {
                return inputData.Replace(" ", "")
                                .Replace("-", "")
                                .Replace("(", "")
                                .Replace(")", "")
                                .Replace("\r\n", "");
                                //+ "\r\n";
            }
        }
    }
}
