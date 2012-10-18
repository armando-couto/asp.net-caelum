using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Common;
using CaelumEstoque.Models;

namespace CaelumEstoque.Dao
{
    public class UsuarioDao
    {
        public Usuario Busca(String usuario, String senha)
        {
            var session = new DBSession();
            Query query = session.CreateQuery("select * from usuarios where username=@usuario and senha=@senha");
            query.SetParameter("usuario", usuario);
            query.SetParameter("senha", senha);
            DbDataReader reader = query.ExecuteQuery();
            Usuario user = null;
            if (reader.Read())
            {
                user = new Usuario
                {
                    Login = reader.GetString(reader.GetOrdinal("username")),
                    Senha = reader.GetString(reader.GetOrdinal("senha"))
                };
            }
            return user;
        }
    }
}
