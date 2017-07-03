using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;

namespace SisNominas
{
    public partial class frmParametros : Form
    {
        public frmParametros()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Parametros p = new Parametros();
            p.HorarioEntrada = dtpHorarioEntrada.Value;
            p.HorarioSalida = dtpHorarioSalida.Value;
            p.MinutosTolerancia = int.Parse(nudMinutos.Text);
            p.CantMaxDiasVacaciones = int.Parse(nudVacaciones.Text);

            if (Parametros.AgregarParametros(p))
            {
                MessageBox.Show("Se agrego satisfactoriamente", "Mantenimiento Parametros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                cargarDataGridView();
            }
            else
            {
                MessageBox.Show("Ocurrio un error durante el Proceso. Favor, verifique los datos ingresados y vuelva a intentarlo", "Mantenimiento Parametros", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            dtpHorarioEntrada.Value = DateTime.Now;
            dtpHorarioSalida.Value = DateTime.Now;
            nudMinutos.Value = 0;
            nudVacaciones.Value = 0;
            dtpHorarioEntrada.Focus();
        }

        private void frmParametros_Load(object sender, EventArgs e)
        {
            cargarDataGridView();
        }

        private void cargarDataGridView()
        {
            dgvParametros.DataSource = null;
            dgvParametros.DataSource = Parametros.ObtenerTablaParametros();
        }

        private void dgvParametros_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvParametros.SelectedRows.Count > 0)
            {
                dtpHorarioEntrada.Value = DateTime.Parse(dgvParametros.SelectedRows[0].Cells[1].Value.ToString());
                dtpHorarioSalida.Value = DateTime.Parse(dgvParametros.SelectedRows[0].Cells[2].Value.ToString());
                nudMinutos.Text = dgvParametros.SelectedRows[0].Cells[3].Value.ToString();
                nudVacaciones.Text = dgvParametros.SelectedRows[0].Cells[4].Value.ToString();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Parametros p = new Parametros();
            p.Codigo = (int)dgvParametros.SelectedRows[0].Cells[0].Value;
            p.HorarioEntrada = dtpHorarioEntrada.Value;
            p.HorarioSalida = dtpHorarioSalida.Value;
            p.MinutosTolerancia = int.Parse(nudMinutos.Text);
            p.CantMaxDiasVacaciones = int.Parse(nudVacaciones.Text);

            if (Parametros.ModificarParametros(p))
            {
                MessageBox.Show("Se Modifico satisfactoriamente", "Mantenimiento Parametros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                cargarDataGridView();
            }
            else
            {
                MessageBox.Show("Ocurrio un error durante el Proceso. Favor, verifique los datos ingresados y vuelva a intentarlo", "Mantenimiento Parametros", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvParametros.SelectedRows.Count > 0)
            {
                Parametros p = new Parametros();
                p.Codigo = (int)dgvParametros.SelectedRows[0].Cells[0].Value;
                if (Parametros.EliminarParametros(p))
                {
                    MessageBox.Show("Se elimino satisfactoriamente", "Mantenimiento Parametros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    cargarDataGridView();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error durante el Proceso. Favor, verifique los datos ingresados y vuelva a intentarlo", "Mantenimiento Parametros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
