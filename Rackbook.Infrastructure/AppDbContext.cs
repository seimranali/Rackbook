using Microsoft.EntityFrameworkCore;
using Rackbook.Domain.Entities;

namespace Rackbook.Infrastructure
{
    public class AppDbContext : DbContext, IDisposable
    {

        bool IsDisposed;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
        }

        public DbSet<ItemGroup> ItemGroup { get; set; }
        public DbSet<ItemUnit> ItemUnit { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<vw_Items> vw_Items { get; set; }
        public DbSet<CompanyType> CompanyType { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<vw_Users> vw_Users { get; set; }
        public DbSet<JournalEntry> JournalEntry { get; set; }
        public DbSet<JournalEntryDetail> JournalEntryDetail { get; set; }
        public DbSet<JournalEntryType> JournalEntryType { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<AccountDetail> AccountDetail { get; set; }
        public DbSet<vw_AccountDetail> vw_AccountDetail { get; set; }
        public DbSet<vw_Accounts> vw_Accounts { get; set; }
        public DbSet<NavigationItem> NavigationItem { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomersAddress> CustomersAddress { get; set; }
        public DbSet<SaleOrderMaster> SaleOrderMaster { get; set; }
        public DbSet<SaleOrderDetail> SaleOrderDetail { get; set; }


        protected void Disposed(bool disposing)
        {

            if (disposing)
            {
                base.Dispose();
            }
            IsDisposed = true;
        }

        public void Dispose()
        {
            if (!IsDisposed)
            {
                Disposed(true);
            }
            GC.SuppressFinalize(this);
        }

    }

}
