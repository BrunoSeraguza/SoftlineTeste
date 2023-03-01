using Microsoft.AspNetCore.Mvc;
using SoftLine.Models;
using SoftLine.Repositorio;

namespace SoftLine.Controllers
{
    public class ListProdController : Controller
    {
        private readonly IProdutoRepositorio _ProdutoRepositorio;
        public ListProdController(IProdutoRepositorio produtoRepositorio)
        {
            _ProdutoRepositorio = produtoRepositorio;

        }
        public IActionResult Index()
        {
            List<ProdutoModel> produtos = _ProdutoRepositorio.BuscarTodos();
            return View(produtos);
        }

        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ProdutoModel produto = _ProdutoRepositorio.ListarPorId(id);

            return View(produto);
        }

        public IActionResult Editar(int id)
        {
            ProdutoModel produto = _ProdutoRepositorio.ListarPorId(id);

            return View(produto);
        }

        public IActionResult Apagar(int id)
        {
            try
            {

                bool apagado = _ProdutoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Produto apagado com sucesso";

                }
                else
                {
                    TempData["MensagemError"] = $"Ops, nao conseguimos apagar seu Produto";

                }
                return RedirectToAction("Index");


            }
            catch (Exception erro)
            {

                TempData["MensagemError"] = $"Ops, nao conseguimos apagar seu produto, mais detalhes do erro {erro.Message}";
                return RedirectToAction("Index");
            }


        }
        [HttpPost]
        public IActionResult Criar(ProdutoModel produto)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _ProdutoRepositorio.Adicionar(produto);
                    TempData["MensagemSucesso"] = "produto cadastrado com sucesso";
                    return RedirectToAction("Index");
                }


                return View(produto);

            }
            catch (Exception erro)
            {

                TempData["MensagemError"] = $"Ops, nao conseguimos cadastrar seu produto, tente novamente , detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }


        }
        [HttpPost]
        public IActionResult Alterar(ProdutoModel produto)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _ProdutoRepositorio.Atualizar(produto);
                    TempData["MensagemSucesso"] = "produto alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", produto);

            }
            catch (Exception erro)
            {

                TempData["MensagemError"] = $"Ops, nao conseguimos atualizar seu produto, tente novamente , detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }


        }
    }
    
}
