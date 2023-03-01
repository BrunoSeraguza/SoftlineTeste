using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftLine.Models;
using SoftLine.Repositorio;

namespace SoftLine.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _ProdutoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _ProdutoRepositorio = produtoRepositorio;

        }
        public IActionResult Index()
        {
            List<ProdutoModel> produtos = _ProdutoRepositorio.BuscarTodos();
            return View(produtos);

        }
    }
}
