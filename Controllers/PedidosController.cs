using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using prjORMapi.Domains;
using prjORMapi.Interfaces;
using prjORMapi.Repositories;

namespace prjORMapi.Controllers
{
   
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _pedidosRepository = new IPedidoRepository();
        
    

    /// <summary>
        /// Ler todos os pedidos cadastrados
        /// </summary>
        /// <returns>Lista de pedidos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var pedidos = _pedidosRepository.Listar();

                if (pedidos.Count == 0)
                    return NoContent();

                return Ok(pedidos);
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }
        [HttpPost]
       public IActionResult Post(List<PedidoItem> pedidoItems)
        {
            try
            {

                Pedido pedido = _pedidosReposiory.Adicionar(pedidosItems);

                return Ok(pedido);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}