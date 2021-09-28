using mvc_project_practice.Models;
using MySql.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace mvc_project_practice.Data
{
     
    public class ApplicationDbContext : DbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Categorycs> Categorycs { get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }

    }

}
