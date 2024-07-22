using System;

namespace Capstone1 {
    public class User {
        public long Id { get; set; } // Ensure this matches your schema (bigint unsigned)

        public string FirstName { get; set; } // Should match 'first_name'
        public string LastName { get; set; } // Should match 'last_name'
        public string Email { get; set; } // Should match 'email'
        public string Phone { get; set; } // Optional: Should match 'phone'
        public string Role { get; set; } // Should match 'role'
        public string Password { get; set; } // Should match 'password'
        public DateTime? EmailVerifiedAt { get; set; } // Nullable timestamp
        public bool IsActive { get; set; } // Should match 'is_active'
        public string RememberToken { get; set; } // Optional: Should match 'remember_token'
        public DateTime? DeletedAt { get; set; } // Nullable timestamp
        public DateTime CreatedAt { get; set; } // Should match 'created_at'
        public DateTime UpdatedAt { get; set; } // Should match 'updated_at'
        public long? DealershipId { get; set; } // Optional: Should match 'dealership_id'
    }
}
