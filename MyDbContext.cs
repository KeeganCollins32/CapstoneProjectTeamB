using System.Data.Entity;

namespace Capstone1 {
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
                .HasColumnName("UserID");

            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .HasColumnName("FirstName");

            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .HasColumnName("LastName");

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasColumnName("Email");

            modelBuilder.Entity<User>()
                .Property(u => u.PhoneNumber)
                .HasColumnName("PhoneNumber");

            modelBuilder.Entity<User>()
                .Property(u => u.Address)
                .HasColumnName("Address");

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasColumnName("Password");

            modelBuilder.Entity<User>()
                .Property(u => u.UserType)
                .HasColumnName("UserType");

            modelBuilder.Entity<User>()
                .Property(u => u.ProfilePicture)
                .HasColumnName("ProfilePicture");

            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasColumnName("CreatedAt");

            modelBuilder.Entity<User>()
                .Property(u => u.UpdatedAt)
                .HasColumnName("UpdatedAt");

            base.OnModelCreating(modelBuilder);
        }
    }
}
