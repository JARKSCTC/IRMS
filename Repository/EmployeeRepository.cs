using IRMS.IRepository;
using IRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IRMS.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly IRMSContext irmsDBContext;

        public EmployeeRepository(IRMSContext irmsDBContext)
        {
            this.irmsDBContext = irmsDBContext;
        }

        public async Task<IEnumerable<Employee>> GetAllRecords()
        {
            return await irmsDBContext.Employee.ToListAsync();
        }

        public async Task<Employee> GetRecord(int iD)
        {
            return await irmsDBContext.Employee
                .FirstOrDefaultAsync(e => e.ID == iD);
        }

        public async Task<Employee> AddRecord(Employee employee)
        {
            var result = await irmsDBContext.Employee.AddAsync(employee);
            await irmsDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> UpdateRecord(Employee employee)
        {
            var result = await irmsDBContext.Employee
                .FirstOrDefaultAsync(e => e.ID == employee.ID);

            if (result != null)
            {
                //result.FirstName = employee.FirstName;
               // result.LastName = employee.LastName;
               // result.Email = employee.Email;
               // result.DateOfBrith = employee.DateOfBrith;
              //  result.PhotoPath = employee.PhotoPath;

                await irmsDBContext.SaveChangesAsync();

                return result;
            }

            return result;
        }

        public async Task<Employee> DeleteRecord(int iD)
        {
            var result = await irmsDBContext.Employee
                .FirstOrDefaultAsync(e => e.ID == iD);
            if (result != null)
            {
                irmsDBContext.Employee.Remove(result);
                await irmsDBContext.SaveChangesAsync();
            }
            return result;
        }
    }
}
