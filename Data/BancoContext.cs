using Microsoft.EntityFrameworkCore;
using SoftLine.Models;

namespace SoftLine.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) 
        {


        }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        //aqui em baixo vai faltar a conexao com os produtos
    }
}
