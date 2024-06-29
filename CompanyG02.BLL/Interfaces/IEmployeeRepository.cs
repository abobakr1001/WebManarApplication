using CompanyG02.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyG02.BLL.Interfaces
{
    public interface IEmployeeRepository:IGenericReposotory<Employee>
    {
        public IQueryable<Employee> GetEmployeesByAddres(string address);
        public IQueryable<Employee> GetEmployeesByName(string Name);
    }
}
