using Interfaces.Strategy;
using Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Filter
{
    public class FilterByCategory : IFilter<Product>
    {
        public List<Product> Filter(List<Product> products, Dictionary<string, object> filters)
        {
            if (filters == null || filters.Count == 0)
            {
                return products;
            }
            
            string filterKey = filters.Keys.FirstOrDefault()!;

            switch (filterKey)
            {
                case "category":
                    string filterValue = filters[filterKey].ToString()!;
                    
                    if (string.IsNullOrEmpty(filterValue) || filterValue == "All")
                    {
                        return products;
                    }

                    return products.Where(p => p.Category.ToString().Equals(filterValue, StringComparison.OrdinalIgnoreCase)).ToList();
                    
            }


            // Test
            return products;
        }

        //public List<Product> Filter(List<Product> products, string param)
        //{
        //    if (string.IsNullOrEmpty(param) || param == "All")
        //    {
        //        return products;
        //    }

        //    return products.Where(p => p.Category.ToString().Equals(param, StringComparison.OrdinalIgnoreCase)).ToList();
        //}
    }
}
