﻿using System.Collections.Generic;
using WeddingManager.Core.Data;

namespace WeddingManager.Core.Repositories
{
    public interface ICustomerRepository
    {
        int CreateCustomer(int companyId, Customer customer);

        IEnumerable<Customer> RetrieveCustomers(int companyId);

        void UpdateCustomer(Customer customer);

        void DeleteCustomer(int customerId);
    }
}