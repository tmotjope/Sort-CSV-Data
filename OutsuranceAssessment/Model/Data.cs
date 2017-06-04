using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsuranceAssessment.Model
{
    public class DataDTO
    {
        public List<UserName> Names { get; set; }
        public List<Address> Addressess { get; set; }
    }

    public class GroupedFrequencyDTO
    {
        public string GName { get; set; }
        public int GCount { get; set; }
        public string GRecord
        {
            get
            {
                return GName + ", " + GCount;
            }
        }
    }

    public class UserName
    {
        public string UName { get; set; }
    }

    public class Address
    {
        public int AddressNum { get; set; }
        public string AdressStreet { get; set; }
        public string AddressRecord
        {
            get
            {
                return AddressNum + " " + AdressStreet;
            }
        }
    }
}
