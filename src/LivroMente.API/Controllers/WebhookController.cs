using Microsoft.AspNetCore.Mvc;

namespace LivroMente.API.Controllers
{
    [Route("[controller]")]
    public class WebhookController : Controller
    {
        private readonly ILogger<WebhookController> _logger;

        public WebhookController(ILogger<WebhookController> logger)
        {
            _logger = logger;
        }

       [HttpPost]
        public IActionResult ReceiveNotification([FromBody] dynamic notification)
        {
            // Aqui você pode processar os dados da notificação como preferir
            try
    {
        // Exibir dados da notificação no console para debug
        Console.WriteLine(notification);

        // Processar a notificação recebida
        // Sua lógica de negócio aqui

        // Retornar status 200 (OK) para o Mercado Pago
        return Ok(notification);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erro ao processar a notificação: " + ex.Message);
        return StatusCode(500, "Erro interno do servidor.");
    }
        }
    }
}