using System;
using System.Collections.Generic;
using prjORMapi.Domains;

namespace prjORMapi.Interfaces
{
    public interface IPedidoItemRepository
    {
         List<PedidoItem> Listar();
         
         PedidoItem BuscarPorId(Guid id);
         void Adicionar(PedidoItem pedidoItem);
         void Remover(Guid id);
    }
}