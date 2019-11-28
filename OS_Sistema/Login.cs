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
    public partial class Login : Form
    {
        private string user = "root";
        private string password = "123";
        
       
        public Login()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string nome = txtUser.Text;
            string senha = txtPass.Text;
            if (nome == user && senha == password)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("ERRO AO EFETUAR LOGIN", "LOGIN INCORRETO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }
}
