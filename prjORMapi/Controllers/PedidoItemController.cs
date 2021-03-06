using System;
using Microsoft.AspNetCore.Mvc;
using prjORMapi.Domains;
using prjORMapi.Interfaces;
using prjORMapi.Repositories;
using System.Linq;
using System.Collections.Generic;

namespace prjORMapi.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
        [ApiController]
    public class PedidoItemController : ControllerBase
    {
        private readonly IPedidoItemRepository _pedidoItemRepository;
        
        public PedidoItemController()
        {
            _pedidoItemRepository = new PedidoItemRepository();

            
        }
          /// <summary>
        /// Ler todos os pedidosItems cadastrados
        /// </summary>
        /// <returns>Lista de pedidosItem</returns>
        [HttpGet("{id}")]
        public PedidoItem Get(Guid id)
        {
            try
            {
                return _pedidoItemRepository.BuscarPorId(id);
                
            }
            catch (Exception)
            {
                
                throw;
            }

        }
          /// <summary>
        /// Exclui um pedidoItem do sistema
        /// </summary>
        /// <param name="id">ID do pedidoItem a ser excluído</param>
        /// <returns>ID do pedidoItem excluído</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _pedidoItemRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
         
        /// <summary>
        /// Cadastra um pedidoItem na aplicação
        /// </summary>
        /// <param name="pedidoItem">Obejto completo de um pedidoItem</param>
        /// <returns>Pedido cadastrado</returns>
        [HttpPost]
        public IActionResult Post([FromForm]PedidoItem pedidoItem)
        {
            try
            {

                _pedidoItemRepository.Adicionar(pedidoItem);

                //retorna ok com os dados do pedidoItem
                return Ok(pedidoItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }
        /// <summary>
        /// Ler pedidositem
        /// </summary>
        /// <returns>Lista pedidositem</returns>
        [HttpGet]
         public List<PedidoItem> Get()
        {
           return _pedidoItemRepository.Listar();
        }
        

    }
}