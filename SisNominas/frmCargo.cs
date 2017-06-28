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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cargo c = new Cargo();
            c.Descripcion = txtDescripcion.Text;
            if (Cargo.AgregarCargo(c))
            {
                MessageBox.Show("Se agrego satisfactoriamente", "Mantenimiento Cargos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                recargarDataGridView();
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
            if (dgvCargos.SelectedRows.Count > 0)
            {
                Cargo c = new Cargo();
                c.Codigo = (int)dgvCargos.SelectedRows[0].Cells[0].Value;
                c.Descripcion = dgvCargos.SelectedRows[0].Cells[1].Value.ToString();
                if (Cargo.EliminarCargo(c))
                {
                    MessageBox.Show("Se elimino satisfactoriamente", "Mantenimiento Cargos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    recargarDataGridView();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error durante el Proceso. Favor, verifique los datos ingresados y vuelva a intentarlo", "Mantenimiento Cargos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmCargo_Load(object sender, EventArgs e)
        {
            recargarDataGridView();
        }

        private void dgvCargos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCargos.SelectedRows.Count > 0)
            {
                txtDescripcion.Text = dgvCargos.SelectedRows[0].Cells[1].Value.ToString();
            }
        }

        private void recargarDataGridView()
        {
            dgvCargos.DataSource = null;
            dgvCargos.DataSource = Cargo.ObtenerTableCargos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvCargos.SelectedRows.Count > 0)
            {
                Cargo c = new Cargo();
                c.Codigo = (int)dgvCargos.SelectedRows[0].Cells[0].Value;
                c.Descripcion = txtDescripcion.Text;
                if (Cargo.ModificarCargo(c))
                {
                    MessageBox.Show("Se Modifico satisfactoriamente", "Mantenimiento Cargos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    recargarDataGridView();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error durante el Proceso. Favor, verifique los datos ingresados y vuelva a intentarlo", "Mantenimiento Cargos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
