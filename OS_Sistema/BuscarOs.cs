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
    public partial class BuscarOs : Form
    {
        Ordem ordem;
        DataTable dados;
        public BuscarOs()
        {
            InitializeComponent();
        }

        private void BuscarOs_Load(object sender, EventArgs e)
        {
            ativarCampos();  
        }
        //
        // BOTÃO PARA BUSCAR OS
        //
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ordem = new Ordem(Convert.ToInt16(txtNumOS.Text));
            dados = ordem.buscarOrdem();
            try
            {
                if (dados.Rows.Count > 0)
                {
                    ativarCampos();
                    btnBuscar.Enabled = false;
                    txtNumOS.Enabled = false;
                    txtCliente.Text = dados.Rows[0]["nome"].ToString();
                    cmbTipo.Text = dados.Rows[0]["tipo"].ToString();
                    txtMarca.Text = dados.Rows[0]["marca"].ToString();
                    txtModelo.Text = dados.Rows[0]["modelo"].ToString();
                    txtSerie.Text = dados.Rows[0]["num_serie"].ToString();
                    txtDefeito.Text = dados.Rows[0]["defeito"].ToString();
                    txtSolucao.Text = dados.Rows[0]["solucao"].ToString();
                    txtValor.Text = dados.Rows[0]["valor"].ToString();
                    if (Convert.ToBoolean(dados.Rows[0]["status"]))
                    {
                        lblStatus.ForeColor = Color.Green;
                        lblStatus.Text = "Finalizada";
                        ativarCampos();
                        btnBuscar.Enabled = true;
                        txtNumOS.Enabled = true;
                    }
                    else
                    {
                        lblStatus.ForeColor = Color.Red;
                        lblStatus.Text = "Aberta";
                    }
                }
                else
                {
                    MessageBox.Show("Ordem de Serviço não existe", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(""+erro, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        //BOTÃO FINALIZAR OS
        //
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            DialogResult confirma = MessageBox.Show("Deseja finalizar essa Ordem de Serviço?", "Confirmação", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirma == DialogResult.OK)
            {
                bool result = ordem.finalizarOrdem();
                if (result)
                {
                    ativarCampos();
                    limpaCampos();
                    btnBuscar.Enabled = true;
                    txtNumOS.Enabled = true;
                    MessageBox.Show("Ordem Finalizada Com Sucesso", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Não foi possivel Finalizar a OS", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //
        //BOTÃO VOLTAR RESETA OS CAMPOS
        //
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            ativarCampos();
            limpaCampos();
            btnBuscar.Enabled = true;
            txtNumOS.Enabled = true;
        }

        //
        //FUNÇÃO PARA ATIVAR OU DESATIVAR OS CAMPOS
        //
        private void ativarCampos()
        {
            txtCliente.Enabled = !txtCliente.Enabled;
            cmbTipo.Enabled = !cmbTipo.Enabled;
            txtMarca.Enabled = !txtMarca.Enabled;
            txtModelo.Enabled = !txtModelo.Enabled;
            txtSerie.Enabled = !txtSerie.Enabled;
            txtDefeito.Enabled = !txtDefeito.Enabled;
            txtSolucao.Enabled = !txtSolucao.Enabled;
            txtValor.Enabled = !txtValor.Enabled;
            btnFinalizar.Enabled = !btnFinalizar.Enabled;
            btnAlterar.Enabled = !btnAlterar.Enabled;
            btnDeletar.Enabled = !btnDeletar.Enabled;
            btnVoltar.Enabled = !btnVoltar.Enabled;
        }
        //
        //FUNÇÃO PARA LIMPAR OS CAMPOS
        //
        private void limpaCampos()
        {
            foreach (Control c in pnlDados.Controls)
            {
                if (c is TextBox || c is ComboBox || c is RichTextBox || c.Name == "lblStatus")
                {
                    c.Text = "";
                }
            }
        }
        //
        //ALTERANDO ORDEM DE SERVIÇO 
        //
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            DialogResult confirmacao = MessageBox.Show("Deseja alterar essa Ordem de Serviço?", "Confirmação", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirmacao == DialogResult.OK)
            {
                int id_os;
                string tipo, marca, modelo, num_serie, defeito, solucao;
                decimal valor;
                id_os = Convert.ToInt16(txtNumOS.Text);
                tipo = cmbTipo.Text;
                marca = txtMarca.Text;
                modelo = txtModelo.Text;
                num_serie = txtSerie.Text;
                defeito = txtDefeito.Text;
                solucao = txtSolucao.Text;
                valor = Convert.ToDecimal(txtValor.Text);
                ordem = new Ordem(id_os, tipo, marca, modelo, num_serie, defeito, solucao, valor);
                bool result = ordem.alterarOrdem();
                if (result)
                {
                    MessageBox.Show("Ordem de Serviço Alterada Com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Não foi possivel alterar a Ordem de Serviço", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            DialogResult confirmacao = MessageBox.Show("Deseja realmente deletar essa Ordem de Serviço?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirmacao == DialogResult.OK)
            {
                int id_os = Convert.ToInt16(txtNumOS.Text);
                ordem = new Ordem(id_os);
                ordem.deltarOrdem();
                ativarCampos();
                limpaCampos();
                btnBuscar.Enabled = true;
                txtNumOS.Enabled = true;
                MessageBox.Show("Ordem de Serviço Deletada Com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
    }
}
