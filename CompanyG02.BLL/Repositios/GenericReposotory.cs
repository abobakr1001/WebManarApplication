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
        public void Add(T item)
        {
            dbcontext.Set<T>().Add(item);
         
        }

        public void Delete(T item)
        {
            dbcontext.Set<T>().Remove(item);
           
        }

        public T Get(int id)
        {
            return dbcontext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            if (typeof(T) == typeof(Employee))
            {
                return (IEnumerable<T>) dbcontext.employees.Include(e => e.Department).ToList();
            }
            return dbcontext.Set<T>().ToList();
        }

        public void Update(T item)
        {
            dbcontext.Set<T>().Update(item);
        }
    }
}
