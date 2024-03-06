using Back_end_Challenge.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_end_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pedidoController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            var orders = new List<Order>
            {
                new Order
                {
                    Pedido = 123456,
                    Itens = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            Descricao = "Description",
                            PrecoUnitario = 1,
                            Qtd = 1,
                        }
                    }
                }
            };



            return Ok(orders);
        }
    }
}
