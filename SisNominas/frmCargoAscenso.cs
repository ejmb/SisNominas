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
    public partial class frmCargoAscenso : Form
    {
        public frmCargoAscenso()
        {
            InitializeComponent();
        }

        private void frmCargoAscenso_Load(object sender, EventArgs e)
        {
            cboCargoEntrante.DataSource = null;
            cboCargoSaliente.BindingContext = new BindingContext();
            cboCargoSaliente.DataSource = null;
            cboCargoEntrante.DataSource = Cargo.ObtenerListaCargos();
            cboCargoEntrante.SelectedIndex = -1;
            cboCargoSaliente.DataSource = Cargo.ObtenerListaCargos();
            cboCargoSaliente.SelectedIndex = -1;
            cargarDataGridView();
        }

        private void cargarDataGridView()
        {
            dgvEmpleados.DataSource = null;
            dgvEmpleados.DataSource = Empleado.ObtenerTablaEmpleados();

            dgvHistorico.DataSource = null;
            dgvHistorico.DataSource = CargoAscenso.ObtenerTablaCargoAscenso();
        }

        private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                txtNombres.Text = dgvEmpleados.SelectedRows[0].Cells[1].Value.ToString();
                txtApellidos.Text = dgvEmpleados.SelectedRows[0].Cells[2].Value.ToString();
                txtNroDocumento.Text = dgvEmpleados.SelectedRows[0].Cells[4].Value.ToString();
                cboCargoSaliente.SelectedIndex = cboCargoSaliente.FindStringExact(dgvEmpleados.SelectedRows[0].Cells[14].Value.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                CargoAscenso ca = new CargoAscenso();
                Empleado em = new Empleado();
                Cargo c = new Cargo();
                em.Codigo = (int)dgvEmpleados.SelectedRows[0].Cells[0].Value;
                c.Codigo = (int)dgvEmpleados.SelectedRows[0].Cells[13].Value;

                ca.FechaCambio = dtpFechaCambio.Value;
                ca.Empleado = em;
                ca.CargoSaliente = c;
                ca.CargoEntrante = (Cargo)cboCargoEntrante.SelectedItem;
                ca.SalarioEntrante = int.Parse(txtSalarioEntrante.Text);

                if (CargoAscenso.RegistrarCargoAscenso(ca))
                {
                    MessageBox.Show("Se Agrego satisfactoriamente", "Mantenimiento Cargo/Ascensos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    cargarDataGridView();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error durante el Proceso. Favor, verifique los datos ingresados y vuelva a intentarlo", "Mantenimiento Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar un Emplead@", "Mantenimiento Cargo/Ascensos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Limpiar()
        {
            txtNombres.Text = String.Empty;
            txtApellidos.Text = String.Empty;
            txtNroDocumento.Text = String.Empty;
            dtpFechaCambio.Value = DateTime.Now;
            txtSalarioEntrante.Text = String.Empty;
            cboCargoEntrante.SelectedIndex = -1;
            cboCargoSaliente.SelectedIndex = -1;
            txtNombres.Focus();
        }
    }
}
