using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.Domain.Commands.PaymentCommands;
using LivroMente.Service.Services;
using MediatR;

namespace LivroMente.API.Handlers.PaymentHandler
{
    public class DeletePaymentHandler : IRequestHandler<PaymentDeleteCommand, bool>
    {
        private readonly PaymentService _paymentService;

        public DeletePaymentHandler(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public async  Task<bool> Handle(PaymentDeleteCommand request, CancellationToken cancellationToken)
        {
            var payment = await _paymentService.GetById(request.Id);
            if(payment == null) return false;
            var result = await _paymentService.Delete(payment.Id);
            if(!result) return false;
            return true;
        }
    }
}