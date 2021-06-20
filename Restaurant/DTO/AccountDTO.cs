using System;
namespace Restaurant.DTO
{
    /// <summary>
    /// Account Data Transfer Object
    /// </summary>
    public class AccountDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
    }
}
