using System;
using System.Threading.Tasks;
using examen.Models;
using examen.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace examen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await paymentRepository.GetAll();
            return Ok(new
            {
                correct = true,
                title = "Mensaje del sistema",
                message = "Success. Payments",
                payments = response,
                fullStackTrace = "",
            });
        }

       
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(string Id)
        {
            var response = await paymentRepository.GeyById(new Guid(Id));
            return Ok(new
            {
                correct = true,
                title = "Mensaje del sistema",
                message = "Success. Payment",
                payment = response,
                fullStackTrace = "",
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Payment payment)
        {
            var response = await paymentRepository.Save(payment);
            return Ok(new
            {
                correct = true,
                title = "Mensaje del sistema",
                message = "Payment saved",
                payment = response,
                fullStackTrace = ""
            });
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(string Id, [FromBody] Payment payment)
        {
            var response = await paymentRepository.Update(new Guid(Id), payment);
            return Ok(new
            {
                correct = true,
                title = "Mensaje del sistema",
                message = "Payment updated",
                payment = response,
                fullStackTrace = ""
            });
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            var response = await paymentRepository.Delete(new Guid(Id));
            return Ok(new
            {
                correct = response,
                title = "Mensaje del sistema",
                message = "Payment deleted",
                userData = response,
                fullStackTrace = "",
            });
        }
    }
}
