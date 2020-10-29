using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using prjORMapi.Contexts;
using prjORMapi.Domains;
using prjORMapi.Interfaces;

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
        public void Adicionar(PedidoItem pedidoItem)
        {
            try{
            
            _ctx.PedidoItems.Add(pedidoItem);
          
            _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PedidoItem BuscarPorId(Guid Id)
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

        public List<PedidoItems> Listar(PedidoItem pedidoItems)
        {
             try
            {
                return _ctx.pedidoItems.ToList();
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