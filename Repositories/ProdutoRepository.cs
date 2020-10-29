using System;
using System.Collections.Generic;
using System.Linq;
using prjORMapi.Contexts;
using prjORMapi.Domains;
using prjORMapi.Interfaces;

namespace prjORMapi.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PedidoContext _ctx;
        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }
        #region Leitura
            
        /// <summary>
        /// Lista todos os produtos cadastrados 
        /// </summary>
        /// <returns>Retorna lista de produto</returns>
         public List<Produto> Listar()
        {
            try
            {
                return _ctx.Produtos.ToList();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Busca produto por nome
        /// /// </summary>
        /// <param name="nome">nome do produto</param>
        /// <returns>Retorna um produto</returns>
       
        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                
                return _ctx.Produtos.Where(c => c.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      
        /// <summary>
        /// Buscar produto por seu id
        /// </summary>
        /// <param name="id">id do produto</param>
        /// <returns>Lista de produto</returns>
        public Produto BuscarPorId(Guid id)
        {
            try
            {
                //return _ctx.Produtos.Find(id);
               return _ctx.Produtos.FirstOrDefault(x => x.Id == id);          
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }


        #endregion
        #region Gravação
        /// <summary>
        /// Edita um produto cadastrado
        /// </summary>
        /// <param name="produto">Produto a ser editado</param>
        public void Editar(Produto produto)
        {
            try
            {
                //Buscar produto pelo id
                Produto produtoT = BuscarPorId(produto.Id);
                //verifica se produto existe
                //caso não existe gera um expception
                if(produtoT == null)
                throw new Exception("Produto não encontrado, digite novamente ");
                //Caso exista altera sua propriedades
                produtoT.Nome = produto.Nome;
                produtoT.Preco = produto.Preco;

                //Altera produto no contexto
                _ctx.Produtos.Update(produtoT);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Adiciona um novo produto
        /// </summary>
        /// <param name="produto">Objeto do tipo Produto</param>
        public void Adicionar(Produto produto)
        {
            try
            {
                //Add produto
            _ctx.Produtos.Add(produto);
            /* Outras formas de operrar
            _ctx.Set<Produto>().Add(produto);
            _ctx.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Added;*/

            //Salva as alterarçoes no context 
            _ctx.SaveChanges();
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
                Produto produtoT = BuscarPorId(id);
                //verifica se produto existe
                //caso não existe gera um expception
                if(produtoT == null)
                throw new Exception("Produto não encontrado, digite novamente ");

                _ctx.Produtos.Remove(produtoT);
                _ctx.SaveChanges();
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }







        #endregion
    }
}