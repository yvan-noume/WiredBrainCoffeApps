using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffe.CustomersApp.Models;

namespace WiredBrainCoffe.CustomersApp.Data
{
    public interface ICustomerDataProvider
    {
        Task<IEnumerable<Customer>?> GetAllAsync();
    }
    public class CustomerDataProvider : ICustomerDataProvider
    {
        public async Task<IEnumerable<Customer>?> GetAllAsync()
        {
            await Task.Delay(100);

            return new List<Customer>
            {
                new Customer { Id = 1, FirstName = "Julia", LastName = "Doern", IsDeveloper = true },
                new Customer { Id = 2, FirstName = "Robert", LastName = "Maarlan", IsDeveloper = true },
                new Customer { Id = 3, FirstName = "Thomas", LastName = "Martijn", IsDeveloper = false },
                new Customer { Id = 4, FirstName = "Peter", LastName = "Duis", IsDeveloper = false },
                new Customer { Id = 5, FirstName = "Ben", LastName = "Ronaldo", IsDeveloper = true },
                new Customer { Id = 5, FirstName = "Sara", LastName = "Metroi", IsDeveloper = true }
            };
        }
    }
}
