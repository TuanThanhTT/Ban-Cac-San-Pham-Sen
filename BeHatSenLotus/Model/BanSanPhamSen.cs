

using BeHatSenLotus.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeHatSenLotus.Model
{
    public class BanSanPhamSen : DbContext
    {
        public BanSanPhamSen() : base("name=connectionstring")
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Manfactory> Manfactory { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Permissition> Permissition { get; set; }
        public DbSet<Account> Account { get; set; } 
        public DbSet<AccountPermisstion> AccountPermisstion { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasRequired(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.categoryId);

            modelBuilder.Entity<Product>()
                .HasRequired(p => p.Manfactory)
                .WithMany(m => m.Products)
                .HasForeignKey(p => p.manfactoryId);

            modelBuilder.Entity<AccountPermisstion>()
                .HasKey(ap => new { ap.accountId, ap.permissitionId });

            modelBuilder.Entity<AccountPermisstion>()
                .HasRequired(ap => ap.Account)
                .WithMany(a => a.AccountPermisstions)
                .HasForeignKey(ap => ap.accountId);

            modelBuilder.Entity<AccountPermisstion>()
                .HasRequired(ap => ap.Permissition)
                .WithMany(p => p.accountPermissions)
                .HasForeignKey(ap => ap.permissitionId);

            modelBuilder.Entity<Account>().HasOptional(a => a.user).WithOptionalPrincipal(u => u.account).Map(m => m.MapKey("UserAccountId"));

            modelBuilder.Entity<Account>().HasOptional(a => a.employee).WithOptionalPrincipal(e => e.account).Map(m => m.MapKey("EmployAccountId"));

            modelBuilder.Entity<Order>()
                .HasOptional(o => o.Employees)
                .WithMany(e => e.orders)
                .HasForeignKey(o => o.EmployeeId);

            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Users)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<OrderItem>()
                .HasRequired(oi => oi.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasRequired(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);
        }




    }
}
