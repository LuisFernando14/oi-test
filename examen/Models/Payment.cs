using System;
namespace examen.Models
{
    public class Payment
    {
        public Guid Id = Guid.NewGuid();
        public string Username { get; set; }
        public string ReasonOfPayment { get; set; }
        public int PaymentMethod { get; set; }
        public DateTime CreatedAt { get; set; }

        public Payment()
        {

        }

        public Payment(Guid Id, string Username, string ReasonOfPayment, int PaymentMethod, DateTime CreatedAt)
        {
            this.Id = Id;
            this.Username = Username;
            this.ReasonOfPayment = ReasonOfPayment;
            this.PaymentMethod = PaymentMethod;
            this.CreatedAt = CreatedAt;
        }
    }
}
