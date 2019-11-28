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
    public partial class BuscarCliente : Form
    {
        //Variaveis de Escopo Global
        DataTable dados = new DataTable();
        Cliente cli;

        public BuscarCliente()
        {
            InitializeComponent();
        }

        private void BuscarCliente_Load(object sender, EventArgs e)
        {
            ativaItens();
            cmbEstado.SelectedIndex = 0;
            
        }
        //
        //BOTÃO BUSCAR
        //
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cpf = mskCpf.Text;
            cli = new Cliente(cpf);
            dados = cli.buscarCPF();
            if (dados.Rows.Count > 0)
            {
                string[] endereco = dados.Rows[0]["rua"].ToString().Split('-');
                txtCliente.Text = dados.Rows[0]["nome"].ToString();
                mskTel.Text = dados.Rows[0]["telefone"].ToString();
                mskCel.Text = dados.Rows[0]["celular"].ToString();
                txtRua.Text = endereco[0];
                txtNum.Text = endereco[1];
                txtBairro.Text = dados.Rows[0]["bairro"].ToString();
                txtCidade.Text = dados.Rows[0]["cidade"].ToString();
                cmbEstado.Text = dados.Rows[0]["estado"].ToString();
                mskCEP.Text = dados.Rows[0]["CEP"].ToString();
                ativaItens();
                btnBuscar.Enabled = !btnBuscar.Enabled;
            }
            else
            {
                MessageBox.Show("Não existe registros com esse CPF", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //
        //BOTÃO ALTERAR
        //
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            DialogResult confirma = MessageBox.Show("Deseja alterar os dados desse Cliente", "ALERTA", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (confirma == DialogResult.OK)
            {
                int id_cliente = Convert.ToInt16(dados.Rows[0]["id"]);
                string nome = txtCliente.Text;
                string cpf = mskCpf.Text;
                string tel = mskTel.Text;
                string cel = mskCel.Text;
                string rua = txtRua.Text + "-" + txtNum.Text;
                string bairro = txtBairro.Text;
                string cidade = txtCidade.Text;
                string estado = cmbEstado.Text;
                string cep = mskCEP.Text;
                Cliente alt_cliente = new Cliente(id_cliente, nome, cpf, tel, cel, rua, bairro, cidade, estado, cep);
                bool resultado = alt_cliente.alterarCliente();
                if (resultado)
                {
                    limpaCampos();
                    ativaItens();
                    MessageBox.Show("Dados do Cliente alterado com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnBuscar.Enabled = !btnBuscar.Enabled;
                }
                else
                {
                    MessageBox.Show("Erro ao alterar os dados do Cliente, Contate um administrador", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //
        //LIBERANDO OS CAMPOS OU BLOQUEANDO OS CAMPOS
        //
        private void ativaItens()
        {
            txtCliente.Enabled = !txtCliente.Enabled; 
            mskTel.Enabled = !mskTel.Enabled;
            mskCel.Enabled = !mskCel.Enabled;
            txtRua.Enabled = !txtRua.Enabled;
            txtNum.Enabled = !txtNum.Enabled;
            txtBairro.Enabled = !txtBairro.Enabled;
            txtCidade.Enabled = !txtCidade.Enabled;
            cmbEstado.Enabled = !cmbEstado.Enabled;
            mskCEP.Enabled = !mskCEP.Enabled;
            btnAlterar.Enabled = !btnAlterar.Enabled;
        }
        //
        //LIMPANDO CAMPOS
        //
        private void limpaCampos()
        {
            txtCliente.Text = "";
            mskCpf.Text = "";
            mskTel.Text = "";
            mskCel.Text = "";
            txtRua.Text = "";
            txtNum.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            cmbEstado.SelectedIndex = 0;
            mskCEP.Text = ""; 
        }
    }
}
