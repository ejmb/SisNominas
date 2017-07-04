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
    public partial class frmMarcacion : Form
    {
        public frmMarcacion()
        {
            InitializeComponent();
        }

        private void frmMarcacion_Load(object sender, EventArgs e)
        {
            cargarDataGridView();
        }

        public void cargarDataGridView()
        {
            dgvEmpleados.DataSource = null;
            dgvEmpleados.DataSource = Empleado.ObtenerTablaEmpleados();
        }

        public void cargarDataGridViewMarcaciones(int idEmpleado)
        {
            dgvMarcacion.DataSource = null;
            dgvMarcacion.DataSource = Marcacion.ObtenerTablaMarcacionPorEmpleado(idEmpleado);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                Marcacion m = new Marcacion();
                Empleado em = new Empleado();
                em.Codigo = (int)dgvEmpleados.SelectedRows[0].Cells[0].Value;
                
                m.Empleado = em;
                m.MarcacionEmpleado = dtpFechaHoraMarcacion.Value;

                if (Marcacion.RegistrarMarcacion(m))
                {
                    MessageBox.Show("Se Agrego satisfactoriamente", "Mantenimiento Marcaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    cargarDataGridViewMarcaciones(em.Codigo);
                }
                else
                {
                    MessageBox.Show("Ocurrio un error durante el Proceso. Favor, verifique los datos ingresados y vuelva a intentarlo", "Mantenimiento Marcaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar un Emplead@", "Mantenimiento Marcaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Limpiar()
        {
            txtNombres.Text = String.Empty;
            txtApellidos.Text = String.Empty;
            txtNroDocumento.Text = String.Empty;
            dtpFechaHoraMarcacion.Value = DateTime.Now;
            txtNombres.Focus();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Marcacion m = new Marcacion();
            Empleado em = new Empleado();
            m.Codigo = (long)dgvMarcacion.SelectedRows[0].Cells[4].Value;
            em.Codigo = (int)dgvMarcacion.SelectedRows[0].Cells[0].Value;
            m.Empleado = em;
            m.MarcacionEmpleado = dtpFechaHoraMarcacion.Value;
            
            if (Marcacion.ModificarMarcacion(m))
            {
                MessageBox.Show("Se Modifico satisfactoriamente", "Mantenimiento Marcaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                cargarDataGridViewMarcaciones(em.Codigo);
            }
            else
            {
                MessageBox.Show("Ocurrio un error durante el Proceso. Favor, verifique los datos ingresados y vuelva a intentarlo", "Mantenimiento Marcaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMarcacion.SelectedRows.Count > 0)
            {
                Marcacion m = new Marcacion();
                Empleado em = new Empleado();
                m.Codigo = (long)dgvMarcacion.SelectedRows[0].Cells[4].Value;
                em.Codigo = (int)dgvMarcacion.SelectedRows[0].Cells[0].Value;
                if (Marcacion.EliminarMarcacion(m))
                {
                    MessageBox.Show("Se elimino satisfactoriamente", "Mantenimiento Marcaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    cargarDataGridViewMarcaciones(em.Codigo);
                }
                else
                {
                    MessageBox.Show("Ocurrio un error durante el Proceso. Favor, verifique los datos ingresados y vuelva a intentarlo", "Mantenimiento Marcaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvMarcacion_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMarcacion.SelectedRows.Count > 0)
            {
                txtNombres.Text = dgvMarcacion.SelectedRows[0].Cells[1].Value.ToString();
                txtApellidos.Text = dgvMarcacion.SelectedRows[0].Cells[2].Value.ToString();
                txtNroDocumento.Text = dgvMarcacion.SelectedRows[0].Cells[3].Value.ToString();
                dtpFechaHoraMarcacion.Value = DateTime.Parse(dgvMarcacion.SelectedRows[0].Cells[5].Value.ToString());
            }
        }

        private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                txtNombres.Text = dgvEmpleados.SelectedRows[0].Cells[1].Value.ToString();
                txtApellidos.Text = dgvEmpleados.SelectedRows[0].Cells[2].Value.ToString();
                txtNroDocumento.Text = dgvEmpleados.SelectedRows[0].Cells[4].Value.ToString();
                cargarDataGridViewMarcaciones(int.Parse(dgvEmpleados.SelectedRows[0].Cells[0].Value.ToString()));
            }
        }
    }
}
