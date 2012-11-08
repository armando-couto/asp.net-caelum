using CaelumEstoque.Dao;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String nomeDeUsuario, String senha)
        {
            UsuarioDao dao = new UsuarioDao();
            Usuario usuario = dao.Busca(nomeDeUsuario, senha);
            if (usuario != null)
            {
                Session["usuario"] = usuario;
                return RedirectToRoute("ListaProdutos");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
