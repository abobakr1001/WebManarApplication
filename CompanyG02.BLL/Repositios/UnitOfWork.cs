using CompanyG02.BLL.Interfaces;
using CompanyG02.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyG02.BLL.Repositios
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; set ; }
        public IdepartmentRepository DepartmentRepository { get ; set ; }
        public companyDbcontext Dbcontext { get; }

        public UnitOfWork(companyDbcontext dbcontext)
        {
            EmployeeRepository = new EmployeeRepository(dbcontext);
            DepartmentRepository = new departmentRepository(dbcontext);
            Dbcontext = dbcontext;
        }

        public int Complelete()
        {
            return Dbcontext.SaveChanges();
        }

        public void Dispose()
           => Dbcontext.Dispose();
        
    }
}
