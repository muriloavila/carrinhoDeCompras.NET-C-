using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace carrinhoDeCompras
{
    public partial class frmItem : Form
    {
        string indice;
        List<Item> carinho = new List<Item>();
        DbClass databaseLoja = new DbClass();
        public frmItem(string id, List<Item> carrinho)
        {
            indice = id;
            InitializeComponent();
            carinho = carrinho;
            
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
            SqlDataReader reader = databaseLoja.selecionar("tabitens", "*", "id", "=", indice);
            reader.Read();
            lblNome.Text = reader["nome"].ToString();
            lblMarca.Text = reader["marca"].ToString();
            lblPreco.Text = reader["preco"].ToString();
            lblDescricao.Text = reader["descricao"].ToString();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            item.Id = indice;
            item.Nome = lblNome.Text;
            item.Marca = lblMarca.Text;
            item.Preco = Convert.ToDouble(lblPreco.Text);
            item.Descricao = lblDescricao.Text;
            carinho.Add(item);
            frmCarrinho formCarrinho = new frmCarrinho(carinho);
            this.Close();
            formCarrinho.ShowDialog();
        }
    }
}
