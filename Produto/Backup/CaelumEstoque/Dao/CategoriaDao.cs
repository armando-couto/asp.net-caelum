using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using CaelumEstoque.Models;

namespace CaelumEstoque.Dao
{
    public class CategoriaDao
    {
        public List<CategoriaDoProduto> Lista()
        {
            List<CategoriaDoProduto> categorias = new List<CategoriaDoProduto>();
            DBSession session = new DBSession();
            DbDataReader reader = session.CreateQuery("select * from categorias").ExecuteQuery();
            while (reader.Read())
            {
                categorias.Add(new CategoriaDoProduto
                {
                    Nome = reader.GetString(reader.GetOrdinal("nome")),
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    Descricao = reader.GetString(reader.GetOrdinal("descricao"))
                });
            }
            reader.Close();
            return categorias;
        }

        public void Salva(CategoriaDoProduto categoria)
        {
            DBSession session = new DBSession();
            Query query = session.CreateQuery("insert into categorias (nome, descricao) values (@nome, @descricao)");
            query.SetParameter("nome", categoria.Nome)
                 .SetParameter("descricao", categoria.Descricao);
            query.ExecuteUpdate();
        }

        public CategoriaDoProduto BuscaPorId(int id)
        {
            DBSession session = new DBSession();
            Query query = session.CreateQuery("select * from categorias where id = @id");
            query.SetParameter("id", id);
            DbDataReader reader = query.ExecuteQuery();
            CategoriaDoProduto categoria = null;
            if (reader.Read())
            {
                categoria = new CategoriaDoProduto
                {
                    Nome = reader.GetString(reader.GetOrdinal("nome")),
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    Descricao = reader.GetString(reader.GetOrdinal("descricao"))
                };
            }
            return categoria;
        }
    }
}