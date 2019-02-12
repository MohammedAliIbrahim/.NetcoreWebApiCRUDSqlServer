using LeadCoreAreas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadCoreAreas.Areas.Product.Models
{
    public class DatabaseContext : DbContext
    {



        /*   public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
       { }*/

        /*   private readonly IConfiguration configuration;

           public DatabaseContext( IConfiguration config)
           {
               this.configuration = config;
           }*/

        //  String constring = configuration.GetConnectionString("DefaultConnection");

        /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
              optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
          }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dotnetest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
          //  optionsBuilder.UseSqlServer(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dotnetest;Integrated Security=True;");
        }
        //entities
        public DbSet<store> Stores { get; set; }
        public DbSet<product> Products { get; set; }




    }
}
