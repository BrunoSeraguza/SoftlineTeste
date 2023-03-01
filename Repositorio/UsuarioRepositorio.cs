using SoftLine.Data;
using SoftLine.Models;


namespace SoftLine.Repositorio
{

    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;

        }
        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }
        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();

            return usuario;
            //Gravar no banco de dados

        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel UsuarioDb = ListarPorId(usuario.Id);
            if (UsuarioDb == null) throw new Exception("Houve um erro na atualizacao do usuario");

            UsuarioDb.Nome= usuario.Nome;
            UsuarioDb.Email = usuario.Email;
            UsuarioDb.Login = usuario.Login;
            UsuarioDb.Perfil = usuario.Perfil;
            UsuarioDb.DataAtualizacao = DateTime.Now;
           
            _bancoContext.Usuarios.Update(UsuarioDb);
            _bancoContext.SaveChanges();

            return UsuarioDb;
            
        }

        public bool Apagar(int id)
        {
            UsuarioModel UsuarioDb = ListarPorId(id);
            if (UsuarioDb == null) throw new Exception("Houve um erro na delecao do cliente");
            _bancoContext.Usuarios.Remove(UsuarioDb);
            _bancoContext.SaveChanges();
            return true;

        }

       
    }
}
