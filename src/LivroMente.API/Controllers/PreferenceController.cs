using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LivroMente.Domain.Requests;
using MercadoPago.Client;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreferenceRequest = LivroMente.Domain.Requests.PreferenceRequest;

namespace LivroMente.API.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous] 

    public class PreferenceController : ControllerBase
    {
          [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody]PreferenceRequest preferenceResquest)
        {
            try{
        MercadoPagoConfig.AccessToken = "TEST-6690749639432154-082222-75bdf4bbcafff2fc0a7d2ef8bf6ffbb8-1956922079";
         var requestOptions = new RequestOptions();
         requestOptions.CustomHeaders.Add("x-idempotency-key", Guid.NewGuid().ToString());

          var request = new MercadoPago.Client.Preference.PreferenceRequest
            {
                Items = preferenceResquest.Items.Select(item => new MercadoPago.Client.Preference.PreferenceItemRequest
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Quantity = item.Quantity,
                    CurrencyId = item.CurrencyId = "BRL",
                    UnitPrice = item.UnitPrice
                }).ToList(),

                  BackUrls = new PreferenceBackUrlsRequest
        {
            Success = "http://localhost:4200/Success",
            Failure = "http://localhost:4200/Failure",
            Pending = "http://localhost:4200/Pending"
        },
                      
            };

         var client = new PreferenceClient();
         var preference = await client.CreateAsync( request, requestOptions);
         return Ok(new { Preference = preference });
          
    // Retorne o initPoint para ser usado no front-end
    
         
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
        }
    }
}