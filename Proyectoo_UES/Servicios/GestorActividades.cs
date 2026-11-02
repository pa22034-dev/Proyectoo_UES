using Proyectoo_UES.Estructuras;
using Proyectoo_UES.Modelos;

namespace Proyectoo_UES.Servicios
{
    // Coordina las operaciones del sistema; los formularios no manipulan directamente las estructuras.
    public class GestorActividades
    {
        private readonly ListaActividades actividades = new ListaActividades();
        private int siguienteId = 1;

        public Actividad[] ObtenerActividades() => actividades.ObtenerTodas();

        public Actividad BuscarActividad(int id) => actividades.BuscarPorId(id);

        public bool RegistrarActividad(string nombre, string descripcion, DateTime fecha,
                                       string lugar, int capacidad, out string mensaje)
        {
            nombre = (nombre ?? "").Trim();
            descripcion = (descripcion ?? "").Trim();
            lugar = (lugar ?? "").Trim();

            if (nombre.Length < 3)
            {
                mensaje = "El nombre debe tener al menos 3 caracteres.";
                return false;
            }

            if (lugar.Length < 2)
            {
                mensaje = "Ingresa un lugar válido.";
                return false;
            }

            if (fecha.Date < DateTime.Today)
            {
                mensaje = "La fecha no puede estar en el pasado.";
                return false;
            }

            if (capacidad < 1 || capacidad > 500)
            {
                mensaje = "La capacidad debe estar entre 1 y 500 cupos.";
                return false;
            }

            if (actividades.BuscarPorNombre(nombre) != null)
            {
                mensaje = "Ya existe una actividad con ese nombre.";
                return false;
            }

            Actividad nueva = new Actividad(siguienteId++, nombre, descripcion,
                                            fecha, lugar, capacidad);

            actividades.Agregar(nueva);
            mensaje = "Actividad registrada correctamente.";
            return true;
        }

        public bool EliminarActividad(int id, out string mensaje)
        {
            Actividad actividad = actividades.BuscarPorId(id);

            if (actividad == null)
            {
                mensaje = "La actividad seleccionada ya no existe.";
                return false;
            }

            // No se elimina una actividad si hay estudiantes inscritos o en espera.
            if (actividad.Inscritos > 0 || actividad.EnEspera > 0)
            {
                mensaje = "No se puede eliminar: hay estudiantes inscritos o en lista de espera.";
                return false;
            }

            actividades.Eliminar(id);
            mensaje = "Actividad eliminada correctamente.";
            return true;
        }

        public bool Inscribir(int idActividad, string carnet, string nombre,
                              out string mensaje)
        {
            Actividad actividad = actividades.BuscarPorId(idActividad);
            carnet = (carnet ?? "").Trim();
            nombre = (nombre ?? "").Trim();

            if (actividad == null)
            {
                mensaje = "Selecciona una actividad válida.";
                return false;
            }

            if (carnet.Length < 3 || carnet.Length > 20)
            {
                mensaje = "El carné debe tener entre 3 y 20 caracteres.";
                return false;
            }

            if (nombre.Length < 3)
            {
                mensaje = "El nombre del estudiante debe tener al menos 3 caracteres.";
                return false;
            }

            if (actividad.EstaInscrito(carnet) || actividad.EstaEnEspera(carnet))
            {
                mensaje = "Este estudiante ya está inscrito o en espera para esta actividad.";
                return false;
            }

            Estudiante estudiante = new Estudiante(carnet, nombre);

            if (actividad.CuposDisponibles > 0)
            {
                actividad.AgregarEstudiante(estudiante);
                mensaje = "Inscripción confirmada. Se asignó un cupo.";
                return true;
            }

            actividad.ColaEspera.Encolar(new SolicitudInscripcion(estudiante));
            mensaje = "La actividad está llena. El estudiante fue agregado a la lista de espera.";
            return true;
        }

        public bool Cancelar(int idActividad, string carnet, out string mensaje)
        {
            Actividad actividad = actividades.BuscarPorId(idActividad);
            carnet = (carnet ?? "").Trim();

            if (actividad == null)
            {
                mensaje = "Selecciona una actividad válida.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(carnet))
            {
                mensaje = "Ingresa el carné del estudiante.";
                return false;
            }

            // Primero se comprueba si el estudiante tiene un cupo confirmado.
            if (actividad.CancelarInscripcion(carnet, out Estudiante cancelado))
            {
                // Si hay alguien esperando, se le asigna automáticamente el cupo liberado.
                SolicitudInscripcion siguiente = actividad.ColaEspera.Desencolar();

                if (siguiente != null)
                {
                    actividad.AgregarEstudiante(siguiente.Estudiante);
                    mensaje = $"Inscripción cancelada. El cupo se asignó a {siguiente.Estudiante.Nombre}.";
                }
                else
                {
                    mensaje = $"Se canceló la inscripción de {cancelado.Nombre}. El cupo quedó disponible.";
                }

                return true;
            }

            // También se permite cancelar una solicitud que aún estaba en espera.
            if (actividad.ColaEspera.EliminarPorCarnet(carnet))
            {
                mensaje = "Se canceló la solicitud de la lista de espera.";
                return true;
            }

            mensaje = "No se encontró una inscripción ni una solicitud en espera con ese carné.";
            return false;
        }
    }
}
