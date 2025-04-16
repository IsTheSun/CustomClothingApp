namespace CustomClothingApp.Server.Models;
public partial class Order
{
    public int Orderid { get; set; }
    public int? Userid { get; set; }
    public int? Measurementsid { get; set; }
    public int? Modelid { get; set; }
    public int? Statusid { get; set; }
    public DateTime? Createddate { get; set; }
    public DateTime? Updateddate { get; set; }
    public string? Currentstage { get; set; }
    public string? Stagedescription { get; set; }
    public string? Escrowstatus { get; set; }
    public virtual Measurement? Measurements { get; set; }
    public virtual Clothingmodel? Model { get; set; }
    public virtual User? User { get; set; }
}
