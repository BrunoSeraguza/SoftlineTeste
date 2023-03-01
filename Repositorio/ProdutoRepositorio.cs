using SoftLine.Data;
using SoftLine.Models;

namespace SoftLine.Repositorio
{

    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ProdutoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;

        }
        public ProdutoModel ListarPorId(int id)
        {
            return _bancoContext.Produtos.FirstOrDefault(x => x.Id == id);
        }

        public List<ProdutoModel> BuscarTodos()
        {
            return _bancoContext.Produtos.ToList();
        }
        public ProdutoModel Adicionar(ProdutoModel produto)
        {
            _bancoContext.Produtos.Add(produto);
            _bancoContext.SaveChanges();

            return produto;
            //Gravar no banco de dados

        }

        public ProdutoModel Atualizar(ProdutoModel produto)
        {
            ProdutoModel ProdutoDb = ListarPorId(produto.Id);
            if (ProdutoDb == null) throw new Exception("Houve um erro na atualizacao do Produto");

            ProdutoDb.Descricao= produto.Descricao;
            ProdutoDb.CodigoDeBarras = produto.CodigoDeBarras;
            ProdutoDb.PesoBruto = produto.PesoBruto;
            ProdutoDb.PesoLiquido = produto.PesoLiquido;
            _bancoContext.Produtos.Update(ProdutoDb);
            _bancoContext.SaveChanges();

            return ProdutoDb;
            
        }

        public bool Apagar(int id)
        {
            ProdutoModel ProdutoDb = ListarPorId(id);
            if (ProdutoDb == null) throw new Exception("Houve um erro na delecao do produto");
            _bancoContext.Produtos.Remove(ProdutoDb);
            _bancoContext.SaveChanges();
            return true;

        }
    }
}
