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
    public partial class frmCarrinho : Form
    {
        List<Item> carinho = new List<Item>();
        DbClass classe = new DbClass();
        public frmCarrinho(List<Item> carrinho)
        {
            InitializeComponent();
            carinho = carrinho;
        }
        public void AtualizarDg()
        {
            dgCarrinho.Rows.Clear();
            SqlDataReader reader;
            foreach (Item item in carinho)
            {
                reader = classe.selecionar("tabitens", "*", "id", "=", item.Id);
                reader.Read();
                dgCarrinho.Rows.Add(reader["id"].ToString(), reader["nome"].ToString(), reader["marca"].ToString(), reader["preco"].ToString());
            }
        }
        private void frmCarrinho_Load(object sender, EventArgs e)
        {
            AtualizarDg();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           Item itemToRemove = new Item();
            foreach(Item item in carinho){
                if (item.Id == dgCarrinho.CurrentRow.Cells[0].Value.ToString())
                {
                    itemToRemove = item;
                }
            }
            carinho.Remove(itemToRemove);
            AtualizarDg();
            
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            carinho.Clear();
            AtualizarDg();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            frmBoleto formBoleto = new frmBoleto(carinho);
            formBoleto.ShowDialog();
        }
    }
}
