using LivroMente.API.Commands.PaymentCommands;
using LivroMente.Domain.Models.PaymentModel;
using LivroMente.Service.Interfaces;
using MediatR;

namespace LivroMente.API.Handlers.PaymentHandler
{
    public class CreatePaymentHandler : IRequestHandler<PaymentAddCommand, bool>
    {
        
        private readonly IPaymentService _paymentService;

        public CreatePaymentHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
    
        }
        public async Task<bool> Handle(PaymentAddCommand request, CancellationToken cancellationToken)
        {
            var payment = new Payment
            (
                request.Description
            );

            var result = await _paymentService.Add(payment);
            if(!result) return false;
            return true;
        }
    }
}