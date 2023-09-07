using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMVC.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set;}
        public decimal Valor { get; set; }
        public string Validade { get; set; }
        public bool Ativo{ get; set; }
    }
}