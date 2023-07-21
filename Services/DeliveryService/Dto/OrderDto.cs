namespace Delivery.Dto;

public class OrderDto
{
    public int Id { get; init; }
    public required string SenderCity { get; set; }
    public required string SenderAddress { get; set; }
    public required string ReceiverCity { get; set; }
    public required string ReceiverAddress { get; set; }
    public required double CargoWeight { get; set; }
    public required DateOnly PickupDate { get; set; }
}