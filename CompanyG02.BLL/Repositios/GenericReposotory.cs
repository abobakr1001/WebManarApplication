using CompanyG02.BLL.Interfaces;
using CompanyG02.DAL.Contexts;
using CompanyG02.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyG02.BLL.Repositios
{
    public class GenericReposotory<T>:IGenericReposotory<T> where T : class
    {
        private readonly companyDbcontext dbcontext;

        public GenericReposotory(companyDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task Add(T item)
      
          =>  await  dbcontext.Set<T>().AddAsync(item);
     
        public void Delete(T item)
       
          =>  dbcontext.Set<T>().Remove(item);
           
       

        public async Task<T> Get(int id)
        {
            return await dbcontext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            if (typeof(T) == typeof(Employee))
            {
                return (IEnumerable<T>) await dbcontext.employees.Include(e => e.Department).ToListAsync();
            }
            return await dbcontext.Set<T>().ToListAsync();
        }

        public void Update(T item)
        {
            dbcontext.Set<T>().Update(item);
        }
    }
}
