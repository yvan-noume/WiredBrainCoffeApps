using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffe.CustomersApp.Models;

namespace WiredBrainCoffe.CustomersApp.Data
{
    public interface IProductDataProvider
    {
        Task<IEnumerable<Product>?> GetAllAsync();
    }

    class ProductDataProvider: IProductDataProvider
    {
        public async Task<IEnumerable<Product>?> GetAllAsync()
        {
            await Task.Delay(100);

            return new List<Product>
            {
                new Product { Name="Espresso", Description="The espresso, also known as a short black, is approximately 1 oz"},
                new Product { Name="Double Espresso", Description="A double espresso may also be listed as doppio"},
                new Product { Name="Red Eye", Description="The red eye's purpose is to add a boost of caffeine"},
                new Product { Name="Black Eye", Description="The black eye is just the doubled version of the red eye"},
                new Product { Name="Americano", Description="Americanos are popular breakfast drinks"},
                new Product { Name="Macchiato", Description="This is in reference to the mark that steamed milk leaves on the surface of the espresso"}
            };
        }
    }
}
