using Microsoft.EntityFrameworkCore;
using Tapster.DomainEntities.Entities;
using Utils.EntityFrameworkCore.Extensions;

namespace Tapster.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            AddConfiguration(modelBuilder);
        }
        private void AddConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration<Category>();
            modelBuilder.AddConfiguration<Client>();
            modelBuilder.AddConfiguration<ClientSession>();
            modelBuilder.AddConfiguration<Manager>();
            modelBuilder.AddConfiguration<Order>();
            modelBuilder.AddConfiguration<OrderProduct>();
            modelBuilder.AddConfiguration<Product>();
            modelBuilder.AddConfiguration<Session>();
            modelBuilder.AddConfiguration<Table>();
            modelBuilder.AddConfiguration<Venue>();
            modelBuilder.AddConfiguration<Waiter>();
            modelBuilder.AddConfiguration<WaiterTable>();
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }
        public virtual DbSet<Waiter> Waiters { get; set; }
        public virtual DbSet<WaiterTable> WaiterTables { get; set; }

    }
}
