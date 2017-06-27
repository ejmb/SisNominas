using Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisNominas_Clases;

namespace SisNominas
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            ConexionBD cx = new ConexionBD();
            if (cx.ProbarConexion())
            {
                Thread.Sleep(5000);
                frmSplash.CloseSplash();
            }
            else
            {
                MessageBox.Show("NO SE PUEDE CONECTAR A LA BD");
                frmSplash.CloseSplash();
            }

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Favor Ingresar Usuario");
                return;
            }

            if (txtPass.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Favor Ingresar Contraseña");
                return;
            }

            if (Usuario.Autenticar(txtUser.Text, txtPass.Text))
            {
                this.Hide();
                MessageBox.Show("Bienvenido " + txtUser.Text);
                frmMenu menu = new frmMenu();
                menu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario y/o Contraseña Incorrecto/s.");
                txtUser.Text = string.Empty;
                txtPass.Text = string.Empty;
                txtUser.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
