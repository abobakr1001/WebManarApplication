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
    public class departmentRepository : GenericReposotory<Deaprtment>,IdepartmentRepository
    {

        // generic
        public departmentRepository(companyDbcontext dbcontext) : base(dbcontext)
        {

        }

        //private readonly companyDbcontext dbcontext;

        //public departmentRepository(companyDbcontext dbcontext)
        //{
        //    this.dbcontext = dbcontext;
        //}
        //public int Add(Deaprtment deaprtment)
        //{
        //    dbcontext.deaprtments.Add(deaprtment);
        //    return dbcontext.SaveChanges();
        //}

        //public int Delete(Deaprtment deaprtment)
        //{
        //    dbcontext.deaprtments.Remove(deaprtment);
        //    return dbcontext.SaveChanges();
        //}

        //public Deaprtment Get(int id)
        //{
        //    return dbcontext.Find<Deaprtment>(id);
        //}

        //public IEnumerable<Deaprtment> GetAll()
        //{
        //    return dbcontext.deaprtments.ToList();
        //}

        //public int Update(Deaprtment deaprtment)
        //{
        //    dbcontext.deaprtments.Update(deaprtment);
        //    return dbcontext.SaveChanges();
        //}
    }
}
