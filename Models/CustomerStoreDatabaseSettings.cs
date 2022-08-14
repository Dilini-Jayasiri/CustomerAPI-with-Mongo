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
    public class CustomerStoreDatabaseSettings : ICustomerStoreDatabaseSetting
    {
        public string CustomerCollectionName { get; set; } = string.Empty;
        //string ICustomerStoreDatabaseSetting.CustomerCollectionName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ConnectionString { get; set; } = string.Empty ;
        //string ICustomerStoreDatabaseSetting.ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DatabaseName { get; set; } = string.Empty;
        //string ICustomerStoreDatabaseSetting.DatabaseName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
