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
using System.Reflection;

namespace carrinhoDeCompras
{
    public partial class frmLoja : Form
    {
        List<Item> carrinho = new List<Item>();
        DbClass databaseLoja = new DbClass();
        public frmLoja()
        {
            InitializeComponent();
        }

        private void frmLoja_Load(object sender, EventArgs e)
        {
            SqlDataReader dr = databaseLoja.selecionar("tabitens");
            while (dr.Read())
            {
                dgLoja.Rows.Add(dr["id"].ToString(), dr["nome"].ToString(), dr["marca"].ToString(), dr["preco"].ToString());
            }
            
        }

        private void dgLoja_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string idItem = dgLoja.CurrentRow.Cells[0].Value.ToString();
            frmItem formItem = new frmItem(idItem, carrinho);
            formItem.ShowDialog();

        }

        private void dgLoja_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string idItem = dgLoja.CurrentRow.Cells[0].Value.ToString();
            frmItem formItem = new frmItem(idItem, carrinho);
            formItem.ShowDialog();
        }

        private void btnCarrinho_Click(object sender, EventArgs e)
        {
            frmCarrinho carro = new frmCarrinho(carrinho);
            carro.ShowDialog();
        }
    }
}
