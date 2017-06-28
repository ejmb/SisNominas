using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;

namespace SisNominas
{
    public partial class frmEmpleado : Form
    {
        public frmEmpleado()
        {
            InitializeComponent();
        }

        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            cboEstado.DataSource = null;
            cboEstado.DataSource = Enum.GetValues(typeof(Estado));
            cboTipoDocumento.DataSource = null;
            cboTipoDocumento.DataSource = Enum.GetValues(typeof(TipoDocumento));
            cboCargoActual.DataSource = null;
            cboCargoActual.DataSource = Cargo.ObtenerListaCargos();
            recargarDataGridView();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Empleado em = new Empleado();
            em.Nombres = txtNombres.Text;
            em.Apellidos = txtApellidos.Text;
            em.Direccion = txtDireccion.Text;
            em.NroDocumento = txtNroDocumento.Text;
            em.TipoDocumento = (TipoDocumento)cboTipoDocumento.SelectedItem;
            em.NroCelular = txtNroCelular.Text;
            em.FechaIngreso = dtpFechaIngreso.Value;
            em.CargoActual = (Cargo)cboCargoActual.SelectedItem;
            em.DiasVacacionesAcumuladas = int.Parse(txtVacaciones.Text);
            em.DiasLibresAFavor = int.Parse(txtDiasAFavor.Text);
            em.Estado = (Estado)cboEstado.SelectedItem;
            em.SalarioBaseActual = int.Parse(txtSalario.Text);

            if (Empleado.AgregarEmpleado(em))
            {
                MessageBox.Show("Se agrego satisfactoriamente", "Mantenimiento Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                recargarDataGridView();
            }
            else
            {
                MessageBox.Show("Ocurrio un error durante el Proceso. Favor, verifique los datos ingresados y vuelva a intentarlo", "Mantenimiento Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            txtNombres.Text = String.Empty;
            txtApellidos.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            txtNroDocumento.Text = String.Empty;
            cboTipoDocumento.SelectedItem = null;
            txtNroCelular.Text = String.Empty;
            dtpFechaIngreso.Value = DateTime.Now;
            cboCargoActual.SelectedItem = null;
            txtVacaciones.Text = String.Empty;
            txtDiasAFavor.Text = String.Empty;
            cboEstado.SelectedItem = null;
            txtSalario.Text = String.Empty;

            txtNombres.Focus();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Empleado em = new Empleado();
            em.Codigo = (int)dgvEmpleado.SelectedRows[0].Cells[0].Value;
            em.Nombres = txtNombres.Text;
            em.Apellidos = txtApellidos.Text;
            em.Direccion = txtDireccion.Text;
            em.NroDocumento = txtNroDocumento.Text;
            em.TipoDocumento = (TipoDocumento)cboTipoDocumento.SelectedItem;
            em.NroCelular = txtNroCelular.Text;
            em.FechaIngreso = dtpFechaIngreso.Value;
            em.CargoActual = (Cargo)cboCargoActual.SelectedItem;
            em.DiasVacacionesAcumuladas = int.Parse(txtVacaciones.Text);
            em.DiasLibresAFavor = int.Parse(txtDiasAFavor.Text);
            em.Estado = (Estado)cboEstado.SelectedItem;
            em.SalarioBaseActual = int.Parse(txtSalario.Text);

            if (Empleado.ModificarEmpleado(em))
            {
                MessageBox.Show("Se Modifico satisfactoriamente", "Mantenimiento Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                recargarDataGridView();
            }
            else
            {
                MessageBox.Show("Ocurrio un error durante el Proceso. Favor, verifique los datos ingresados y vuelva a intentarlo", "Mantenimiento Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmpleado.SelectedRows.Count > 0)
            {
                txtNombres.Text = dgvEmpleado.SelectedRows[0].Cells[1].Value.ToString();
                txtApellidos.Text = dgvEmpleado.SelectedRows[0].Cells[2].Value.ToString();
                txtDireccion.Text = dgvEmpleado.SelectedRows[0].Cells[3].Value.ToString();
                txtNroDocumento.Text = dgvEmpleado.SelectedRows[0].Cells[4].Value.ToString();
                cboTipoDocumento.SelectedIndex = cboTipoDocumento.FindStringExact(dgvEmpleado.SelectedRows[0].Cells[5].Value.ToString());
                txtNroCelular.Text = dgvEmpleado.SelectedRows[0].Cells[6].Value.ToString();
                dtpFechaIngreso.Value = (DateTime)dgvEmpleado.SelectedRows[0].Cells[7].Value;
                cboCargoActual.SelectedIndex = cboCargoActual.FindStringExact(Cargo.ObtenerDescripcionCargo((int)dgvEmpleado.SelectedRows[0].Cells[8].Value));
                txtVacaciones.Text = dgvEmpleado.SelectedRows[0].Cells[9].Value.ToString();
                txtDiasAFavor.Text = dgvEmpleado.SelectedRows[0].Cells[10].Value.ToString();
                cboEstado.SelectedIndex = cboEstado.FindStringExact(dgvEmpleado.SelectedRows[0].Cells[11].Value.ToString());
                txtSalario.Text = dgvEmpleado.SelectedRows[0].Cells[12].Value.ToString();
            }
        }

        private void recargarDataGridView()
        {
            dgvEmpleado.DataSource = null;
            dgvEmpleado.DataSource = Empleado.ObtenerTablaEmpleados();
        }
    }
}
