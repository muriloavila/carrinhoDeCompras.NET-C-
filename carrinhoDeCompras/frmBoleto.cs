using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carrinhoDeCompras
{
    public partial class frmBoleto : Form
    {
        List<Item> carinho = new List<Item>();
        public frmBoleto(List<Item> carrinho)
        {
            carinho = carrinho;
            InitializeComponent();
        }

        private void frmBoleto_Load(object sender, EventArgs e)
        {
            double total = 0;
            foreach (Item item in carinho)
            {
                total += item.Preco;
            }
            lblTotal.Text = total.ToString();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
