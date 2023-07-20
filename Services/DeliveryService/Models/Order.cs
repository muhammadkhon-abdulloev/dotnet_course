using System.ComponentModel.DataAnnotations.Schema;

namespace Delivery.Models;

[Table("order")]
public class Order
{
    public int Id { get; set; }
    public required string SenderCity { get; set; }
    public required string SenderAddress { get; set; }
    public required string ReceiverCity { get; set; }
    public required string ReceiverAddress { get; set; }
    public required double CargoWeight { get; set; }
    public required DateOnly PickupDate { get; set; }
}