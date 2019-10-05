using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using CustomerInfo.Repository;
using CustomerInfo.Model;

namespace CustomerInfo.Manager
{
    class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();

        public DataTable LoadCustomerCombo()
        {
            return _customerRepository.LoadCustomerCombo();
        }
        public bool AddCustomer(CustomerDistrict customerDistrict)
        {
            return _customerRepository.AddCustomer(customerDistrict);
        }
        public bool IsCodeExists(CustomerDistrict customerDistrict)
        {
            return _customerRepository.IsCodeExists(customerDistrict);
        }
        public bool IsContactExists(CustomerDistrict customerDistrict)
        {
            return _customerRepository.IsContactExists(customerDistrict);
        }
        public DataTable DisplayData()
        {
            return _customerRepository.DisplayData();
        }
        public bool UpdateCustomer(CustomerDistrict customerDistrict)
        {
            return _customerRepository.Update(customerDistrict);
        }
        public DataTable Search(CustomerDistrict customerDistrict)
        {
            return _customerRepository.Search(customerDistrict);
        }
    }
}
