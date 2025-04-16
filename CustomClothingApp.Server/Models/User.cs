namespace CustomClothingApp.Server.Models;
public partial class User
{
    public int Userid { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Userrole { get; set; }
    public DateTime? Createddate { get; set; }
    public string? PasswordHash { get; set; }
    public virtual ICollection<Measurement> Measurements { get; set; } = new List<Measurement>();
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
