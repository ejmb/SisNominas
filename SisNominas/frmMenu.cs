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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
            StartTimer();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpleado emp = new frmEmpleado();
            emp.ShowDialog();
        }

        private void cargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCargo car = new frmCargo();
            car.ShowDialog();
        }

        private void cargosAscensoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCargoAscenso carAs = new frmCargoAscenso();
            carAs.ShowDialog();
        }

        private void parametrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmParametros param = new frmParametros();
            param.ShowDialog();
        }

        private void marcacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarcacion marca = new frmMarcacion();
            marca.ShowDialog();
        }

        private void reposoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReposo rep = new frmReposo();
            rep.ShowDialog();
        }

        private void horasExtraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHorasExtra hex = new frmHorasExtra();
            hex.ShowDialog();
        }

        private void diaLibreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiaLibre dial = new frmDiaLibre();
            dial.ShowDialog();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcerca ace = new frmAcerca();
            ace.ShowDialog();
        }

        private void liquidacionSalarialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empleado.GenerarPDF();
        }

        private void StartTimer()
        {
            Timer t = new Timer();
            t.Interval = 600;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            lblReloj.Text = DateTime.Now.ToString();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            //Empleado.GenerarVacaciones();
        }

        private void llegadasTardiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLlegadaTardia lleg = new frmLlegadaTardia();
            lleg.ShowDialog();
        }
    }
}
