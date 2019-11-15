using SynelAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SynelAppDemo.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefualtConnection")
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}