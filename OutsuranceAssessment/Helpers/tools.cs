using OutsuranceAssessment.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsuranceAssessment.Helpers
{
    public static class tools
    {
        public static List<Address> OrderByAddress(List<Address> addresses)
        {
            var result = addresses.OrderBy(a => a.AdressStreet).ThenBy(a=> a.AddressNum).ToList();
            return result;
        }

        public static List<GroupedFrequencyDTO> OrderByFrequency(List<UserName> names)
        {
            var result = names.GroupBy(n => n.UName)
            .Select(group =>
                         new GroupedFrequencyDTO
                         {
                             GName = group.Key,
                             GCount = group.Count()
                         }).OrderByDescending(c => c.GCount).ThenByDescending(c => c.GName).ToList();
            return result;
        }



        public static string GetFileContents()
        {
            string relativePath = ConfigurationManager.AppSettings["filePath"];
            

            using (var fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath), FileMode.Open))
            {
                var sr = new StreamReader(fs);
                return sr.ReadToEnd();
            }
        }

        public static DataDTO ProcessFile(string filecontents)
        {
            List<UserName> listOfName = new List<UserName>();
            List<Address> listOfAddress = new List<Address>();
            
        
            string[] contents = filecontents.Split('\n');

            for (int i = 1; i < contents.Length - 1; i++)
            {
                string[] temp = contents[i].Split(new char[] { ',' }, StringSplitOptions.None);
                for (int j = 0; j < 2; j++)
                {
                    listOfName.Add(new UserName { UName = temp[j] });
                }
            
                listOfAddress.Add(ExtractAddresses(temp[2]));
            }
            return new DataDTO() { Addressess = listOfAddress, Names = listOfName };
        }

        public static Address ExtractAddresses(string addressRow)
        {
            try
            {
                var tempAddress = addressRow.Split(new[] { ' ' }, 2);
                return new Address { AddressNum = Convert.ToInt32(tempAddress[0]), AdressStreet = tempAddress[1] };
            }
            catch (IndexOutOfRangeException ex)
            {
                throw (new Exception("Input string was not in a correct format."));
            }
        }

    }
}
