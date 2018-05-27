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


        public override int GetHashCode()
        {
            return FirstName.GetHashCode() & LastName.GetHashCode(); 

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
                    return (CleanUp(FirstName) + CleanUp(MiddleName) + CleanUp(LastName) +("\r\n")
                         + CleanUp(NickName) + ("\r\n")
                         + CleanUp(Title) + ("\r\n")
                         + CleanUp(Company) + ("\r\n")
                         + CleanUp(Address) + ("\r\n")
                         + CleanUp(PhoneHome) + ("\r\n")
                         + CleanUp(PhoneMobile) + ("\r\n")
                         + CleanUp(PhoneWork) + ("\r\n")
                         + CleanUp(Fax) + ("\r\n")
                         + CleanUp(EMail1) + ("\r\n")
                         + CleanUp(EMail2) + ("\r\n")
                         + CleanUp(EMail3) + ("\r\n")
                         + CleanUp(HomePage) + ("\r\n")
                         + CleanUp(BirthDay)+ CleanUp(BirthMonth)+CleanUp(BirthYear) + ("\r\n")
                         + CleanUp(AnnivDay)+ CleanUp(AnnivMonth) + CleanUp(AnnivYear) + ("\r\n")
                         + CleanUp(Address2) + ("\r\n")
                         + CleanUp(Phone2) + ("\r\n")
                         + CleanUp(ContactNotes))
                         .Trim();
                
            }

            set
            {
                contactDetailsInOneString = value;
            }
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
                                + "\r\n";
            }
        }
    }
}
