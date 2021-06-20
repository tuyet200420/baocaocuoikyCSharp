using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ModelEF.EF
{
    public partial class HoThiTuyetContext : DbContext
    {
        public HoThiTuyetContext()
            : base("name=HoThiTuyetContext")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.IDCategory);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitCost)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.UserName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.PassWord)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Status)
                .IsUnicode(false);
        }
    }
}
