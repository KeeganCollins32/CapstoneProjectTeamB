using Capstone1;
using System;
using System.Data.Entity;

public class MyDbContext : DbContext {
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        modelBuilder.Entity<User>().ToTable("users"); // Ensure this matches your table name
    }
}
