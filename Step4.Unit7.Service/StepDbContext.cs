using Microsoft.EntityFrameworkCore;
using Step4.Unit7.Model;

namespace Step4.Unit7.Service;

public class StepDbContext : DbContext
{
    public StepDbContext(DbContextOptions<StepDbContext> options) : base(options)
    {
     
    }
    
    public DbSet<Debtor> Debtors { get; set; }
    public DbSet<Account> Accounts { get; set; }
}