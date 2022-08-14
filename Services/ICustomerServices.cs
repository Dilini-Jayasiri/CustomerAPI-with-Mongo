using mongoDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace mongoDemo.Services
{
    public interface ICustomerServices
    {
        List<Customer> Get();
        Customer Get(string customerId);
        Customer Create(Customer customer);
        void Update(string customerId, Customer customer);
        void Remove(string customerId);
    }
}
