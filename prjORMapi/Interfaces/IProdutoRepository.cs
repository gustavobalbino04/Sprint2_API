using System;
using System.Collections.Generic;
using prjORMapi.Domains;

namespace prjORMapi.Interfaces
{
    public interface IProdutoRepository
    {
         List<Produto> Listar();
         List<Produto>  BuscarPorNome(string nome);
         Produto BuscarPorId(Guid id);
         Produto Adicionar(Produto produto);
         Produto Editar(Produto produto);
         void Remover(Guid id);

         
    }
}