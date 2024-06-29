using CompanyG02.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyG02.DAL.Contexts
{
    public class companyDbcontext:DbContext
    {

        public companyDbcontext(DbContextOptions<companyDbcontext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;database=CompanyManar;Trusted_Connection=true");
        //}

        public DbSet<Deaprtment> deaprtments { get; set; }
        public DbSet<Employee> employees { get; set; }
    }
}
