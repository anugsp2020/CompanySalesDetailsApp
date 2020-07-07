using System.Collections.Generic;
using System.Linq;

namespace CompanySalesDetailsApp
{
    public class CompanySalesRevenue
    {
        public Dictionary<string, List<Service>> GetCompanySalesDetails(List<string> _companySalesData)
        {
            Dictionary<string, List<Service>> companyDict = new Dictionary<string, List<Service>>();

            for (int i = 0; i < _companySalesData.Count; i++)
            {
                if (!companyDict.ContainsKey(_companySalesData[i].Split(':')[0]))
                {
                    companyDict.Add(_companySalesData[i].Split(':')[0], new List<Service> { new Service { Name = _companySalesData[i].Split(':')[2], AnnualSalesAmount = float.Parse(_companySalesData[i].Split(':')[1]) } });
                }
                else
                {
                    companyDict[_companySalesData[i].Split(':')[0]].Add(new Service { Name = _companySalesData[i].Split(':')[2], AnnualSalesAmount = float.Parse(_companySalesData[i].Split(':')[1]) });
                }
            }

            return companyDict;
        }

        public IEnumerable<KeyValuePair<string, float>> DisplayCompaniesRevenueInOrder(Dictionary<string, List<Service>> dictCompaniesSalesDetails)
        {

            SortedDictionary<string, float> companiesInOrderDict = new SortedDictionary<string, float>();
            
            foreach (var item in dictCompaniesSalesDetails)
            {
                companiesInOrderDict.Add(item.Key, item.Value.Sum(x => x.AnnualSalesAmount));
            }

            IEnumerable<KeyValuePair<string, float>> temp = companiesInOrderDict;


            return temp;
        }
    }
}
