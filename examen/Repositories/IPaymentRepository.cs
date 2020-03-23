using System;
using examen.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace examen.Repositories
{
    public interface IPaymentRepository
    {
        Task<Payment> Save(Payment payment);
        Task<List<Payment>> GetAll();
        Task<Payment> GeyById(Guid Id);
        Task<Payment> Update(Guid id, Payment payment);
        Task<bool> Delete(Guid id);
    }
}
