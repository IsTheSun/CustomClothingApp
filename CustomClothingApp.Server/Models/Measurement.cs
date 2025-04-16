namespace CustomClothingApp.Server.Models;
public partial class Measurement
{
    public int Measurementsid { get; set; }
    public int? Userid { get; set; }
    public decimal? Height { get; set; }
    public decimal? Chest { get; set; }
    public decimal? Waist { get; set; }
    public decimal? Hip { get; set; }
    public string? Othermeasurements { get; set; }
    public DateTime? Createddate { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual User? User { get; set; }
}
