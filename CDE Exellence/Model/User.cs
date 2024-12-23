﻿namespace CDE_Exellence.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = "User";
        public string Region { get; set; } = null!; // Vùng quản lý
    }
}
