using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using prjORMapi.Domains;
using prjORMapi.Interfaces;
using prjORMapi.Repositories;

namespace prjORMapi.Controllers
{
   
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class Pedidoscontroller : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;
        
    public  Pedidoscontroller()
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

                Pedido pedidos = _pedidoRepository.Adicionar(pedidosItems);

                return Ok(pedidos);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    };
}