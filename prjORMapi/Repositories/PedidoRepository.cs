using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using prjORMapi.Contexts;
using prjORMapi.Domains;
using prjORMapi.Interfaces;

namespace prjORMapi.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
         private readonly PedidoContext _ctx;

        public PedidoRepository()
        {
            _ctx = new PedidoContext();
        }
        public Pedido Adicionar(List<PedidoItem> pedidosItens)
        {
           try
           {
               Pedido pedido = new Pedido()
               {
                   Status = "Pedidos Efetuado",
                   OrderDate = DateTime.Now,
                   PedidosItens = new List<PedidoItem>(),
               };
               foreach (var item in pedidosItens)
                {
                    pedido.PedidosItens.Add(new PedidoItem
                    {
                        IdPedido = pedido.Id, 
                        IdProduto = item.IdProduto, 
                        Quantidade = item.Quantidade 
                    });
                }
                    _ctx.Pedidos.Add(pedido);
                
                    _ctx.SaveChanges();

                return pedido;
           }
           catch (Exception ex)
           {
               
               throw new Exception(ex.Message);
           }
        }

        public List<Pedido> Listar()
        {
            try
            {
                return _ctx.Pedidos
                        .Include(i => i.PedidosItens)
                        .ThenInclude(x => x.Produto)
                        .ToList(); 
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
    }
}