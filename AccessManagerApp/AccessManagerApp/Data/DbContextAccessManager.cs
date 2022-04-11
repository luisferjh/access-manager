using AccessManagerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessManagerApp.Data
{
    public class DbContextAccessManager:DbContext
    { 
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<AccountDetails> AccountDetails { get; set; }


        public DbContextAccessManager(DbContextOptions<DbContextAccessManager> options)
        : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.IdAccount);

                entity.HasOne(e => e.AccountType)
                    .WithMany(p => p.Account)
                    .HasForeignKey(e => e.IdAccountType)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(s => s.GuidAccount)
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();

                entity.Property(s => s.Name)                    
                    .HasColumnType("nchar(50)")
                    .IsRequired();

                entity.Property(s => s.Description)                  
                   .HasColumnType("nchar(100)");

                entity.Property(s => s.State)                
                  .HasColumnType("bit");

                entity.Property(s => s.CreationDate)               
                  .HasColumnType("datetime");
            });

            modelBuilder.Entity<AccountDetails>(entity => {
                entity.HasKey(e => e.IdAccountDetail);

                entity.HasOne(f => f.Account)
                    .WithMany(p => p.AccountDetails)
                    .HasForeignKey(f => f.IdAccount);
            });
            
            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.HasKey(e => e.IdAccountType);

                entity.Property(p => p.TypeName)
                    .HasColumnType("nchar(20)")
                    .IsRequired();

                entity.Property(p => p.Code)
                    .HasColumnType("nchar(4)")
                    .IsRequired();
            });

            modelBuilder.Entity<AccNormal>(entity =>
            {
                entity.Property(p => p.UserName)
                    .HasColumnType("nchar(50)")
                    .IsRequired();

                entity.Property(p => p.Email)
                    .HasColumnType("nchar(50)")
                    .IsRequired();

                entity.Property(p => p.Password)
                    .HasColumnType("nchar(50)")
                    .IsRequired();
            });

            modelBuilder.Entity<AccEmailAssociated>(entity =>
            {
                entity.Property(p => p.Email)
                    .HasColumnType("nchar(50)")
                    .IsRequired();
            });

            modelBuilder.Entity<AccWebSite>(entity =>
            {
                entity.Property(p => p.WebSiteName)
                    .HasColumnType("nchar(50)")
                    .IsRequired();
            });

            modelBuilder.Entity<AccCard>(entity =>
            {
                entity.Property(p => p.CardType)
                    .HasColumnType("nchar(10)")
                    .IsRequired();

                entity.Property(p => p.Franchise)
                    .HasColumnType("nchar(20)")
                    .IsRequired();

                entity.Property(p => p.Bank)
                    .HasColumnType("nchar(20)")
                    .IsRequired();

                entity.Property(p => p.CCV)
                    .HasColumnType("nchar(50)");

                entity.Property(p => p.ExpirationDate)
                    .HasColumnType("nchar(50)");                    
            });
        }
    }
}
