using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using System.Data;
using System.Data.Common;

namespace CaelumEstoque.Dao
{
    public class Query
    {
        private SQLiteCommand _Command;
        public Query(String sql, SQLiteConnection connection)
        {
            _Command = new SQLiteCommand(connection);
            _Command.CommandText = sql + ";";
        }
        public void ExecuteUpdate()
        {
            _Command.ExecuteNonQuery();
        }
        public DbDataReader ExecuteQuery()
        {
            return _Command.ExecuteReader();
        }
        public Query SetParameter(String nome, object valor)
        {
            _Command.Parameters.AddWithValue("@" + nome, valor);
            return this;
        }
    }
    public class DBSession
    {
        private SQLiteConnection _Connection;
        public DBSession()
        {
            _Connection = new SQLiteConnection("Data Source=|DataDirectory|estoque.db");
            _Connection.Open();
        }
        public void Close()
        {
            _Connection.Close();
        }
        public Query CreateQuery(String sql) 
        {
            return new Query(sql, _Connection);
        }
    }
}