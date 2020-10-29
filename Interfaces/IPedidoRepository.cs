using System.Collections.Generic;
using prjORMapi.Domains;

namespace prjORMapi.Interfaces
{
    public interface IPedidoRepository
    {
         List<Pedido> Listar();

         Pedido Adicionar(List<PedidoItem> pedidosItens);
         
    }
}