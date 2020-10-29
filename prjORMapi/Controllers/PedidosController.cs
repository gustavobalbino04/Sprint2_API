using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using prjORMapi.Domains;
using prjORMapi.Interfaces;
using prjORMapi.Repositories;

namespace prjORMapi.Controllers
{
   
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class Pedidocontroller : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;
        
    }
    public PedidosController()
    {
        _pedidoRepository = new PedidoRepository();
    }
    /// <summary>
        /// Ler todos os pedidos cadastrados
        /// </summary>
        /// <returns>Lista de pedidos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var pedidos = _pedidoRepository.Listar();

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
       public IActionResult Post(List<PedidoItem> pedidosItems)
        {
            try
            {

                Pedido pedido = _pedidoReposiory.Adicionar(pedidosItems);

                return Ok(pedido);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

}