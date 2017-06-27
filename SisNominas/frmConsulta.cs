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
using MetroFramework.Forms;

namespace SisNominas
{
    public partial class frmConsulta : MetroForm
    {
        public List<Cargo> listaCargos { get; set; }

        public frmConsulta()
        {
            InitializeComponent();
        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            dgvListado.DataSource = null;
            dgvListado.DataSource = this.listaCargos;
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmCargo frm = new frmCargo();
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dgvListado.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                frm.txtDescripcion.Text = row.Cells[1].Value.ToString();                
            }     
            frm.Show();
            Hide();
        }
    }
}
