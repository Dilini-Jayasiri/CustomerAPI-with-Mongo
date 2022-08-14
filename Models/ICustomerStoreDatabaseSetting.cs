using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace mongoDemo.Models
{
    public interface ICustomerStoreDatabaseSetting
    {
        string CustomerCollectionName { get; set; }
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}
