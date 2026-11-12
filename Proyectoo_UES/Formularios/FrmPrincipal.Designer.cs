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
            pictureBox1 = new PictureBox();
            panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(650, 227);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "UNIVERSIDAD DE EL SALVADOR";
            lblTitulo.TextAlign = ContentAlignment.BottomCenter;
            lblTitulo.Click += lblTitulo_Click;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.Dock = DockStyle.Top;
            lblSubtitulo.Font = new Font("Segoe UI", 13F);
            lblSubtitulo.ForeColor = SystemColors.ButtonHighlight;
            lblSubtitulo.Location = new Point(0, 227);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(650, 37);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Sistema de Gestión de Actividades Extracurriculares";
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnInscripciones
            // 
            btnInscripciones.Anchor = AnchorStyles.None;
            btnInscripciones.ForeColor = SystemColors.ButtonHighlight;
            btnInscripciones.Location = new Point(160, 114);
            btnInscripciones.Name = "btnInscripciones";
            btnInscripciones.Size = new Size(330, 48);
            btnInscripciones.TabIndex = 1;
            btnInscripciones.Text = "Gestionar inscripciones";
            btnInscripciones.Click += btnInscripciones_Click;
            // 
            // btnCupos
            // 
            btnCupos.Anchor = AnchorStyles.None;
            btnCupos.ForeColor = SystemColors.ButtonFace;
            btnCupos.Location = new Point(160, 196);
            btnCupos.Name = "btnCupos";
            btnCupos.Size = new Size(330, 48);
            btnCupos.TabIndex = 2;
            btnCupos.Text = "Consultar cupos y lista de espera";
            btnCupos.Click += btnCupos_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.None;
            btnSalir.ForeColor = SystemColors.ButtonHighlight;
            btnSalir.Location = new Point(160, 281);
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
            panelBotones.Location = new Point(0, 264);
            panelBotones.Name = "panelBotones";
            panelBotones.Padding = new Padding(20, 15, 20, 15);
            panelBotones.RowCount = 4;
            panelBotones.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            panelBotones.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            panelBotones.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            panelBotones.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            panelBotones.Size = new Size(650, 358);
            panelBotones.TabIndex = 0;
            // 
            // btnActividades
            // 
            btnActividades.Anchor = AnchorStyles.None;
            btnActividades.ForeColor = SystemColors.ControlLightLight;
            btnActividades.Location = new Point(160, 32);
            btnActividades.Name = "btnActividades";
            btnActividades.Size = new Size(330, 48);
            btnActividades.TabIndex = 0;
            btnActividades.Text = "Gestionar actividades";
            btnActividades.Click += btnActividades_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_ues_blanco_1_838x1024;
            pictureBox1.Location = new Point(270, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(134, 167);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // FrmPrincipal
            // 
            BackColor = Color.Maroon;
            BackgroundImage = Properties.Resources.logo_ues_blanco_1_838x1024;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(650, 622);
            Controls.Add(pictureBox1);
            Controls.Add(panelBotones);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(600, 480);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UES - Sistema de Gestión";
            panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        private TableLayoutPanel panelBotones;
        private Button btnActividades;
        private PictureBox pictureBox1;
    }
}
