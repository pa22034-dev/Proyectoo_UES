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
    // Declara la clase parcial FrmInscripciones que hereda de Form para gestionar inscripciones visualmente.
    public partial class FrmInscripciones : Form
    {
        // Referencia privada y de solo lectura al gestor que coordina las operaciones del sistema.
        private readonly GestorActividades gestor;

        // Constructor del formulario que recibe la instancia compartida de GestorActividades.
        public FrmInscripciones(GestorActividades gestor)
        {
            // Asigna el gestor recibido al campo privado de la clase.
            this.gestor = gestor;
            // Inicializa todos los controles visuales diseñados en el formulario (botones, cajas de texto, tablas).
            InitializeComponent();
            // Carga la lista inicial de actividades en el ComboBox al abrir el formulario.
            CargarActividades();
        }

        // Propiedad privada que devuelve el objeto Actividad actualmente seleccionado en el ComboBox.
        private Actividad ActividadSeleccionada
        {
            // Bloque descriptor de acceso que obtiene el valor de la propiedad.
            get
            {
                // Intenta convertir el ítem seleccionado en el ComboBox a tipo Actividad (devuelve null si no hay selección).
                return cboActividad.SelectedItem as Actividad;
            }
        }

        // Evento que se ejecuta cada vez que el usuario cambia la actividad seleccionada en el ComboBox.
        private void cboActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Refresca las tablas de estudiantes inscritos y en lista de espera según la nueva selección.
            ActualizarTablas();
        }

        // Evento que se ejecuta al hacer clic en el botón "Inscribir".
        private void btnInscribir_Click(object sender, EventArgs e)
        {
            // Obtiene la actividad actualmente seleccionada mediante la propiedad auxiliar.
            Actividad actividad = ActividadSeleccionada;

            // Verifica si no hay ninguna actividad seleccionada en el ComboBox.
            if (actividad == null)
            {
                // Muestra un aviso al usuario indicando que debe existir y seleccionarse una actividad.
                MessageBox.Show("Primero registra y selecciona una actividad.");
                // Detiene la ejecución del método para evitar errores de referencia nula.
                return;
            }

            // Invoca al gestor para procesar la inscripción con el ID de actividad, carné y nombre ingresados.
            bool correcto = gestor.Inscribir(actividad.Id, txtCarnet.Text,
                txtNombre.Text, out string mensaje);

            // Muestra el mensaje resultante al usuario con ícono de información si tuvo éxito o advertencia si falló.
            MessageBox.Show(mensaje, "Inscripciones", MessageBoxButtons.OK,
                correcto ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            // Si la inscripción o ingreso a cola de espera se realizó correctamente:
            if (correcto)
            {
                // Limpia la caja de texto del carné.
                txtCarnet.Clear();
                // Limpia la caja de texto del nombre del estudiante.
                txtNombre.Clear();
                // Recarga el ComboBox de actividades para reflejar los cupos actualizados.
                CargarActividades();
                // Actualiza las tablas visuales de inscritos y en espera.
                ActualizarTablas();
            }
        }

        // Evento que se ejecuta al hacer clic en el botón "Cancelar inscripción".
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Obtiene la actividad actualmente seleccionada.
            Actividad actividad = ActividadSeleccionada;

            // Verifica si no se ha seleccionado ninguna actividad.
            if (actividad == null)
            {
                // Muestra un mensaje solicitando seleccionar una actividad primero.
                MessageBox.Show("Selecciona una actividad.");
                // Interrumpe la ejecución del evento.
                return;
            }

            // Solicita al gestor cancelar la inscripción o solicitud en espera del carné ingresado.
            bool correcto = gestor.Cancelar(actividad.Id, txtCarnet.Text, out string mensaje);

            // Muestra el resultado de la operación con el ícono correspondiente según el éxito o fallo.
            MessageBox.Show(mensaje, "Cancelar inscripción", MessageBoxButtons.OK,
                correcto ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            // Si la cancelación fue exitosa:
            if (correcto)
            {
                // Limpia el campo de texto del carné.
                txtCarnet.Clear();
                // Recarga las actividades para actualizar los contadores de cupos en el ComboBox.
                CargarActividades();
                // Refresca ambas tablas (por si alguien subió de la cola de espera a inscritos).
                ActualizarTablas();
            }
        }

        // Evento que se ejecuta al hacer clic en el botón "Actualizar".
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Vuelve a cargar la lista de actividades en el ComboBox.
            CargarActividades();
            // Refresca los datos mostrados en las tablas de inscritos y lista de espera.
            ActualizarTablas();
        }

        // Evento que se ejecuta al hacer clic en el botón "Volver".
        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual y regresa a la ventana anterior.
            Close();
        }

        // Método privado que llena el ComboBox con las actividades registradas manteniendo la selección previa si existe.
        private void CargarActividades()
        {
            // Inicializa el ID anterior en -1 (valor por defecto cuando no hay nada seleccionado).
            int idAnterior = -1;

            // Si había una actividad seleccionada antes de recargar, guarda su ID para restaurarla después.
            if (ActividadSeleccionada != null)
            {
                // Asigna el identificador de la actividad previamente seleccionada.
                idAnterior = ActividadSeleccionada.Id;
            }

            // Elimina todos los elementos actuales del ComboBox antes de volver a llenarlo.
            cboActividad.Items.Clear();

            // Recorre el arreglo de actividades obtenido desde el gestor.
            foreach (Actividad a in gestor.ObtenerActividades())
            {
                // Agrega cada objeto Actividad al ComboBox.
                cboActividad.Items.Add(a);
            }

            // Recorre los elementos recién agregados al ComboBox buscando la actividad que estaba seleccionada.
            for (int i = 0; i < cboActividad.Items.Count; i++)
            {
                // Comprueba si el ID del elemento actual coincide con el ID guardado anteriormente.
                if (((Actividad)cboActividad.Items[i]).Id == idAnterior)
                {
                    // Restaura la selección en el índice correspondiente (esto dispara SelectedIndexChanged).
                    cboActividad.SelectedIndex = i;
                    // Sale del método ya que la selección y las tablas quedaron actualizadas.
                    return;
                }
            }

            // Si no se encontró la selección anterior pero hay actividades disponibles, selecciona la primera.
            if (cboActividad.Items.Count > 0)
            {
                // Selecciona el primer elemento de la lista (índice 0).
                cboActividad.SelectedIndex = 0;
            }
            else
            {
                // Si no hay actividades registradas, limpia las tablas llamando a ActualizarTablas.
                ActualizarTablas();
            }
        }

        // Método privado que rellena los DataGridView de estudiantes inscritos y estudiantes en cola de espera.
        private void ActualizarTablas()
        {
            // Limpia todas las filas de la tabla de estudiantes inscritos.
            dgvInscritos.Rows.Clear();
            // Limpia todas las filas de la tabla de solicitudes en espera.
            dgvEspera.Rows.Clear();

            // Obtiene la actividad actualmente seleccionada en el ComboBox.
            Actividad actividad = ActividadSeleccionada;

            // Si no hay actividad seleccionada, termina el método dejando las tablas vacías.
            if (actividad == null)
            {
                // Retorna sin intentar leer listas de una actividad nula.
                return;
            }

            // Recorre la lista de estudiantes con cupo confirmado en la actividad.
            foreach (Estudiante e in actividad.ObtenerInscritos())
            {
                // Agrega una fila a la tabla de inscritos con el carné y el nombre del estudiante.
                dgvInscritos.Rows.Add(e.Carnet, e.Nombre);
            }

            // Recorre todas las solicitudes en la cola FIFO de espera de la actividad.
            foreach (SolicitudInscripcion s in actividad.ColaEspera.ObtenerTodas())
            {
                // Agrega una fila a la tabla de espera con carné, nombre y fecha/hora formateada de la solicitud.
                dgvEspera.Rows.Add(s.Estudiante.Carnet, s.Estudiante.Nombre,
                    s.FechaSolicitud.ToString("dd/MM/yyyy HH:mm:ss"));
            }
        }
    }
}