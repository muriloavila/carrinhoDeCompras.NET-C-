using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carrinhoDeCompras
{
    public class Item
    {
        private string id;
        private string nome;
        private string marca;
        private double preco;
        private string descricao;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        public double Preco
        {
            get { return preco; }
            set { preco = value; }
        }
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}
