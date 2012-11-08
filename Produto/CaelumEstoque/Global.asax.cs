using CaelumEstoque.Dao;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CaelumEstoque
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "ListaProdutos",
                "produtos",
                new { controller = "Produto", action = "Index" }
            );
            routes.MapRoute(
                "VisualizaProduto",
                "produtos/{id}",
                new { controller = "Produto", action = "Visualiza" }
            );
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        
        //public ActionResult RecuperaSenha(String email)
        //{
        //    UsuarioDao dao = new UsuarioDao();
        //    Usuario usuario = dao.BuscaPorEmail(email);
        //    GeraNovaSenha(usuario);
        //   dao.Atualiza(usuario);
        //    EnviaNovaSenhaParaOEmailDoUsuario(usuario);
        //    return View();
        //}
    }
}