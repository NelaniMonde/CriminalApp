using LoanApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanApplication.Data
{
    public class AppDataBaseContext : DbContext
    {
        public AppDataBaseContext(DbContextOptions<AppDataBaseContext> options): base (options) 
        { }

        public DbSet<LoanModel> Loans { get; set; }
    }
}
