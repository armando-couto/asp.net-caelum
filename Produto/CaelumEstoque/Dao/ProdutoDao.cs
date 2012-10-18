using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaelumEstoque.Models;
using System.Data.Common;

namespace CaelumEstoque.Dao
{
    public class ProdutoDao
    {
        public List<Produto> Lista()
        {
            List<Produto> produtos = new List<Produto>();
            DBSession session = new DBSession();
            Query query = session.CreateQuery("select p.*, c.id as categoria_id, c.nome as categoria_nome " + 
                                        "from produtos p inner join categorias c on p.categoria_id=c.id");

            DbDataReader reader = query.ExecuteQuery();
            while (reader.Read())
            {
                CategoriaDoProduto categoria = new CategoriaDoProduto
                {
                    Id = reader.GetInt32(reader.GetOrdinal("categoria_id")),
                    Nome = reader.GetString(reader.GetOrdinal("categoria_nome"))
                };
                produtos.Add(new Produto { 
                    Id=reader.GetInt32(reader.GetOrdinal("id")), 
                    Nome=reader.GetString(reader.GetOrdinal("nome")), 
                    Preco=reader.GetFloat(reader.GetOrdinal("preco")),
                    Descricao = reader.GetString(reader.GetOrdinal("descricao")),
                    Quantidade = reader.GetInt32(reader.GetOrdinal("quantidade")),
                    Categoria = categoria
                });
            }
            reader.Close();

            session.Close();
            return produtos;
        }
        public void Salva(Produto produto)
        {
            DBSession session = new DBSession();

            String sql = String.Format("insert into produtos (nome, preco, descricao, categoria_id, quantidade) values " +
                "(@nome, @preco, @descricao, @categoriaId, @quantidade)");
            Query query = session.CreateQuery(sql);
            query.SetParameter("nome", produto.Nome)
                 .SetParameter("preco", produto.Preco)
                 .SetParameter("descricao", produto.Descricao)
                 .SetParameter("categoriaId", produto.Categoria.Id)
                 .SetParameter("quantidade", produto.Quantidade);
            query.ExecuteUpdate();
            session.Close();
        }
        public void Atualiza(Produto produto)
        {
            DBSession session = new DBSession();

            Query query = session.CreateQuery("update produtos set nome=@nome, preco=@preco, descricao=@descricao, categoria_id=@categoriaId, quantidade=@quantidade where id=@id");
            query.SetParameter("nome", produto.Nome)
                 .SetParameter("preco", produto.Preco)
                 .SetParameter("descricao", produto.Descricao)
                 .SetParameter("categoriaId", produto.Categoria.Id)
                 .SetParameter("quantidade", produto.Quantidade)
                 .SetParameter("id", produto.Id);
            query.ExecuteUpdate();
            session.Close();
        }
        public void Deleta(Produto produto)
        {
            DBSession session = new DBSession();
            Query query = session.CreateQuery("delete from produtos where id=@id");
            query.SetParameter("id", produto.Id);
            query.ExecuteUpdate();
            session.Close();
        }
        public Produto BuscaPorId(int id)
        {
            DBSession session = new DBSession();
            Query query = session.CreateQuery("select p.*, c.id as id_categoria, c.nome as nome_categoria, c.descricao as descricao_categoria " +
                                    "from produtos p inner join categorias c on p.categoria_id=c.id " +
                                    "where p.id = @produtoId");
            query.SetParameter("produtoId", id);
            DbDataReader reader = query.ExecuteQuery();
            Produto produto = null;
            if (reader.Read())
            {
                object[] array = new object[50];
                reader.GetValues(array);
                String nome = reader.GetName(8);
                CategoriaDoProduto categoria = new CategoriaDoProduto
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id_categoria")),
                    Nome = reader.GetString(reader.GetOrdinal("nome_categoria")),
                    Descricao = reader.GetString(reader.GetOrdinal("descricao_categoria"))
                };
                produto = new Produto
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    Nome = reader.GetString(reader.GetOrdinal("nome")),
                    Preco = reader.GetFloat(reader.GetOrdinal("preco")),
                    Descricao = reader.GetString(reader.GetOrdinal("descricao")),
                    Quantidade = reader.GetInt32(reader.GetOrdinal("quantidade")),
                    Categoria = categoria
                };
            }
            reader.Close();

            session.Close();

            return produto;
        }
    }
}