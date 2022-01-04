namespace dotnet_webapi.Models;

public class Contract
{
    public int ContractId { get; set; }
    public string? SenderName { get; set; }
    public string? RecipientName { get; set; }
    public double Amount { get; set; }
    public bool IsActive { get; set; }
}
