using Microsoft.EntityFrameworkCore;
using TD_SPA_Project.DBContext;
using TD_SPA_Project.Entity;
using TD_SPA_Project.Serivce.Interfaces;

namespace TD_SPA_Project.Serivce.Implements
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly CommonContext commonContext;
        public EmployeeRepository(CommonContext commonContext)
        {
            this.commonContext = commonContext;
        }

        public async Task<Employee?> Add(Employee newEmployee)
        {
            commonContext.Employees.Add(newEmployee);
            int result_line = await commonContext.SaveChangesAsync();
            return result_line > 0 ? newEmployee : null;
        }
        public async Task<bool> DeleteById(int id)
        {
            var post = await commonContext.Employees.FindAsync(id);
            if (post == null)
            {
                return false;
            }
            commonContext.Employees.Remove(post);
            await commonContext.SaveChangesAsync();
            return true;
        }
        public void Dispose()
        {
        }
        public async Task<IEnumerable<Employee?>> GetAll()
        {
            return await commonContext.Employees.ToListAsync();
        }
        public async Task<Employee?> GetById(int id)
        {
            var employee = await commonContext.Employees.FindAsync(id);
            return employee;
        }

        public async Task<Employee?> Update(int id, Employee employee)
        {
            if (id != employee.idemployee) { return null; }
            commonContext.Entry(employee).State = EntityState.Modified;
            try
            {
                await commonContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostExists(id)) { return null; }
                else { throw; }
            }
            return employee;
        }
        private bool BlogPostExists(int id) { return commonContext.Employees.Any(e => e.idemployee == id); }
    }
}
