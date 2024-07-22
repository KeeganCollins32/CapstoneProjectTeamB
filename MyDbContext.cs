using System.Data.Entity;
using Capstone1;

public class MyDbContext : DbContext {
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        // Configure the User entity to map to the 'users' table
        modelBuilder.Entity<User>()
            .ToTable("users");

        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .HasColumnName("id");

        modelBuilder.Entity<User>()
            .Property(u => u.FirstName)
            .HasColumnName("first_name");

        modelBuilder.Entity<User>()
            .Property(u => u.LastName)
            .HasColumnName("last_name");

        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .HasColumnName("email");

        modelBuilder.Entity<User>()
            .Property(u => u.Phone)
            .HasColumnName("phone");

        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasColumnName("role");

        modelBuilder.Entity<User>()
            .Property(u => u.EmailVerifiedAt)
            .HasColumnName("email_verified_at");

        modelBuilder.Entity<User>()
            .Property(u => u.Password)
            .HasColumnName("password");

        modelBuilder.Entity<User>()
            .Property(u => u.IsActive)
            .HasColumnName("is_active");

        modelBuilder.Entity<User>()
            .Property(u => u.RememberToken)
            .HasColumnName("remember_token");

        modelBuilder.Entity<User>()
            .Property(u => u.DeletedAt)
            .HasColumnName("deleted_at");

        modelBuilder.Entity<User>()
            .Property(u => u.CreatedAt)
            .HasColumnName("created_at");

        modelBuilder.Entity<User>()
            .Property(u => u.UpdatedAt)
            .HasColumnName("updated_at");

        modelBuilder.Entity<User>()
            .Property(u => u.DealershipId)
            .HasColumnName("dealership_id");

        base.OnModelCreating(modelBuilder);
    }
}