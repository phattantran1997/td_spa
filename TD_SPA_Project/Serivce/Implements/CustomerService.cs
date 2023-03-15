using System;
using TD_SPA_Project.DBContext;
using TD_SPA_Project.Entity;
using TD_SPA_Project.Serivce.Interfaces;

namespace TD_SPA_Project.Serivce.Implements
{
	public class CustomerService : ICustomerService
	{
        public readonly CommonContext commonContext;
		public CustomerService(CommonContext commonContext)
		{
            this.commonContext = commonContext;
		}

        public Task<List<Customer>> GetAllCustomers()
        {
            var x = commonContext.Customers.ToList();
            throw new NotImplementedException();
        }
    }
}

