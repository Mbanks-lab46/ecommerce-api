namespace EcommerceAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Order> Orders {get; set; } = new List<Order>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
}
}
