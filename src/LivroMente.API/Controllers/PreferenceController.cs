using System.Net;
using DotNetEnv;
using MercadoPago.Client;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreferenceRequest = LivroMente.API.Requests.PreferenceRequest;

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
            Env.Load();
            string MercadoPagoToken = Environment.GetEnvironmentVariable("TokenMercadoPago");
            try{
        MercadoPagoConfig.AccessToken = MercadoPagoToken;
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
            Success = "http://localhost:4200/success",
            Failure = "http://localhost:4200/failure",
            Pending = "http://localhost:4200/pending"
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