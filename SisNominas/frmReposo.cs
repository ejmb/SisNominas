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
    public partial class frmReposo : Form
    {
        public frmReposo()
        {
            InitializeComponent();
        }

        public void cargarDataGridView()
        {
            dgvEmpleados.DataSource = null;
            dgvEmpleados.DataSource = Empleado.ObtenerTablaEmpleados();
        }

        public void cargarDataGridViewReposos(int idEmpleado)
        {
            dgvReposo.DataSource = null;
            dgvReposo.DataSource = Reposo.ObtenerTablaReposoPorEmpleado(idEmpleado);
        }

        private void Limpiar()
        {
            txtNombres.Text = String.Empty;
            txtApellidos.Text = String.Empty;
            txtNroDocumento.Text = String.Empty;
            dtpFechaReposo.Value = DateTime.Now;
            txtObservaciones.Text = String.Empty;
            txtDiasReposo.Text = String.Empty;
            txtNombres.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                Reposo r = new Reposo();
                Empleado em = new Empleado();
                em.Codigo = (int)dgvEmpleados.SelectedRows[0].Cells[0].Value;

                r.Empleado = em;
                r.FechaInicial = dtpFechaReposo.Value;
                r.Observacion = txtObservaciones.Text;
                r.CantDiasReposo = int.Parse(txtDiasReposo.Text);

                if (Reposo.AgregarReposo(r))
                {
                    MessageBox.Show("Se Agrego satisfactoriamente", "Mantenimiento Reposos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    cargarDataGridViewReposos(em.Codigo);
                }
                else
                {
                    MessageBox.Show("Ocurrio un error durante el Proceso. Favor, verifique los datos ingresados y vuelva a intentarlo", "Mantenimiento Reposos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar un Emplead@", "Mantenimiento Reposos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Reposo r = new Reposo();
            Empleado em = new Empleado();
            r.codigo = (int)dgvReposo.SelectedRows[0].Cells[4].Value;
            em.Codigo = (int)dgvReposo.SelectedRows[0].Cells[0].Value;
            r.Empleado = em;
            r.FechaInicial = dtpFechaReposo.Value;
            r.Observacion = txtObservaciones.Text;
            r.CantDiasReposo = int.Parse(txtDiasReposo.Text);

            if (Reposo.ModificarReposo(r))
            {
                MessageBox.Show("Se Modifico satisfactoriamente", "Mantenimiento Reposos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                cargarDataGridViewReposos(em.Codigo);
            }
            else
            {
                MessageBox.Show("Ocurrio un error durante el Proceso. Favor, verifique los datos ingresados y vuelva a intentarlo", "Mantenimiento Reposos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReposo.SelectedRows.Count > 0)
            {
                Reposo r = new Reposo();
                Empleado em = new Empleado();
                r.codigo = (int)dgvReposo.SelectedRows[0].Cells[4].Value;
                em.Codigo = (int)dgvReposo.SelectedRows[0].Cells[0].Value;
                if (Reposo.EliminarReposo(r))
                {
                    MessageBox.Show("Se elimino satisfactoriamente", "Mantenimiento Reposos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    cargarDataGridViewReposos(em.Codigo);
                }
                else
                {
                    MessageBox.Show("Ocurrio un error durante el Proceso. Favor, verifique los datos ingresados y vuelva a intentarlo", "Mantenimiento Reposos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                txtNombres.Text = dgvEmpleados.SelectedRows[0].Cells[1].Value.ToString();
                txtApellidos.Text = dgvEmpleados.SelectedRows[0].Cells[2].Value.ToString();
                txtNroDocumento.Text = dgvEmpleados.SelectedRows[0].Cells[4].Value.ToString();
                cargarDataGridViewReposos(int.Parse(dgvEmpleados.SelectedRows[0].Cells[0].Value.ToString()));
            }
        }

        private void dgvReposo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReposo.SelectedRows.Count > 0)
            {
                txtNombres.Text = dgvReposo.SelectedRows[0].Cells[1].Value.ToString();
                txtApellidos.Text = dgvReposo.SelectedRows[0].Cells[2].Value.ToString();
                txtNroDocumento.Text = dgvReposo.SelectedRows[0].Cells[3].Value.ToString();
                dtpFechaReposo.Value = DateTime.Parse(dgvReposo.SelectedRows[0].Cells[5].Value.ToString());
                txtObservaciones.Text = dgvReposo.SelectedRows[0].Cells[7].Value.ToString();
                txtDiasReposo.Text = dgvReposo.SelectedRows[0].Cells[6].Value.ToString();
            }
        }

        private void frmReposo_Load(object sender, EventArgs e)
        {
            cargarDataGridView();
        }
    }
}
