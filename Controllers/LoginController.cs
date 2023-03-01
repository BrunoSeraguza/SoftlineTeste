using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SoftLine.Models;
using SoftLine.Repositorio;
using System;

namespace SoftLine.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio= usuarioRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entrar(LoginModelcs loginmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginmodel.Login);
                    if(usuario != null  )
                    {
                        if(usuario.SenhaValida(loginmodel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                       

                    }
                    TempData["MensagemError"] = $"senha do usuario invalida, tente novamente";

                }
                return View("Index");

            }
            catch (Exception erro)
            {

                TempData["MensagemError"] = $"Ops, nao conseguimos realizar seu login,tente novamente {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
