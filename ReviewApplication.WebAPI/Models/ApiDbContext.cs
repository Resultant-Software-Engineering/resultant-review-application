using Microsoft.EntityFrameworkCore;

namespace ReviewApplication.WebAPI.Models;

public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
{
    public DbSet<User?> Users { get; set; }
    public DbSet<Deposit> Deposits { get; set; }
    public DbSet<Withdrawal> Withdrawals { get; set; }
}