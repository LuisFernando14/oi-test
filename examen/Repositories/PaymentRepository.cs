using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using examen.Models;
using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace examen.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly string mssqlConnectionString;

        public PaymentRepository(string mssqlConnectionString)
        {
            this.mssqlConnectionString = mssqlConnectionString;
        }

        public async Task<bool> Delete(Guid id)
        {
            var query = "delete from payment where Id = @Id;";
            int count = 0;
            using (var connection = new SqlConnection(mssqlConnectionString))
            {
                await connection.OpenAsync();
                count = await connection.ExecuteAsync(query, new { id });
            }
            return count != 0;
        }

        public async Task<List<Payment>> GetAll()
        {
            var query = "Select * from payment;";
            var payments = new List<Payment>();
            using (var connection = new SqlConnection(mssqlConnectionString))
            {
                await connection.OpenAsync();
                var a = connection.QueryAsync<Payment>(query).Result.ToList<Payment>();
                payments = a;
            }
            return payments;
        }

        public async Task<Payment> GeyById(Guid Id)
        {
            var query = "Select * from payment where Id = @Id;";
            var payment = new Payment();
            using (var connection = new SqlConnection(mssqlConnectionString))
            {
                await connection.OpenAsync();
                var a = await connection.QueryFirstAsync<Payment>(query, new { Id = Id });
                payment = a;

            }
            return payment;
        }

        public async Task<Payment> Save(Payment payment)
        {
            var query = "Insert into payment (Id, Username, ReasonOfPayment, PaymentMethod) values (@Id, @Username, @ReasonOfPayment, @PaymentMethod);";
            int count = 0;
            using (var connection = new SqlConnection(mssqlConnectionString))
            {
                await connection.OpenAsync();
                count = await connection.ExecuteAsync(query, new { payment.Id, payment.Username, payment.ReasonOfPayment, payment.PaymentMethod });
            }
            if(count != 0)
                return payment;
            return null;
        }

        public async Task<Payment> Update(Guid Id, Payment payment)
        {
            var query = "Update payment set Username = @Username, ReasonOfPayment = @ReasonOfPayment, PaymentMethod = @PaymentMethod where Id = @Id;";
            int count = 0;
            using (var connection = new SqlConnection(mssqlConnectionString))
            {
                await connection.OpenAsync();
                count = await connection.ExecuteAsync(query, new { payment.Username, payment.ReasonOfPayment, payment.PaymentMethod, Id });
            }
            if (count != 0)
                return payment;
            return null;
        }
    }
}
