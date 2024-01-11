using System.ComponentModel.DataAnnotations;

namespace ReviewApplication.WebAPI.Models;

public class Deposit
{
    [Key]
    public Guid Id { get; set; }
    public float Amount { get; set; }
    public string Description { get; set; } = null!;
    public DateTimeOffset CreatedAt { get; set; }
    public string UserFullName { get; set; }
}