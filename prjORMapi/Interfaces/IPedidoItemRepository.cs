using System;
using System.Collections.Generic;
using prjORMapi.Domains;
using System.Linq;
using System.Threading.Tasks;

namespace prjORMapi.Interfaces
{
    public interface IPedidoItemRepository
    {
         List<PedidoItem> Listar();
         
         PedidoItem BuscarPorId(Guid id);
         void Adicionar(PedidoItem pedidoItens);
         void Remover(Guid id);
    }
}