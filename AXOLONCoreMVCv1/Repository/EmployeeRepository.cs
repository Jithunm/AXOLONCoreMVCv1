using AXOLONCoreMVCv1.Data;
using AXOLONCoreMVCv1.Managers;
using AXOLONCoreMVCv1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace AXOLONCoreMVCv1.Repository
{
   
 
    public interface IEmployeeRepository
    {
        List<TblEmployee> GetEmployees();
        Task<string> InsertEmployee(TblEmployee model);
        Task<string> DeleteEmployee(int empid);
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        AXOLON_DBContext context = new AXOLON_DBContext();
        MessageBox messageboxObj = new MessageBox();
        public List<TblEmployee> GetEmployees()
        {
            var employeeData =  context.TblEmployees.ToList();
            return employeeData;
        }
        public async Task<string> InsertEmployee(TblEmployee model)
        {
            context.TblEmployees.Add(model);
            await (context.SaveChangesAsync());
            return messageboxObj.successMessage1;
        }
        public async Task<string> DeleteEmployee(int empid)
        {
            try
            {
                var dataset = context.TblEmployees.Where(x => x.EmployeeId == empid).FirstOrDefault();
                context.TblEmployees.Remove(dataset);
                await (context.SaveChangesAsync());
            }
            catch (Exception)
            {
                return messageboxObj.deleteError;
            }

            return messageboxObj.deleteSuccess;
        }

       
    }
}
