using SoftLine.Data;
using SoftLine.Models;

namespace SoftLine.Repositorio
{

    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ClienteRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;

        }
        public ClienteModel ListarPorId(int id)
        {
            return _bancoContext.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public List<ClienteModel> BuscarTodos()
        {
            return _bancoContext.Clientes.ToList();
        }
        public ClienteModel Adicionar(ClienteModel cliente)
        {
            _bancoContext.Clientes.Add(cliente);
            _bancoContext.SaveChanges();

            return cliente;
            //Gravar no banco de dados

        }

        public ClienteModel Atualizar(ClienteModel cliente)
        {
            ClienteModel ClienteDb = ListarPorId(cliente.Id);
            if (ClienteDb == null) throw new Exception("Houve um erro na atualizacao do cliente");
            
            ClienteDb.Nome= cliente.Nome;
            ClienteDb.Fantasia = cliente.Fantasia;
            ClienteDb.Documento = cliente.Documento;    
            ClienteDb.Endereco = cliente.Endereco;
            _bancoContext.Clientes.Update(ClienteDb);
            _bancoContext.SaveChanges();

            return ClienteDb;
            
        }

        public bool Apagar(int id)
        {
            ClienteModel ClienteDb = ListarPorId(id);
            if (ClienteDb == null) throw new Exception("Houve um erro na delecao do cliente");
            _bancoContext.Clientes.Remove(ClienteDb);
            _bancoContext.SaveChanges();
            return true;

        }
    }
}
