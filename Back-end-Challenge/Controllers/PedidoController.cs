using Back_end_Challenge.Data;
using Back_end_Challenge.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back_end_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PedidoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // Get All
        [HttpGet]
        public async Task<ActionResult<Order>> GetAllPedidos()
        {
            var orders = await _appDbContext.Orders.ToListAsync();

            return Ok(orders);
        }

        // Get Pedido
        [HttpGet("{numeroPedido}")]
        public async Task<ActionResult<List<Order>>> GetPedidosByNumero(int numeroPedido)
        {
            var order = await _appDbContext.Orders.FindAsync(numeroPedido);
            if (order is null)
                return NotFound("CODIGO_PEDIDO_INVALIDO");

            return Ok(order);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<List<Order>>> AddPedido([FromBody] Order order)
        {
            _appDbContext.Orders.Add(order);
            await _appDbContext.SaveChangesAsync();

            return Ok(await _appDbContext.Orders.ToListAsync());
        }

        // PUT
        [HttpPut]
        public async Task<ActionResult<List<Order>>> UpdatePedido([FromBody] Order UpdatedOrder)
        {
            var dbOrder = await _appDbContext.Orders.FindAsync(UpdatedOrder.Pedido);

            if (dbOrder is null)
                return NotFound("CODIGO_PEDIDO_INVALIDO");



            dbOrder.Pedido = UpdatedOrder.Pedido;

            foreach (var updatedItem in UpdatedOrder.Itens)
            {
                var dbItem = dbOrder.Itens.FirstOrDefault(i => i.Descricao == updatedItem.Descricao);

                if (dbItem != null)
                {
                    dbItem.Descricao = updatedItem.Descricao;
                    dbItem.PrecoUnitario = updatedItem.PrecoUnitario;
                    dbItem.Qtd = updatedItem.Qtd;
                }
                else
                {
                    dbOrder.Itens.Add(updatedItem);
                }
            }

            await _appDbContext.SaveChangesAsync();

            return Ok(await _appDbContext.Orders.ToListAsync());
        }

        // DELETE

        [HttpDelete("{numeroPedido}")]
        public async Task<ActionResult<List<Order>>> DeletePedido(int numeroPedido)
        {
            var dbOrder = await _appDbContext.Orders.FindAsync(numeroPedido);

            if (dbOrder is null)
            {
                return NotFound("CODIGO_PEDIDO_INVALIDO");
            }

            _appDbContext.Orders.Remove(dbOrder);

            await _appDbContext.SaveChangesAsync();

            return Ok(await _appDbContext.Orders.Include(o => o.Itens).ToListAsync());
        }
    }
}
