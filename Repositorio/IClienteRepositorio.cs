using SoftLine.Models;

namespace SoftLine.Repositorio
{
    public interface IClienteRepositorio
    {
        ClienteModel ListarPorId(int id);
        List<ClienteModel> BuscarTodos();
        ClienteModel Adicionar(ClienteModel cliente);
        ClienteModel Atualizar(ClienteModel cliente);
        bool Apagar(int id);
        

        
    }
}
