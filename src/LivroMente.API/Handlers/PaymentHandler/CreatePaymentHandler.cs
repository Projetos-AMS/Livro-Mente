using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.Domain.Commands.PaymentCommands;
using LivroMente.Domain.Models.PaymentModel;
using LivroMente.Service.Services;
using MediatR;

namespace LivroMente.API.Handlers.PaymentHandler
{
    public class CreatePaymentHandler : IRequestHandler<PaymentAddCommand, bool>
    {
        private readonly PaymentService _paymentService;

        public CreatePaymentHandler(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public async Task<bool> Handle(PaymentAddCommand request, CancellationToken cancellationToken)
        {
            var payment = new Payment
            {
                Description = request.Description,
            };

            var result = await _paymentService.Add(payment);
            if(!result) return false;
            return true;
        }
    }
}