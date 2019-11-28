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
    public partial class Inicio : Form
    {
        Conexao con = new Conexao();
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblData.Text = DateTime.Now.ToLongDateString();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void novoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadCliente tela_cadUser = new CadCliente();
            tela_cadUser.ShowDialog();
        }

        private void timerHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sobre tela_sobre = new Sobre();
            tela_sobre.ShowDialog();
        }

        private void novaOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadOS tela_novaOs = new CadOS();
            tela_novaOs.ShowDialog();
        }

        private void buscarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarCliente tela_BuscaCliente = new BuscarCliente();
            tela_BuscaCliente.ShowDialog();
        }

        private void buscarOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarOs tela_BuscaOs = new BuscarOs();
            tela_BuscaOs.ShowDialog();
        }
    }
}
