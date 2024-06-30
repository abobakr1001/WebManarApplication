using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyG02.BLL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; set; }
        IdepartmentRepository DepartmentRepository { get; set; }
       Task<int>  Complelete();
    }
}
