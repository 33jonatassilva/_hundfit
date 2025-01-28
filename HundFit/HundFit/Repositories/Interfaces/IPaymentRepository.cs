using HundFit.Models;

namespace HundFit.Repositories.Interfaces;

public interface IPaymentRepository
{
    public Payment Create(Payment payment);
    public List<Payment> GetAll();
    public Payment GetById(Guid id);
    public Payment Update(Payment payment);
    public Payment Delete(Payment payment);
}