using Microsoft.AspNetCore.Mvc;
using SoftLine.Models;
using SoftLine.Repositorio;

namespace SoftLine.Controllers
{
    public class ListCliController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ListCliController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio= clienteRepositorio;

        }
        public IActionResult Index()
        {
         List<ClienteModel> clientes =    _clienteRepositorio.BuscarTodos();
            return View(clientes);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
           ClienteModel cliente =  _clienteRepositorio.ListarPorId(id);    
            
            return View(cliente);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ClienteModel cliente = _clienteRepositorio.ListarPorId(id);

            return View(cliente);
        }
        public IActionResult Apagar(int id)
        {
            try
            {

               bool apagado = _clienteRepositorio.Apagar(id);

                if(apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso";

                }
                else
                {
                    TempData["MensagemError"] = $"Ops, nao conseguimos apagar seu contato";
                   
                }
                return RedirectToAction("Index");


            }
            catch (Exception erro)
            {

                TempData["MensagemError"] = $"Ops, nao conseguimos apagar seu contato, mais detalhes do erro {erro.Message}";
                return RedirectToAction("Index");
            }


        }

        [HttpPost]
        public IActionResult Criar(ClienteModel cliente)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Adicionar(cliente);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }


                return View(cliente );

            }
            catch (Exception erro)
            {

                TempData["MensagemError"] = $"Ops, nao conseguimos cadastrar seu contato, tente novamente , detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }


        }
        [HttpPost]
        public IActionResult Alterar(ClienteModel cliente)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Atualizar(cliente);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", cliente);

            }
            catch (Exception erro)
            {

                TempData["MensagemError"] = $"Ops, nao conseguimos atualizar seu contato, tente novamente , detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }


        }
    }
}
