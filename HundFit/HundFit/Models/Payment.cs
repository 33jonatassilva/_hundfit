namespace HundFit.Models;

public class Payment
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public float Value { get; set; }
    public DateTime PaymentDate { get; set; }
    public DateTime InvoiceDueDate { get; set; }
    public bool Status { get; set; }
}