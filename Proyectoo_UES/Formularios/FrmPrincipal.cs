using System;
using System.Windows.Forms;
using Proyectoo_UES.Servicios;


namespace Proyectoo_UES.Formularios
{
    // Declara la clase parcial FrmPrincipal que hereda de Form y funciona como menú principal del sistema.
    public partial class FrmPrincipal : Form
    {
        // Referencia privada y de solo lectura al gestor único que administra los datos durante toda la ejecución.
        private readonly GestorActividades gestor;

        // Constructor del formulario principal que recibe la instancia compartida de GestorActividades.
        public FrmPrincipal(GestorActividades gestor)
        {
            // Asigna el gestor recibido al campo privado de la clase.
            this.gestor = gestor;
            // Inicializa los componentes visuales diseñados en el formulario (botones, etiquetas, PictureBox).
            InitializeComponent();

            // Llama al método auxiliar para centrar el logotipo al abrir la ventana por primera vez.
            centrarlogo();

            // Suscribe el evento Resize del formulario a un método tradicional para recentrar el logo al redimensionar.
            this.Resize += FrmPrincipal_Resize;
        }

        // Método manejador del evento Resize que se ejecuta cada vez que cambia el tamaño de la ventana.
        private void FrmPrincipal_Resize(object sender, EventArgs e)
        {
            // Llama al método que recalcula y centra la posición horizontal del logotipo.
            centrarlogo();
        }

        // Método privado encargado de centrar el control PictureBox horizontalmente dentro del formulario.
        private void centrarlogo()
        {
            // Calcula la coordenada izquierda restando el ancho del PictureBox al ancho interno de la ventana y dividiendo entre 2.
            pictureBox1.Left =
                (this.ClientSize.Width - pictureBox1.Width) / 2;

            // Configura el modo de ajuste de la imagen para que se escale proporcionalmente sin deformarse.
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        // Evento que se ejecuta al hacer clic en el botón "Actividades".
        private void btnActividades_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario FrmActividades dentro de un bloque using para liberar recursos al cerrarse.
            using (FrmActividades ventana = new FrmActividades(gestor))
            {
                // Muestra el formulario de actividades como ventana modal bloqueando la principal hasta cerrarse.
                ventana.ShowDialog(this);
            }
        }

        // Evento que se ejecuta al hacer clic en el botón "Inscripciones".
        private void btnInscripciones_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario FrmInscripciones pasando el mismo gestor compartido.
            using (FrmInscripciones ventana = new FrmInscripciones(gestor))
            {
                // Abre la ventana de inscripciones de forma modal sobre el formulario principal.
                ventana.ShowDialog(this);
            }
        }

        // Evento que se ejecuta al hacer clic en el botón "Cupos" (consulta de disponibilidad).
        private void btnCupos_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario FrmCupos dentro de un bloque using para gestión automática de memoria.
            using (FrmCupos ventana = new FrmCupos(gestor))
            {
                // Abre la ventana de consulta de cupos de forma modal sobre el formulario principal.
                ventana.ShowDialog(this);
            }
        }

        // Evento que se ejecuta al hacer clic en el botón "Salir".
        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cierra el formulario principal, finalizando la aplicación.
            Close();
        }

        // Evento generado por el diseñador al hacer clic sobre la etiqueta del título (sin acción asignada).
        private void lblTitulo_Click(object sender, EventArgs e)
        {
            // Bloque vacío: no se requiere realizar ninguna acción al presionar el título.
        }

        // Evento generado por el diseñador al hacer clic sobre la imagen del logotipo (sin acción asignada).
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Bloque vacío: no se requiere realizar ninguna acción al presionar el logotipo.
        }
    }
}
