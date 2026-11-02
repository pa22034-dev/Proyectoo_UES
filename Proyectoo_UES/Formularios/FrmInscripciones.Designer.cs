namespace Proyectoo_UES.Formularios
{
    partial class FrmInscripciones
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo, lblActividad, lblCarnet, lblNombre;
        private ComboBox cboActividad;
        private TextBox txtCarnet, txtNombre;
        private DataGridView dgvInscritos, dgvEspera;
        private Button btnInscribir, btnCancelar, btnActualizar, btnVolver;
        private GroupBox grpInscritos, grpEspera;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitulo = new Label(); this.lblActividad = new Label();
            this.lblCarnet = new Label(); this.lblNombre = new Label();
            this.cboActividad = new ComboBox(); this.txtCarnet = new TextBox(); this.txtNombre = new TextBox();
            this.dgvInscritos = new DataGridView(); this.dgvEspera = new DataGridView();
            this.btnInscribir = new Button(); this.btnCancelar = new Button();
            this.btnActualizar = new Button(); this.btnVolver = new Button();
            this.grpInscritos = new GroupBox(); this.grpEspera = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscritos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspera)).BeginInit();
            this.SuspendLayout();

            this.lblTitulo.Text = "GESTIÓN DE INSCRIPCIONES";
            this.lblTitulo.Dock = DockStyle.Top; this.lblTitulo.Height = 45;
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(25, 75, 125);

            this.lblActividad.Text = "Actividad:"; this.lblCarnet.Text = "Carné:";
            this.lblNombre.Text = "Nombre completo:";
            foreach (Label l in new[] { lblActividad, lblCarnet, lblNombre })
            { l.TextAlign = ContentAlignment.MiddleRight; l.Dock = DockStyle.Fill; }

            this.cboActividad.DropDownStyle = ComboBoxStyle.DropDownList; this.cboActividad.Dock = DockStyle.Fill;
            this.cboActividad.SelectedIndexChanged += new EventHandler(cboActividad_SelectedIndexChanged);
            this.txtCarnet.Dock = DockStyle.Fill; this.txtNombre.Dock = DockStyle.Fill;

            TableLayoutPanel datos = new TableLayoutPanel();
            datos.Dock = DockStyle.Top; datos.Height = 125; datos.Padding = new Padding(12);
            datos.ColumnCount = 2; datos.RowCount = 3;
            datos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            datos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            for (int i = 0; i < 3; i++) datos.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3F));
            datos.Controls.Add(lblActividad, 0, 0); datos.Controls.Add(cboActividad, 1, 0);
            datos.Controls.Add(lblCarnet, 0, 1); datos.Controls.Add(txtCarnet, 1, 1);
            datos.Controls.Add(lblNombre, 0, 2); datos.Controls.Add(txtNombre, 1, 2);

            ConfigurarTabla(dgvInscritos);
            dgvInscritos.Columns.Add("Carnet", "Carné"); dgvInscritos.Columns.Add("Nombre", "Estudiante inscrito");
            ConfigurarTabla(dgvEspera);
            dgvEspera.Columns.Add("Carnet", "Carné"); dgvEspera.Columns.Add("Nombre", "Estudiante en espera");
            dgvEspera.Columns.Add("Fecha", "Fecha de solicitud");

            this.grpInscritos.Text = "Inscripciones confirmadas"; this.grpInscritos.Dock = DockStyle.Fill;
            this.grpEspera.Text = "Cola de espera"; this.grpEspera.Dock = DockStyle.Fill;
            this.grpInscritos.Controls.Add(dgvInscritos); this.grpEspera.Controls.Add(dgvEspera);

            TableLayoutPanel tablas = new TableLayoutPanel();
            tablas.Dock = DockStyle.Fill; tablas.ColumnCount = 1; tablas.RowCount = 2;
            tablas.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablas.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablas.Controls.Add(grpInscritos, 0, 0); tablas.Controls.Add(grpEspera, 0, 1);

            this.btnInscribir.Text = "Inscribir"; this.btnInscribir.Click += new EventHandler(btnInscribir_Click);
            this.btnCancelar.Text = "Cancelar por carné"; this.btnCancelar.Click += new EventHandler(btnCancelar_Click);
            this.btnActualizar.Text = "Actualizar"; this.btnActualizar.Click += new EventHandler(btnActualizar_Click);
            this.btnVolver.Text = "Volver"; this.btnVolver.Click += new EventHandler(btnVolver_Click);
            FlowLayoutPanel botones = new FlowLayoutPanel();
            botones.Dock = DockStyle.Bottom; botones.Height = 48; botones.Padding = new Padding(8);
            botones.Controls.AddRange(new Control[] { btnInscribir, btnCancelar, btnActualizar, btnVolver });

            this.Controls.Add(tablas); this.Controls.Add(botones); this.Controls.Add(datos); this.Controls.Add(lblTitulo);
            this.Name = "FrmInscripciones"; this.Text = "UES - Gestión de inscripciones";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(900, 700); this.MinimumSize = new Size(750, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscritos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspera)).EndInit();
            this.ResumeLayout(false);
        }

        private void ConfigurarTabla(DataGridView tabla)
        {
            tabla.Dock = DockStyle.Fill; tabla.ReadOnly = true;
            tabla.AllowUserToAddRows = false; tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}