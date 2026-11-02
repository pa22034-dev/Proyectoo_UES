namespace Proyectoo_UES.Formularios
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Button btnInscripciones;
        private Button btnCupos;
        private Button btnSalir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            btnInscripciones = new Button();
            btnCupos = new Button();
            btnSalir = new Button();
            panelBotones = new TableLayoutPanel();
            btnActividades = new Button();
            panelBotones.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(25, 75, 125);
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(650, 105);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "UNIVERSIDAD DE EL SALVADOR";
            lblTitulo.TextAlign = ContentAlignment.BottomCenter;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.Dock = DockStyle.Top;
            lblSubtitulo.Font = new Font("Segoe UI", 13F);
            lblSubtitulo.Location = new Point(0, 105);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(650, 37);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Sistema de Gestión de Actividades Extracurriculares";
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnInscripciones
            // 
            btnInscripciones.Anchor = AnchorStyles.None;
            btnInscripciones.Location = new Point(160, 117);
            btnInscripciones.Name = "btnInscripciones";
            btnInscripciones.Size = new Size(330, 48);
            btnInscripciones.TabIndex = 1;
            btnInscripciones.Text = "Gestionar inscripciones";
            btnInscripciones.Click += btnInscripciones_Click;
            // 
            // btnCupos
            // 
            btnCupos.Anchor = AnchorStyles.None;
            btnCupos.Location = new Point(160, 201);
            btnCupos.Name = "btnCupos";
            btnCupos.Size = new Size(330, 48);
            btnCupos.TabIndex = 2;
            btnCupos.Text = "Consultar cupos y lista de espera";
            btnCupos.Click += btnCupos_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.None;
            btnSalir.Location = new Point(160, 289);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(330, 42);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.Click += btnSalir_Click;
            // 
            // panelBotones
            // 
            panelBotones.ColumnCount = 1;
            panelBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            panelBotones.Controls.Add(btnActividades, 0, 0);
            panelBotones.Controls.Add(btnInscripciones, 0, 1);
            panelBotones.Controls.Add(btnCupos, 0, 2);
            panelBotones.Controls.Add(btnSalir, 0, 3);
            panelBotones.Dock = DockStyle.Fill;
            panelBotones.Location = new Point(0, 142);
            panelBotones.Name = "panelBotones";
            panelBotones.Padding = new Padding(20, 15, 20, 15);
            panelBotones.RowCount = 4;
            panelBotones.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            panelBotones.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            panelBotones.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            panelBotones.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            panelBotones.Size = new Size(650, 368);
            panelBotones.TabIndex = 0;
            // 
            // btnActividades
            // 
            btnActividades.Anchor = AnchorStyles.None;
            btnActividades.Location = new Point(160, 33);
            btnActividades.Name = "btnActividades";
            btnActividades.Size = new Size(330, 48);
            btnActividades.TabIndex = 0;
            btnActividades.Text = "Gestionar actividades";
            btnActividades.Click += btnActividades_Click;
            // 
            // FrmPricipal
            // 
            ClientSize = new Size(650, 510);
            Controls.Add(panelBotones);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(600, 480);
            Name = "FrmPricipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UES - Sistema de Gestión";
            panelBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        private TableLayoutPanel panelBotones;
        private Button btnActividades;
    }
}
