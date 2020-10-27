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
         void Adicionar(Produto produto);
         void Editar(Produto produto);
         void Remover(Guid id);

         
    }
}