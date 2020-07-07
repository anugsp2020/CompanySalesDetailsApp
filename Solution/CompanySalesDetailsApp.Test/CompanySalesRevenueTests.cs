using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using CompanySalesDetailsApp;
using System.Linq;
using System.Text;

namespace CompanySalesDetailsApp.Test
{
    [TestFixture]
    public class CompanySalesRevenueTests
    {
        Assembly assembly;
        Type className;

        [SetUp]
        public void SetUp()
        {
            assembly = Assembly.Load("CompanySalesDetailsApp");
            className = assembly.GetType("CompanySalesDetailsApp.CompanySalesRevenue");
        }

        [Test]
        public void GetCompanySalesDetails_MethodInclusion_ReturnsNotNull()
        {
            var allBindings = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

            if (className != null)
            {
                var method = className.GetMethod("GetCompanySalesDetails", allBindings);

                Assert.That(method != null, "Method GetCompanySalesDetails is not implemented or check spelling");
            }
            else
            {
                Assert.Fail("No class with the name 'CompanySalesRevenue' is implemented Or the class name is wrong");
            }
        }

        [Test]
        public void DisplayCompaniesRevenueInOrder_MethodInclusion_ReturnsNotNull()
        {
            var allBindings = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

            if (className != null)
            {
                var method = className.GetMethod("DisplayCompaniesRevenueInOrder", allBindings);

                Assert.That(method != null, "Method DisplayCompaniesRevenueInOrder is not implemented or check spelling");
            }
            else
            {
                Assert.Fail("No class with the name 'CompanySalesRevenue' is implemented Or the class name is wrong");
            }
        }

        [Test]
        public void GetCompanySalesDetails_ValidInputString_ReturnsCompanyNameAndServices()
        {
            List<string> companySalesInfo = new List<string>
            {
                "HCL:23.6:Software",
                "Adobe:34.9:Software",
                "HCL:23.0:Infrastructure"
            };

            Dictionary<string, List<Service>> sourceDict = new Dictionary<string, List<Service>>();


            for (int i = 0; i < companySalesInfo.Count; i++)
            {
                if (!sourceDict.ContainsKey(companySalesInfo[i].Split(':')[0]))
                {
                    sourceDict.Add(companySalesInfo[i].Split(':')[0], new List<Service> { new Service { Name = companySalesInfo[i].Split(':')[2], AnnualSalesAmount = float.Parse(companySalesInfo[i].Split(':')[1]) } });
                }
                else
                {
                    sourceDict[companySalesInfo[i].Split(':')[0]].Add(new Service { Name = companySalesInfo[i].Split(':')[2], AnnualSalesAmount = float.Parse(companySalesInfo[i].Split(':')[1]) });
                }
            }


            StringBuilder sourceDictSB = new StringBuilder();

            foreach (var itemOuter in sourceDict)
            {
                foreach (var itemInner in itemOuter.Value)
                {
                    sourceDictSB.Append(string.Join(itemOuter.Key, itemInner.Name, itemInner.AnnualSalesAmount));
                }
            }


            var resultDict = new CompanySalesDetailsApp.CompanySalesRevenue().GetCompanySalesDetails(companySalesInfo);

            StringBuilder targetDictSB = new StringBuilder();

            foreach (var itemOuter in resultDict)
            {
                foreach (var itemInner in itemOuter.Value)
                {
                    targetDictSB.Append(string.Join(itemOuter.Key, itemInner.Name, itemInner.AnnualSalesAmount));
                }
            }

            Assert.That(sourceDictSB.Equals(targetDictSB));

        }

        [Test]
        public void DisplayCompaniesRevenueInOrder_ValidInputDictionory_ReturnsCompanyNameAndAnnualSalesRevenue()
        {
            Dictionary<string, List<Service>> sourceDict = new Dictionary<string, List<Service>>();

            sourceDict.Add("Microsoft", new List<Service>
            {
                new Service { Name="Software",AnnualSalesAmount=30.9F},
                new Service { Name="Desktop",AnnualSalesAmount=10.2F},
                new Service { Name="Infrastructure",AnnualSalesAmount=6.8F}
            });
            sourceDict.Add("Adobe", new List<Service>
            {
                new Service { Name="Digital Media",AnnualSalesAmount=10.9F},
                new Service { Name="Software",AnnualSalesAmount=6.7F}
            });
            sourceDict.Add("Oracle", new List<Service>
            {
                new Service { Name="Platform",AnnualSalesAmount=20.3F},
                new Service { Name="Software",AnnualSalesAmount=8.8F}
            });

            SortedDictionary<string, float> companiesInOrderDict = new SortedDictionary<string, float>();

            foreach (var item in sourceDict)
            {
                companiesInOrderDict.Add(item.Key, item.Value.Sum(x => x.AnnualSalesAmount));
            }

            IEnumerable<KeyValuePair<string, float>> expectedResult = companiesInOrderDict;

            IEnumerable<KeyValuePair<string, float>> actualResult = new CompanySalesRevenue().DisplayCompaniesRevenueInOrder(sourceDict);

            CollectionAssert.AreEquivalent(expectedResult, actualResult);

        }
    }
}
