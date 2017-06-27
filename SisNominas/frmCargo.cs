using Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisNominas
{
    public partial class frmCargo : Form
    {
        public frmCargo()
        {
            InitializeComponent();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            frmConsulta frm = new frmConsulta();
            frm.listaCargos = Cargo.ObtenerCargos();
            frm.Show();
            Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cargo c = new Cargo();
            c.Descripcion = txtDescripcion.Text;
            if (Cargo.AgregarCargo(c))
            {
                MessageBox.Show("Se agrego satisfactoriamente", "Mantenimiento Cargos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Ocurrio un error durante el Proceso. Favor, verifique los datos ingresados y vuelva a intentarlo", "Mantenimiento Cargos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            txtDescripcion.Text = string.Empty;
            txtDescripcion.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cargo c = new Cargo();
            c.Descripcion = txtDescripcion.Text;
            if (Cargo.EliminarCargo(c))
            {
                MessageBox.Show("Se elimino satisfactoriamente", "Mantenimiento Cargos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Ocurrio un error durante el Proceso. Favor, verifique los datos ingresados y vuelva a intentarlo", "Mantenimiento Cargos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
