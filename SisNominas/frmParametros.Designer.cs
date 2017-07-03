namespace SisNominas
{
    partial class frmParametros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParametros));
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpHorarioEntrada = new System.Windows.Forms.DateTimePicker();
            this.dtpHorarioSalida = new System.Windows.Forms.DateTimePicker();
            this.dgvParametros = new System.Windows.Forms.DataGridView();
            this.nudVacaciones = new System.Windows.Forms.NumericUpDown();
            this.nudMinutos = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParametros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVacaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(114)))), ((int)(((byte)(186)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnModificar.Location = new System.Drawing.Point(191, 235);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 5;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(13)))), ((int)(((byte)(54)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEliminar.Location = new System.Drawing.Point(272, 235);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(114)))), ((int)(((byte)(186)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAgregar.Location = new System.Drawing.Point(110, 235);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Horario Salida";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Horario Entrada";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Minutos Tolerancia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Max. de Vacaciones";
            // 
            // dtpHorarioEntrada
            // 
            this.dtpHorarioEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHorarioEntrada.Location = new System.Drawing.Point(126, 11);
            this.dtpHorarioEntrada.Name = "dtpHorarioEntrada";
            this.dtpHorarioEntrada.Size = new System.Drawing.Size(105, 20);
            this.dtpHorarioEntrada.TabIndex = 0;
            // 
            // dtpHorarioSalida
            // 
            this.dtpHorarioSalida.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHorarioSalida.Location = new System.Drawing.Point(126, 37);
            this.dtpHorarioSalida.Name = "dtpHorarioSalida";
            this.dtpHorarioSalida.Size = new System.Drawing.Size(105, 20);
            this.dtpHorarioSalida.TabIndex = 1;
            // 
            // dgvParametros
            // 
            this.dgvParametros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParametros.Location = new System.Drawing.Point(15, 66);
            this.dgvParametros.Name = "dgvParametros";
            this.dgvParametros.Size = new System.Drawing.Size(420, 150);
            this.dgvParametros.TabIndex = 10;
            this.dgvParametros.SelectionChanged += new System.EventHandler(this.dgvParametros_SelectionChanged);
            // 
            // nudVacaciones
            // 
            this.nudVacaciones.Location = new System.Drawing.Point(361, 40);
            this.nudVacaciones.Name = "nudVacaciones";
            this.nudVacaciones.Size = new System.Drawing.Size(50, 20);
            this.nudVacaciones.TabIndex = 11;
            // 
            // nudMinutos
            // 
            this.nudMinutos.Location = new System.Drawing.Point(361, 14);
            this.nudMinutos.Name = "nudMinutos";
            this.nudMinutos.Size = new System.Drawing.Size(50, 20);
            this.nudMinutos.TabIndex = 11;
            // 
            // frmParametros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 271);
            this.Controls.Add(this.nudMinutos);
            this.Controls.Add(this.nudVacaciones);
            this.Controls.Add(this.dgvParametros);
            this.Controls.Add(this.dtpHorarioSalida);
            this.Controls.Add(this.dtpHorarioEntrada);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmParametros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mantenimiento Parametros";
            this.Load += new System.EventHandler(this.frmParametros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParametros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVacaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpHorarioEntrada;
        private System.Windows.Forms.DateTimePicker dtpHorarioSalida;
        private System.Windows.Forms.DataGridView dgvParametros;
        private System.Windows.Forms.NumericUpDown nudVacaciones;
        private System.Windows.Forms.NumericUpDown nudMinutos;
    }
}