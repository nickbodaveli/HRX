using HRSOFT.Application.Common.Interfaces;
using HRSOFT.Application.Feature.Commands.Employee.Create;
using HRSOFT.Domain.Common;
using HRSOFT.EFCore.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSOFT.Infrastructure.Persistance.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HRSOFTDBContext _context;

        public EmployeeRepository(HRSOFTDBContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<bool> CreateEmployee(Employee request)
        {
             _context.Add(request);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> GetEmployeeByEmailOrPrivateNumber(string? email, string? privateNumber)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => 
            (
                x.Email == email || 
                x.PrivateNumber == privateNumber
            ));

            return employee != null;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            _context.ChangeTracker.Clear();
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
