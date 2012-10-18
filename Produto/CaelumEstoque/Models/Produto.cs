using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CaelumEstoque.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public String Nome { get; set; }
        
        public float Preco { get; set; }

        public CategoriaDoProduto Categoria { get; set; }

        public String Descricao { get; set; }

        public int Quantidade { get; set; }
    }
    
}