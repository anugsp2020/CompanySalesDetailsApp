﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CompanySalesDetailsApp
{ 
    class Program
    {
        static void Main()
        { 
            int numberOfRecords = int.Parse(Console.ReadLine());

            List<string> inputs = new List<string>();

            for (int i = 0; i < numberOfRecords; i++)
            {
                inputs.Add(Console.ReadLine());
            }

            CompanySalesRevenue companySalesRevenue = new CompanySalesRevenue();

            var companyDetailsDict = companySalesRevenue.GetCompanySalesDetails(inputs);

            var companiesRevenueDict = companySalesRevenue.DisplayCompaniesRevenueInOrder(companyDetailsDict);

            foreach (var item in companiesRevenueDict)
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }
        }
    }
}
