using mongoDemo.Models;
using MongoDB.Driver;

namespace mongoDemo.Services
{
    public class CustomerService : ICustomerServices
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerService(ICustomerStoreDatabaseSetting settings,IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _customers = database.GetCollection<Customer>(settings.CustomerCollectionName);
        }
        public Customer Create(Customer customer)
        {
            _customers.InsertOne(customer);
            return customer;
        }

        public List<Customer> Get()
        {
            return _customers.Find(customer => true).ToList();
        }

        public Customer Get(string id)
        {
            return _customers.Find(customer => customer.CustomerId == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
             _customers.DeleteOne(customer => customer.CustomerId == id);
        }

        public void Update(string id, Customer customer)
        {
            _customers.ReplaceOne(customer => customer.CustomerId == id, customer);
        }
    }
}
