using CompanyG02.BLL.Interfaces;
using CompanyG02.DAL.Contexts;
using CompanyG02.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyG02.BLL.Repositios
{
    public class EmployeeRepository : GenericReposotory<Employee>,IEmployeeRepository
    {
        private readonly companyDbcontext dbcontext;

        //generic

        public EmployeeRepository(companyDbcontext dbcontext) : base(dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public IQueryable<Employee> GetEmployeesByAddres(string address)
        {
            return dbcontext.employees.Where(e => e.Address == address);

        }

        public IQueryable<Employee> GetEmployeesByName(string Name)
        {
            return dbcontext.employees.Where(e => e.Name.ToLower().Contains(Name.ToLower()));
        }


        //private readonly companyDbcontext dbcontext;

        //public EmployeeRepository(companyDbcontext dbcontext)
        //{
        //    this.dbcontext = dbcontext;
        //}
        //public int Add(Employee employee)
        //{
        //    dbcontext.employees.Add(employee);
        //    return dbcontext.SaveChanges();
        //}

        //public int Delete(Employee employee)
        //{
        //    dbcontext.employees.Remove(employee);
        //    return dbcontext.SaveChanges();
        //}

        //public Employee Get(int id)
        //{
        //    return dbcontext.Find<Employee>(id);
        //}

        //public IEnumerable<Employee> GetAll()
        //{
        //    return dbcontext.employees.ToList();
        //}

        //public int Update(Employee employee)
        //{
        //    dbcontext.employees.Update(employee);
        //    return dbcontext.SaveChanges();
        //}
    }
}
