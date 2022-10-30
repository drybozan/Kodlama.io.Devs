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
using Core.Security.Entities;

namespace Persistence.Context
{
    
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        // entityler ile DBnin ilişildiği kısım
        public DbSet<ProgramingLanguage> ProgramingLanguage { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Github> Githubs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }



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
            #region ProgramingLanguage Model Creation
            modelBuilder.Entity<ProgramingLanguage>(a =>
            {
                a.ToTable("ProgramingLanguageTbl").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.Technologies); //1-n ilişki
              
            });

            // Seed data tablo oluşturulrken içinde hali hazırda bulunduracak datalar demektir.
            ProgramingLanguage[] programingLanguageEntitySeeds = { new(1, "C#"), new(2, "Java") };
            modelBuilder.Entity<ProgramingLanguage>().HasData(programingLanguageEntitySeeds);
            #endregion

            #region Technology Model Creation
            modelBuilder.Entity<Technology>(a =>
            {
                a.ToTable("TechnologyTbl").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.ProgramingLanguageId).HasColumnName("ProgramingLanguageId");
                a.HasOne(p=>p.ProgramingLanguage); // n-1 ilişki

            });


            Technology[] technologyEntitySeeds = { new(1, 1, "WPF"), new(2, 1, ".Net"), new(3, 2, "Spring"), new(4, 2, "JSP") };
            modelBuilder.Entity<Technology>().HasData(technologyEntitySeeds);
            #endregion


            #region Github Model Creation
            modelBuilder.Entity<Github>(u =>
            {
                u.ToTable("GithubTbl").HasKey(u => u.Id);
                u.Property(u => u.Id).HasColumnName("Id");
                u.Property(u => u.UserId).HasColumnName("UserId");
                u.Property(u => u.GithubUrl).HasColumnName("GithubUrl");
                u.HasOne(u => u.User);
            });
            #endregion


            #region User Model Creation
            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("UserTbl").HasKey(u => u.Id);
                u.Property(u => u.Id).HasColumnName("Id");
                u.Property(u => u.FirstName).HasColumnName("FirstName");
                u.Property(u => u.LastName).HasColumnName("LastName");
                u.Property(u => u.Email).HasColumnName("Email");
                u.Property(u => u.Status).HasColumnName("Status");
                u.Property(u => u.PasswordHash).HasColumnName("PasswordHash");
                u.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt");
                u.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType");
                u.HasMany(u => u.UserOperationClaims);
                u.HasMany(u => u.RefreshTokens);
               
            });
            #endregion

            #region OperationClaim Model Creation
            modelBuilder.Entity<OperationClaim>(u =>
            {
                u.ToTable("OperationClaimTbl").HasKey(u => u.Id);
                u.Property(u => u.Id).HasColumnName("Id");
                u.Property(u => u.Name).HasColumnName("Name");
            });

            OperationClaim[] operationClaimEntitySeeds = { new(1, "Admin"), new(2, "User"), new(3, "Visitor") };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaimEntitySeeds);
            #endregion

            #region UserOperationClaim Model Creation
            modelBuilder.Entity<UserOperationClaim>(u =>
            {
                u.ToTable("UserOperationClaimTbl").HasKey(u => u.Id);
                u.Property(u => u.Id).HasColumnName("Id");
                u.Property(u => u.UserId).HasColumnName("UserId");
                u.Property(u => u.OperationClaimId).HasColumnName("OperationClaimId");
                u.HasOne(u => u.User);
                u.HasOne(u => u.OperationClaim);
            });
            #endregion

            #region RefreshToken Model Creation
            modelBuilder.Entity<RefreshToken>(u =>
            {
                u.ToTable("RefreshTokenTbl").HasKey(u => u.Id);
                u.Property(u => u.Id).HasColumnName("Id");
                u.Property(u => u.UserId).HasColumnName("UserId");
                u.Property(u => u.Token).HasColumnName("Token");
                u.Property(u => u.Expires).HasColumnName("Expires");
                u.Property(u => u.Created).HasColumnName("Created");
                u.Property(u => u.CreatedByIp).HasColumnName("CreatedByIp");
                u.Property(u => u.Revoked).HasColumnName("Revoked");
                u.Property(u => u.RevokedByIp).HasColumnName("RevokedByIp");
                u.Property(u => u.ReplacedByToken).HasColumnName("ReplacedByToken");
                u.Property(u => u.ReasonRevoked).HasColumnName("ReasonRevoked");
                u.HasOne(u => u.User);
            });
            #endregion




          



        }
    }
}
