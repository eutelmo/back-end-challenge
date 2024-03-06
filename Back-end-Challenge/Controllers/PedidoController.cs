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
            pedido = 123456,
            itens = new List<OrderItem>
            {
                new OrderItem
                {
                    descricao = "Description",
                    precoUnitario = 1,
                    qtd = 1,
                }
            }
        }
    };



            return Ok(orders);
        }
    }
}
