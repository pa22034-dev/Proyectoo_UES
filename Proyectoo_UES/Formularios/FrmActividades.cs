using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Proyectoo_UES.Modelos;
using Proyectoo_UES.Servicios;

// Define el espacio de nombres principal del proyecto.
namespace Proyectoo_UES
{
    // Declara la clase parcial FrmActividades que hereda de Form para gestionar el registro y eliminación de actividades.
    public partial class FrmActividades : Form
    {
        // Referencia privada y de solo lectura al gestor que administra la lógica de negocio de actividades.
        private readonly GestorActividades gestor;

        // Constructor del formulario que recibe la instancia compartida de GestorActividades.
        public FrmActividades(GestorActividades gestor)
        {
            // Asigna el gestor recibido al campo privado de la clase.
            this.gestor = gestor;
            // Inicializa los controles visuales diseñados en el formulario (campos de texto, botones, tabla).
            InitializeComponent();
            // Carga inicialmente las actividades registradas en el DataGridView al abrir la ventana.
            ActualizarTabla();
        }

        // Evento que se ejecuta al hacer clic en el botón "Registrar".
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Llama al gestor para validar y registrar la nueva actividad con los datos ingresados en los controles.
            bool correcto = gestor.RegistrarActividad(
                txtNombre.Text, txtDescripcion.Text, dtpFecha.Value.Date,
                txtLugar.Text, (int)nudCapacidad.Value, out string mensaje);

            // Muestra un cuadro de diálogo con el mensaje resultante e ícono de información o advertencia según el éxito.
            MessageBox.Show(mensaje, "Gestión de actividades",
                MessageBoxButtons.OK,
                correcto ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            // Si la actividad se registró correctamente:
            if (correcto)
            {
                // Limpia los campos del formulario dejándolos listos para un nuevo registro.
                Limpiar();
                // Refresca la tabla para mostrar la nueva actividad agregada.
                ActualizarTabla();
            }
        }

        // Evento que se ejecuta al hacer clic en el botón "Eliminar seleccionada".
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verifica si hay alguna fila actualmente seleccionada en la tabla de actividades.
            if (dgvActividades.CurrentRow == null)
            {
                // Muestra un aviso indicando que se debe seleccionar una actividad primero.
                MessageBox.Show("Selecciona una actividad de la tabla.");
                // Detiene la ejecución del evento.
                return;
            }

            // Obtiene y convierte a entero el identificador (ID) de la actividad en la fila seleccionada.
            int id = Convert.ToInt32(dgvActividades.CurrentRow.Cells["Id"].Value);

            // Muestra un cuadro de confirmación Sí/No; si el usuario no confirma con Sí, cancela la operación.
            if (MessageBox.Show("¿Deseas eliminar la actividad seleccionada?",
                "Confirmar eliminación", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
            {
                // Retorna sin eliminar la actividad.
                return;
            }

            // Solicita al gestor eliminar la actividad por su ID y recibe el mensaje de resultado.
            bool correcto = gestor.EliminarActividad(id, out string mensaje);
            // Muestra al usuario el mensaje devuelto por el gestor (confirmación o motivo de rechazo).
            MessageBox.Show(mensaje);
            // Refresca la tabla para reflejar los cambios actuales.
            ActualizarTabla();
        }

        // Evento que se ejecuta al hacer clic en el botón "Limpiar".
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Llama al método auxiliar que restablece los campos de entrada.
            Limpiar();
        }

        // Evento que se ejecuta al hacer clic en el botón "Actualizar".
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // 1. Verifica si hay una fila seleccionada en la tabla.
            if (dgvActividades.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una actividad de la tabla para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Obtiene el ID de la actividad seleccionada (usando la columna en la posición 0).
            int id = Convert.ToInt32(dgvActividades.CurrentRow.Cells[0].Value);

            // 3. Llama al gestor para actualizar la actividad con los nuevos datos de los controles.
            // (Nota: Asegúrate de que tu clase GestorActividades tenga un método que reciba estos parámetros para actualizar).
            bool correcto = gestor.ActualizarActividad(
                id, txtNombre.Text, txtDescripcion.Text, dtpFecha.Value.Date,
                txtLugar.Text, (int)nudCapacidad.Value, out string mensaje);

            // Muestra el resultado de la operación.
            MessageBox.Show(mensaje, "Gestión de actividades",
                MessageBoxButtons.OK,
                correcto ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            // Si la actualización fue exitosa:
            if (correcto)
            {
                // Limpia los campos y refresca la tabla.
                Limpiar();
                ActualizarTabla();
            }

        }

        // Evento que se ejecuta al hacer clic en el botón "Volver".
        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual y regresa a la ventana anterior.
            Close();
        }

        // Método privado que limpia y restablece a sus valores iniciales todos los controles de entrada.
        private void Limpiar()
        {
            // Borra el texto del campo Nombre.
            txtNombre.Clear();
            // Borra el texto del campo Descripción.
            txtDescripcion.Clear();
            // Borra el texto del campo Lugar.
            txtLugar.Clear();
            // Restablece el selector numérico de capacidad al valor predeterminado de 20.
            nudCapacidad.Value = 20;
            // Restablece el selector de fecha al día actual.
            dtpFecha.Value = DateTime.Today;
            // Coloca el cursor de escritura nuevamente en el cuadro de texto Nombre.
            txtNombre.Focus();
        }

        // Método privado que vacía y vuelve a llenar el DataGridView con todas las actividades registradas.
        private void ActualizarTabla()
        {
            // Elimina todas las filas actuales de la tabla antes de recargar.
            dgvActividades.Rows.Clear();

            // Recorre el arreglo de actividades obtenido desde el gestor.
            foreach (Actividad a in gestor.ObtenerActividades())
            {
                // Agrega una nueva fila con ID, nombre, fecha formateada, lugar, capacidad, inscritos, disponibles y en espera.
                dgvActividades.Rows.Add(a.Id, a.Nombre, a.Fecha.ToString("dd/MM/yyyy"),
                    a.Lugar, a.Capacidad, a.Inscritos, a.CuposDisponibles, a.EnEspera);
            }
        }
    }
}