using System.ComponentModel.DataAnnotations;

namespace ReviewApplication.WebAPI.Models;

public class User
{
    [Key]
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string BankAccountNumber { get; set; } = null!;
}