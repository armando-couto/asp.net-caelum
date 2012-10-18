using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaelumEstoque.Models;
using CaelumEstoque.Dao;

namespace CaelumEstoque.Controllers
{
    public class CategoriaController : Controller
    {
        //
        // GET: /Categoria/

        public ActionResult Index()
        {
            CategoriaDao dao = new CategoriaDao();
            List<CategoriaDoProduto> categoria = dao.Lista();
            return View(categoria);
        }

    }
}
