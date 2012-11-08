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

        public ActionResult Visualiza(int id)
        {
            ProdutoDao dao = new ProdutoDao();
            Produto produto = dao.BuscaPorId(id);
            return View(produto);
        }

        public ActionResult Form()
        {
            CategoriaDao dao = new CategoriaDao();
            ViewBag.Produto = new Produto
            {
                Categoria = new CategoriaDoProduto()
            };
            List<CategoriaDoProduto> categorias = dao.Lista();
            return View(categorias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adiciona(Produto produto)
        {
            int idDaInformatica = 1;
            double informatica = 100;
            if(produto.Categoria.Id.Equals(idDaInformatica))
            {
                ModelState.AddModelError("produto.InformaticaComPrecoInvalido", "Produtos da categoria informática devem");
            }
            if (produto.Categoria.Equals(informatica))
            {
                ModelState.AddModelError("produto.InformaticaComPrecoInvalido", "Produtos da categoria informática devem ter preço maior do que 100");
            }
            if(ModelState.IsValid) 
            {
                ProdutoDao dao = new ProdutoDao();
                dao.Salva(produto);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Produto = produto;
                CategoriaDao categoriaDao = new CategoriaDao();
                List<CategoriaDoProduto> categorias = categoriaDao.Lista();
                return View("Form", categorias);
            }
        }

        [HttpPost]
        public ActionResult DecrementaQuantidade(int produtoId)
        {
            ProdutoDao dao = new ProdutoDao();
            Produto produto = dao.BuscaPorId(produtoId);
            if (produto.Quantidade > 0)
            {
                produto.Quantidade--;
            }
            dao.Atualiza(produto);
            return Json(produto);
        }
    }
}
