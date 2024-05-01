using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.Domain.Commands.PaymentCommands;
using LivroMente.Service.Services;
using MediatR;

namespace LivroMente.API.Handlers.PaymentHandler
{
    public class UpdatePaymentHandler : IRequestHandler<PaymentUpdateCommand, bool>
    {
        private readonly PaymentService _paymentService;

        public UpdatePaymentHandler(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public async Task<bool> Handle(PaymentUpdateCommand request, CancellationToken cancellationToken)
        {
            var payment = await _paymentService.GetById(request.Id);
            if(payment == null) return false;
            payment.Description = request.PaymentRequest.Description;
            var result = await _paymentService.Update(payment.Id);
            if(!result) return false;
            return true;
        }
    }
}