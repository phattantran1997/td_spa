using System;
using TD_SPA_Project.Entity;

namespace TD_SPA_Project.Serivce.Interfaces
{
	public interface ICustomerService
	{
		public Task<List<Customer>> GetAllCustomers();
	}
}

