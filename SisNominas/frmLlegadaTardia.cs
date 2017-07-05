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
    public partial class frmLlegadaTardia : Form
    {
        public frmLlegadaTardia()
        {
            InitializeComponent();
        }

        public void cargarDataGridView()
        {
            dgvEmpleados.DataSource = null;
            dgvEmpleados.DataSource = Empleado.ObtenerTablaEmpleados();
        }

        private void frmLlegadaTardia_Load(object sender, EventArgs e)
        {
            cargarDataGridView();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                LlegadaTardia.GenerarPDF((int) dgvEmpleados.SelectedRows[0].Cells[0].Value);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Emplead@", "Llegadas Tardias", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
