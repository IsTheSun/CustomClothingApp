namespace CustomClothingApp.Server.Models;
public partial class Clothingmodel
{
    public int Modelid { get; set; }
    public string? Modelname { get; set; }
    public string? Modeldescription { get; set; }
    public decimal? Baseprice { get; set; }
    public DateTime? Createddate { get; set; }
    public string? Category { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
