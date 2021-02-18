using Microsoft.EntityFrameworkCore;
using AccountingApp.Models;


    public class DatabaseContext : DbContext
{
        public DatabaseContext (DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<AccountingApp.Models.Company> Company { get; set; }

        public DbSet<AccountingApp.Models.AppUser> AppUser { get; set; }

        public DbSet<AccountingApp.Models.Role> Role { get; set; }

        public object Address { get; internal set; }

        public DbSet<AccountingApp.Models.Invoice> Invoice { get; set; }

        public DbSet<AccountingApp.Models.InvoiceItem> InvoiceItem { get; set; }

        public DbSet<AccountingApp.Models.ViewModels.AdminUserEdit> AdminUserEdit { get; set; }

}
