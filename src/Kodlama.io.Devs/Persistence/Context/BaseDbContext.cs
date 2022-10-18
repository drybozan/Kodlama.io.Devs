using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Context
{
    
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        // entityler ile DBnin ilişildiği kısım
        public DbSet<ProgramingLanguage> ProgramingLanguage { get; set; }
       

      
        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        /// <summary>
        /// datbasede oluşturulacak tablolar burda model edilir kodla sonra database oluşturulur migration ile
        /// </summary>
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramingLanguage>(a =>
            {
                a.ToTable("ProgramingLanguageTbl").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
              
            });
                     

            /// Seed data tablo oluşturulrken içinde hali hazırda bulunduracak datalar demektir.
           ProgramingLanguage [] programingLanguageEntitySeeds = { new(1, "C#"), new(2, "Java") };
            modelBuilder.Entity<ProgramingLanguage>().HasData(programingLanguageEntitySeeds);



        }
    }
}
