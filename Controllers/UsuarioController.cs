using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SoftLine.Models;
using SoftLine.Repositorio;

namespace SoftLine.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;

        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);

            return View(usuario);
        }
        public IActionResult Apagar(int id)
        {
            try
            {

                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuario apagado com sucesso";

                }
                else
                {
                    TempData["MensagemError"] = $"Ops, nao conseguimos apagar seu  usuario";

                }
                return RedirectToAction("Index");


            }
            catch (Exception erro)
            {

                TempData["MensagemError"] = $"Ops, nao conseguimos apagar esse usuario, mais detalhes do erro {erro.Message}";
                return RedirectToAction("Index");
            }


        }


        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso";
                    return RedirectToAction("Index");
                }


                return View(usuario);

            }
            catch (Exception erro)
            {

                TempData["MensagemError"] = $"Ops, nao conseguimos cadastrar seu usuario, tente novamente , detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }


        }
        [HttpPost]
        public IActionResult Alterar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil

                    };
                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", usuario);

            }
            catch (Exception erro)
            {

                TempData["MensagemError"] = $"Ops, nao conseguimos atualizar seu Usuario, tente novamente , detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }


        }
    }
}
