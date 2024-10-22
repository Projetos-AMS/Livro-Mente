// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using LivroMente.Domain.Commands.PreferenceCommands;
// using MediatR;
// using MercadoPago.Client;
// using MercadoPago.Client.Preference;
// using MercadoPago.Config;
// using Microsoft.AspNetCore.Mvc;

// namespace LivroMente.API.Handlers.PreferenceHandler
// {
//     public class CreatePreferenceHandler : IRequestHandler<PreferenceAddCommand, IActionResult>
//     {
 
//     public async Task<IActionResult> Handle(PreferenceAddCommand request, CancellationToken cancellationToken)
//     {
//         if (request.PreferenceRequest == null || !request.PreferenceRequest.Items.Any())
//         {
//             return new BadRequestObjectResult("Solicitação de preferência inválida.");
//         }

//         try
//         {
//             // Configurar o Access Token do Mercado Pago (considere usar um método seguro para armazenar isso)
//             MercadoPagoConfig.AccessToken = "TEST-6690749639432154-082222-75bdf4bbcafff2fc0a7d2ef8bf6ffbb8-1956922079";

//             var requestOptions = new RequestOptions
//             {
//                 CustomHeaders = { { "x-idempotency-key", Guid.NewGuid().ToString() } }
//             };

//             var preferenceRequest = new MercadoPago.Client.Preference.PreferenceRequest
//             {
//                 Items = request.PreferenceRequest.Items.Select(item => new MercadoPago.Client.Preference.PreferenceItemRequest
//                 {
//                     Id = item.Id,
//                     Title = item.Title,
//                     Description = item.Description,
//                     Quantity = item.Quantity,
//                     CurrencyId = item.CurrencyId,
//                     UnitPrice = item.UnitPrice
//                 }).ToList()
//             };

//             var client = new PreferenceClient();
//             var preference = await client.CreateAsync(preferenceRequest, requestOptions);

//             return new OkObjectResult(preference);
//         }
//         catch (Exception ex)
//         {
//             // Logar detalhes da exceção para análise posterior (opcional)
//             // logger.LogError(ex, "Erro ao criar preferência de pagamento");

//             return new BadRequestObjectResult(new { Message = "Ocorreu um erro ao criar a preferência de pagamento.", Details = ex.Message });
//         }
//     }
//     }
// }