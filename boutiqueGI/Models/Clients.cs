namespace boutiqueGI.Models
{
    public class Clients
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? PhoneNumber {  get; set; }
        public string? Email {  get; set; }
    }
}
