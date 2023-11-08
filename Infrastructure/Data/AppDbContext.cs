using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<RecievedData> RecievedData { get; set; }

        public AppDbContext():base()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.EnableSensitiveDataLogging();

            //options.UseSqlServer("Data Source=.;Initial Catalog=Bahram_Devlopment;Integrated Security=true;MultipleActiveResultSets=True;TrustServerCertificate=True;",a => a.CommandTimeout(180));
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Domain.Entities.RecievedData>()
        //        .HasKey(b=>b.Id)
        //        ;
        //}

    }
}
