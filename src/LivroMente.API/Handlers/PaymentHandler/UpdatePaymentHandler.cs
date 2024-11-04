using LivroMente.API.Commands.PaymentCommands;
using LivroMente.Service.Interfaces;
using MediatR;

namespace LivroMente.API.Handlers.PaymentHandler
{
    public class UpdatePaymentHandler : IRequestHandler<PaymentUpdateCommand, bool>
    {
        private readonly IPaymentService _paymentService;

        public UpdatePaymentHandler(IPaymentService paymentService)
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