using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using TD_SPA_Project.DBContext;
using TD_SPA_Project.Entity;
using TD_SPA_Project.Serivce.Interfaces;

namespace TD_SPA_Project.Serivce.Implements
{
	public class CustomerRepository : ICustomerRepository
	{
        public readonly CommonContext commonContext;
		public CustomerRepository(CommonContext commonContext)
		{
            this.commonContext = commonContext;
		}

        public async Task<Customer?> Add(Customer newcustomer)
        {
            commonContext.Customers.Add(newcustomer);
            int result_line = await commonContext.SaveChangesAsync();
            return result_line > 0 ? newcustomer : null;
        }
        public async Task<bool> DeleteById(int id)
        {
            var post = await commonContext.Customers.FindAsync(id);
            if (post == null)
            {
                return false;
            }
            commonContext.Customers.Remove(post);
            await commonContext.SaveChangesAsync();
            return true;
        }
        public void Dispose()
        {
        }
        public async Task<IEnumerable<Customer?>> GetAll()
        {
            return await commonContext.Customers.ToListAsync();
        }
        public async Task<Customer?> GetById(int id)
        {
            var customer = await commonContext.Customers.FindAsync(id);
            return customer;
        }

        public async Task<Customer?> Update(int id, Customer customer)
        {
            if (id != customer.iduser) { return null; }
            commonContext.Entry(customer).State = EntityState.Modified;
            try
            {
                await commonContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostExists(id)) { return null; }
                else { throw; }
            }
            return customer;
        }
        private bool BlogPostExists(int id) { return commonContext.Customers.Any(e => e.iduser == id); }

    }

}

