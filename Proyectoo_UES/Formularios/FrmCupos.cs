using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Proyectoo_UES.Modelos;
using Proyectoo_UES.Servicios;


namespace Proyectoo_UES.Formularios
{
    // Declara la clase parcial FrmCupos que hereda de Form para visualizar el estado de cupos por actividad.
    public partial class FrmCupos : Form
    {
        // Referencia privada y de solo lectura al gestor que administra las actividades del sistema.
        private readonly GestorActividades gestor;

        // Constructor del formulario que recibe la instancia compartida de GestorActividades.
        public FrmCupos(GestorActividades gestor)
        {
            // Asigna el gestor recibido al campo privado de la clase.
            this.gestor = gestor;
            // Inicializa todos los controles visuales diseñados en el formulario (botones, DataGridView, etc.).
            InitializeComponent();
            // Carga inicialmente los datos de cupos de todas las actividades en la tabla.
            ActualizarTabla();
        }

        // Evento que se ejecuta al hacer clic en el botón "Actualizar".
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Vuelve a consultar las actividades y refresca las filas de la tabla de cupos.
            ActualizarTabla();
        }

        // Evento que se ejecuta al hacer clic en el botón "Volver".
        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual y regresa a la ventana anterior.
            Close();
        }

        // Método privado que limpia y rellena el DataGridView con el resumen de cupos de cada actividad.
        private void ActualizarTabla()
        {
            // Elimina todas las filas actuales de la tabla para evitar datos duplicados.
            dgvCupos.Rows.Clear();

            // Recorre el arreglo de actividades obtenido desde el gestor.
            foreach (Actividad a in gestor.ObtenerActividades())
            {
                // Agrega una fila con ID, nombre, fecha formateada, capacidad, inscritos, disponibles y en espera.
                dgvCupos.Rows.Add(a.Id, a.Nombre, a.Fecha.ToString("dd/MM/yyyy"),
                    a.Capacidad, a.Inscritos, a.CuposDisponibles, a.EnEspera);
            }
        }

        // Evento que se ejecuta al hacer clic en el botón "Actividades".
        private void btnActividades_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario FrmActividades dentro de un bloque using para liberar recursos al cerrarse.
            using (FrmActividades ventana = new FrmActividades(gestor))
            {
                // Abre la ventana de gestión de actividades de forma modal sobre el formulario actual.
                ventana.ShowDialog(this);
            }
        }

        // Evento que se ejecuta al hacer clic en el botón "Salir".
        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual.
            Close();
        }

       
        private void dgvCupos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}