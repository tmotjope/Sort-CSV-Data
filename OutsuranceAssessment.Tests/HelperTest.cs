using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutsuranceAssessment.Helpers;
using System.IO;
using Rhino.Mocks;
using System.Linq;

namespace OutsuranceAssessment.Tests
{
    [TestClass]
    public class HelperTest
    {
        private const string validData = "FirstName,LastName,Address,PhoneNumber\nJimmy,Smith,102 Long Lane,29384857\nClive,Owen,65 Ambling Way,31214788\nJames,Brown,82 Stewart St,32114566\nGraham,Howe,12 Howard St,8766556\nJohn,Howe,78 Short Lane,29384857\nClive,Smith,49 Sutherland St,31214788\nJames,Owen,8 Crimson Rd,32114566\nGraham,Brown,94 Roland St,8766556\n";
        private const string invalidData = "FirstName,LastName,Address,PhoneNumber\nJimmy,Smith,Long Lane,29384857\nClive,Owen,65Ambling Way,31214788\nJames,Brown,82 Stewart St,32114566\nGraham,Howe,12 Howard St,8766556\nJohn,Howe,78 Short Lane,29384857\nClive,Smith,49 Sutherland St,31214788\nJames,Owen,8 Crimson Rd,32114566\nGraham,Brown,94 Roland St,8766556\n";

        [TestMethod]
        public void TestCorrectData()
        {
            
            var testmodel = tools.ProcessFile(validData);
            Assert.AreEqual(102, testmodel.Addressess.FirstOrDefault().AddressNum);
        }

        [TestMethod]
        public void TestInvalidAddresssData()
        {
            try
            {
                
                var testmodel = tools.ProcessFile(invalidData);

                Assert.AreEqual(102, testmodel.Addressess.FirstOrDefault().AddressNum);
                Assert.AreEqual("Long Lane", testmodel.Addressess.FirstOrDefault().AdressStreet);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Input string was not in a correct format.", ex.Message);
            }
        }
    }
}
