﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string middlename = "";
        private string lastname;
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string homePhone = "";
        private string mobilePhone = "";
        private string workPhone = "";
        private string fax = "";
        private string homepage = "";
        private string bday = "";
        private string bmonth = "";
        private string byear = "";
        private string aday = "";
        private string amonth = "";
        private string ayear = "";
        private string new_group = "";
        private string address2 = "";
        private string phone2 = "";
        private string notes="";

        public ContactData (string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

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

            if (FirstName == other.FirstName)
            {
                return  LastName == other.LastName;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
        }

        public override string ToString()
        {
            return "name= " + FirstName + " lastname=" + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (LastName.CompareTo(other.LastName) == 0)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            
            return LastName.CompareTo(other.LastName);

        }

        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

    }
}
