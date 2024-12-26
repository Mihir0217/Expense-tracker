using Microsoft.EntityFrameworkCore;

namespace firstmvc.Models;

public class ExpensesDbContext : DbContext
{
   public DbSet<Expense> Spendings {get; set;}    //spendings is our table name

   public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options)
      :base(options)
   {
    
   }
}
