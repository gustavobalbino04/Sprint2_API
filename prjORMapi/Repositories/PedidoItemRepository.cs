using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using prjORMapi.Contexts;
using prjORMapi.Domains;
using prjORMapi.Interfaces;
using System.Threading.Tasks;

namespace prjORMapi.Repositories
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
        [ApiController]
    public class PedidoItemRepository : IPedidoItemRepository
    {
         private readonly PedidoContext _ctx;
        public PedidoItemRepository()
        {
            _ctx = new PedidoContext();
        }
        public void Adicionar(PedidoItem pedidoItens)
        {
            try{
            
            _ctx.PedidoItems.Add(pedidoItens);
          
            _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PedidoItem BuscarPorId(Guid id)
        {
             try
            {
               return _ctx.PedidoItems.FirstOrDefault(x => x.Id == id);          
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public List<PedidoItem> Listar()
        {
             try
            {
                List<PedidoItem> pitens = _ctx.PedidoItems.ToList();
                return pitens;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid id)
        {
             try
            {
                PedidoItem pedidoIT = BuscarPorId(id);
                if(pedidoIT == null)
                throw new Exception("Pedido Item não encontrado  ");

                _ctx.PedidoItems.Remove(pedidoIT);
                _ctx.SaveChanges();
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
    }
}