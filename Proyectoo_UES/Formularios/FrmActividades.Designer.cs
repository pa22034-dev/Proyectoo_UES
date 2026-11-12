
using System; // Permite utilizar clases y eventos.
using System.Drawing; // Permite trabajar con colores, fuentes y tamaños.
using System.Windows.Forms; // Permite utilizar controles de Windows Forms.

namespace Proyectoo_UES // Espacio de nombres del proyecto.
{
    partial class FrmActividades // Clase parcial del formulario de actividades.
    {
        // Contenedor que almacena los componentes del formulario.
        private System.ComponentModel.IContainer components = null;

        // Etiquetas que muestran los nombres de los campos.
        private Label lblTitulo, lblNombre, lblDescripcion, lblFecha, lblLugar, lblCapacidad;

        // Campos donde el usuario escribe la información.
        private TextBox txtNombre, txtDescripcion, txtLugar;

        // Control para seleccionar una fecha.
        private DateTimePicker dtpFecha;

        // Control para seleccionar la capacidad máxima.
        private NumericUpDown nudCapacidad;

        // Tabla donde se muestran las actividades registradas.
        private DataGridView dgvActividades;

        // Botones para realizar las operaciones del formulario.
        private Button btnRegistrar, btnEliminar, btnLimpiar, btnActualizar, btnVolver;

        // Método que libera los recursos utilizados por el formulario.
        protected override void Dispose(bool disposing)
        {
            // Comprueba si se deben liberar los componentes.
            if (disposing && components != null)
                components.Dispose();

            // Llama al método de liberación de la clase principal.
            base.Dispose(disposing);
        }

        // Método que inicializa y configura los controles del formulario.
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblNombre = new Label();
            lblDescripcion = new Label();
            lblFecha = new Label();
            lblLugar = new Label();
            lblCapacidad = new Label();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtLugar = new TextBox();
            dtpFecha = new DateTimePicker();
            nudCapacidad = new NumericUpDown();
            dgvActividades = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            btnRegistrar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            btnActualizar = new Button();
            btnVolver = new Button();
            formulario = new TableLayoutPanel();
            botones = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)nudCapacidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvActividades).BeginInit();
            formulario.SuspendLayout();
            botones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1050, 159);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "REGISTRO DE ACTIVIDADES";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNombre
            // 
            lblNombre.Dock = DockStyle.Fill;
            lblNombre.ForeColor = SystemColors.Control;
            lblNombre.Location = new Point(15, 12);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(129, 33);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            lblNombre.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDescripcion
            // 
            lblDescripcion.Dock = DockStyle.Fill;
            lblDescripcion.ForeColor = SystemColors.Control;
            lblDescripcion.Location = new Point(15, 45);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(129, 33);
            lblDescripcion.TabIndex = 2;
            lblDescripcion.Text = "Descripción:";
            lblDescripcion.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblFecha
            // 
            lblFecha.Dock = DockStyle.Fill;
            lblFecha.ForeColor = SystemColors.Control;
            lblFecha.Location = new Point(15, 78);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(129, 33);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Fecha:";
            lblFecha.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblLugar
            // 
            lblLugar.Dock = DockStyle.Fill;
            lblLugar.ForeColor = SystemColors.Control;
            lblLugar.Location = new Point(15, 111);
            lblLugar.Name = "lblLugar";
            lblLugar.Size = new Size(129, 33);
            lblLugar.TabIndex = 6;
            lblLugar.Text = "Lugar:";
            lblLugar.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCapacidad
            // 
            lblCapacidad.Dock = DockStyle.Fill;
            lblCapacidad.ForeColor = SystemColors.Control;
            lblCapacidad.Location = new Point(15, 144);
            lblCapacidad.Name = "lblCapacidad";
            lblCapacidad.Size = new Size(129, 34);
            lblCapacidad.TabIndex = 8;
            lblCapacidad.Text = "Cupo máximo:";
            lblCapacidad.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtNombre
            // 
            txtNombre.Dock = DockStyle.Fill;
            txtNombre.Location = new Point(150, 15);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(885, 27);
            txtNombre.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Dock = DockStyle.Fill;
            txtDescripcion.Location = new Point(150, 48);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(885, 27);
            txtDescripcion.TabIndex = 3;
            // 
            // txtLugar
            // 
            txtLugar.Dock = DockStyle.Fill;
            txtLugar.Location = new Point(150, 114);
            txtLugar.Name = "txtLugar";
            txtLugar.Size = new Size(885, 27);
            txtLugar.TabIndex = 7;
            // 
            // dtpFecha
            // 
            dtpFecha.Dock = DockStyle.Fill;
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(150, 81);
            dtpFecha.MinDate = new DateTime(2026, 11, 2, 0, 0, 0, 0);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(885, 27);
            dtpFecha.TabIndex = 5;
            // 
            // nudCapacidad
            // 
            nudCapacidad.Dock = DockStyle.Left;
            nudCapacidad.Location = new Point(150, 147);
            nudCapacidad.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudCapacidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCapacidad.Name = "nudCapacidad";
            nudCapacidad.Size = new Size(120, 27);
            nudCapacidad.TabIndex = 9;
            nudCapacidad.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // dgvActividades
            // 
            dgvActividades.AllowUserToAddRows = false;
            dgvActividades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvActividades.BackgroundColor = Color.Tan;
            dgvActividades.ColumnHeadersHeight = 29;
            dgvActividades.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8 });
            dgvActividades.Dock = DockStyle.Fill;
            dgvActividades.Location = new Point(0, 349);
            dgvActividades.Name = "dgvActividades";
            dgvActividades.ReadOnly = true;
            dgvActividades.RowHeadersWidth = 51;
            dgvActividades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvActividades.Size = new Size(1050, 248);
            dgvActividades.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "ID";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Actividad";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Fecha";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Lugar";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Capacidad";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Inscritos";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Disponibles";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "En espera";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.White;
            btnRegistrar.ForeColor = SystemColors.ActiveCaptionText;
            btnRegistrar.Location = new Point(11, 11);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(95, 37);
            btnRegistrar.TabIndex = 0;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.White;
            btnEliminar.ForeColor = SystemColors.ActiveCaptionText;
            btnEliminar.Location = new Point(112, 11);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(95, 37);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "Eliminar seleccionada";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.White;
            btnLimpiar.ForeColor = SystemColors.ActiveCaptionText;
            btnLimpiar.Location = new Point(213, 11);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(96, 37);
            btnLimpiar.TabIndex = 2;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.White;
            btnActualizar.ForeColor = SystemColors.ActiveCaptionText;
            btnActualizar.Location = new Point(315, 11);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(99, 37);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.White;
            btnVolver.ForeColor = SystemColors.ActiveCaptionText;
            btnVolver.Location = new Point(420, 11);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(105, 37);
            btnVolver.TabIndex = 4;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // formulario
            // 
            formulario.ColumnCount = 2;
            formulario.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 135F));
            formulario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            formulario.Controls.Add(lblNombre, 0, 0);
            formulario.Controls.Add(txtNombre, 1, 0);
            formulario.Controls.Add(lblDescripcion, 0, 1);
            formulario.Controls.Add(txtDescripcion, 1, 1);
            formulario.Controls.Add(lblFecha, 0, 2);
            formulario.Controls.Add(dtpFecha, 1, 2);
            formulario.Controls.Add(lblLugar, 0, 3);
            formulario.Controls.Add(txtLugar, 1, 3);
            formulario.Controls.Add(lblCapacidad, 0, 4);
            formulario.Controls.Add(nudCapacidad, 1, 4);
            formulario.Dock = DockStyle.Top;
            formulario.Location = new Point(0, 159);
            formulario.Name = "formulario";
            formulario.Padding = new Padding(12);
            formulario.RowCount = 5;
            formulario.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            formulario.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            formulario.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            formulario.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            formulario.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            formulario.Size = new Size(1050, 190);
            formulario.TabIndex = 2;
            // 
            // botones
            // 
            botones.Controls.Add(btnRegistrar);
            botones.Controls.Add(btnEliminar);
            botones.Controls.Add(btnLimpiar);
            botones.Controls.Add(btnActualizar);
            botones.Controls.Add(btnVolver);
            botones.Dock = DockStyle.Bottom;
            botones.Location = new Point(0, 597);
            botones.Name = "botones";
            botones.Padding = new Padding(8);
            botones.Size = new Size(1050, 48);
            botones.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_ues_blanco_1_838x1024;
            pictureBox1.Location = new Point(112, 34);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // FrmActividades
            // 
            BackColor = Color.Brown;
            ClientSize = new Size(1050, 645);
            Controls.Add(pictureBox1);
            Controls.Add(dgvActividades);
            Controls.Add(botones);
            Controls.Add(formulario);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(850, 550);
            Name = "FrmActividades";
            StartPosition = FormStartPosition.CenterParent;
            Text = "UES - Gestión de actividades";
            ((System.ComponentModel.ISupportInitialize)nudCapacidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvActividades).EndInit();
            formulario.ResumeLayout(false);
            formulario.PerformLayout();
            botones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private TableLayoutPanel formulario;
        private FlowLayoutPanel botones;
        private PictureBox pictureBox1;
    }
}
