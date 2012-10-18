using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaelumEstoque.Models;
using CaelumEstoque.Dao;

namespace CaelumEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        //
        // GET: /Produto/

        public ActionResult Index()
        {
            ProdutoDao dao = new ProdutoDao();
            List<Produto> produtos = dao.Lista();
            return View(produtos);
        }

        public ActionResult Visualiza()
        {
            return View();
        }
    }
}
