using OutsuranceAssessment.Helpers;
using OutsuranceAssessment.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsuranceAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            string error = string.Empty;

            Console.WriteLine("Reading the file");

            //Read file contents
            var fileContents = tools.GetFileContents();

            // Check for nulls
            if (fileContents.Length == 0)
            {
                Console.WriteLine("Error occured while reading file");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Reading done");
            }

            //Process data
            try
            {
                var model = tools.ProcessFile(fileContents);
                // Print results
                PrintResults(tools.OrderByFrequency(model.Names), "Frequency file list ");
                PrintResults(tools.OrderByAddress(model.Addressess), "Addresses file list");

                Console.WriteLine("Done");
            }
            catch
            {
                
                Console.WriteLine("Error Occured");
            }
            finally
            {
                Console.ReadKey();
                
            }


            
        }

        private static void PrintResults(List<Address> addressList, string heading)
        {
            Console.WriteLine(heading);
            foreach(Address item in addressList)
            {
                Console.WriteLine(item.AddressRecord);
            }
        }

        private static void PrintResults(List<GroupedFrequencyDTO> groupedList, string heading)
        {
            Console.WriteLine(heading);
            foreach (GroupedFrequencyDTO item in groupedList)
            {
                Console.WriteLine(item.GRecord);
            }
        }     




    }
}
