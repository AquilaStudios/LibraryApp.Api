using LibraryApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DomainLogic.Interfaces
{
    public interface ICustomer
    {

        public List<Customer> GetAll();
        public List<Customer> Get(Customer customer);


        public Customer? GetById(Customer customer);

        public void Add(Customer customer);


        public void AddByRange(IEnumerable<Customer> customer);


        public void Update(Customer customer);

        public void Remove(Customer customer);


        public void RemoveByRange(IEnumerable<Customer> customers);
        

    }
}
