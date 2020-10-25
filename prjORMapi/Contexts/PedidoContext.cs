using Microsoft.EntityFrameworkCore;
using prjORMapi.Domains;

namespace prjORMapi.Contexts

{
    public class PedidoContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoItem> PedidoItems{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
               optionsBuilder.UseSqlServer(@"Data source= LAPTOP-KNDOV3AI\SQLEXPRESS;Initial Catalog=PedidosItem;user id=sa; password=sa132");

            base.OnConfiguring(optionsBuilder);
        }  
    }
}