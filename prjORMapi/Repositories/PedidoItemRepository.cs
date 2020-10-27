using System;
using System.Collections.Generic;
using System.Linq;
using prjORMapi.Contexts;
using prjORMapi.Domains;
using prjORMapi.Interfaces;

namespace prjORMapi.Repositories
{
    public class PedidoItemRepository : IPedidoItemRepository
    {
         private readonly PedidoContext _ctx;
        public PedidoItemRepository()
        {
            _ctx = new PedidoContext();
        }
        public void Adicionar(PedidoItem pedidoItem)
        {
            throw new NotImplementedException();
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
                return _ctx.PedidoItems.ToList();
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