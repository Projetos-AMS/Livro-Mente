using LivroMente.API.Commands.PaymentCommands;
using LivroMente.Service.Interfaces;
using MediatR;

namespace LivroMente.API.Handlers.PaymentHandler
{
    public class DeletePaymentHandler : IRequestHandler<PaymentDeleteCommand, bool>
    {
        private readonly IPaymentService _paymentService;

        public DeletePaymentHandler(IPaymentService paymentService)
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