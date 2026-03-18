using Accounting_Settle_Up_System.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounting_Settle_Up_System.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<ExpenseSplit> ExpenseSplits { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure UserGroup composite key (if still using composite, 
        // though BaseEntity adds an Id, often junction tables use composite or keep Id)
        // I'll keep the composite key as it's standard for junctions.
        modelBuilder.Entity<UserGroup>()
            .HasKey(ug => new { ug.GroupId, ug.UserId });

        // Configure navigation properties for UserGroup
        modelBuilder.Entity<UserGroup>()
            .HasOne(ug => ug.Group)
            .WithMany(g => g.UserGroups)
            .HasForeignKey(ug => ug.GroupId);

        modelBuilder.Entity<UserGroup>()
            .HasOne(ug => ug.User)
            .WithMany(u => u.UserGroups)
            .HasForeignKey(ug => ug.UserId);

        // Configure Expense - User relationship (PaidBy)
        modelBuilder.Entity<Expense>()
            .HasOne(e => e.PaidBy)
            .WithMany(u => u.ExpensesPaid)
            .HasForeignKey(e => e.PaidById)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure Payment relationships
        modelBuilder.Entity<Payment>()
            .HasOne(p => p.FromUser)
            .WithMany()
            .HasForeignKey(p => p.FromUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.ToUser)
            .WithMany()
            .HasForeignKey(p => p.ToUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Group)
            .WithMany()
            .HasForeignKey(p => p.GroupId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
