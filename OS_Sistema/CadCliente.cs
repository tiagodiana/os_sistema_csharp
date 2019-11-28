using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OS_Sistema
{
    public partial class CadCliente : Form
    {
        public CadCliente()
        {
            InitializeComponent();
        }

        private void CadCliente_Load(object sender, EventArgs e)
        {
            cmbEstado.SelectedIndex = 24;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome, cpf, tel, cel, rua, bairro, cidade, estado, cep;
            nome = txtNome.Text;
            cpf = mskCPF.Text;
            tel = mskTel.Text;
            cel = mskCel.Text;
            rua = txtRua.Text + "-" + txtNum.Text;
            bairro = txtBairro.Text;
            cidade = txtCidade.Text;
            estado = cmbEstado.Text;
            cep = mskCEP.Text; 

            Cliente novo_cliente = new Cliente(nome, cpf, tel, cel, rua, bairro, cidade, estado, cep);
            if (novo_cliente.cadastrar())
            {
                txtNome.Text = "";
                mskCPF.Text = "";
                mskTel.Text = "";
                mskCel.Text = "";
                txtRua.Text = ""; 
                txtNum.Text = "";
                txtBairro.Text = "";
                txtCidade.Text = "";
                cmbEstado.SelectedIndex = 0;
                mskCEP.Text = ""; 
                MessageBox.Show("Cadastrado Com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    

    }
}
