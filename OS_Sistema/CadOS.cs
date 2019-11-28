using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_Sistema
{
    public partial class CadOS : Form
    {
        DataTable clientes;
        public CadOS()
        {
            InitializeComponent();
        }

        private void CadOS_Load(object sender, EventArgs e)
        {
            try
            {
                Cliente all_cliente = new Cliente();
                clientes = all_cliente.todosClientes();
                if (clientes.Rows.Count > 0)
                {
                    cmbClientes.DataSource = clientes;
                    cmbClientes.DisplayMember = "nome";
                    cmbClientes.ValueMember = "id";
                    cmbClientes.SelectedIndex = -1;
                }
                else
                {
                    btnCriar.Enabled = false;
                    cmbClientes.Enabled = false;
                    cmbClientes.Items.Add("Não Existe Clientes Cadastrados");
                    cmbClientes.SelectedIndex = 0;
                }
                cmbTipo.SelectedIndex = 0;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro " + erro, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            int id_cliente;
            string tipo, marca, modelo, num_serie, defeito, solucao;
            decimal valor;

            id_cliente = Convert.ToInt16(cmbClientes.SelectedValue);
            tipo = cmbTipo.Text;
            marca = txtMarca.Text;
            modelo = txtModelo.Text;
            num_serie = txtSerie.Text;
            defeito = txtrichDefeito.Text;
            solucao = txtrichSolucao.Text;
            valor = Convert.ToDecimal(txtValor.Text);

            Ordem nova_ordem = new Ordem(tipo, marca, modelo, num_serie, defeito, solucao, valor);

            if (nova_ordem.novaOrdem(id_cliente))
            {
               
                MessageBox.Show("Cadastrado Com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro ao Cadastrar", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
     
    }
}
