using System;
using Proyectoo_UES.Estructuras;
using Proyectoo_UES.Modelos;
namespace Proyectoo_UES.Servicios
{
    // Coordina las operaciones del sistema; los formularios no manipulan directamente las estructuras.
    public class GestorActividades
    {
        // Instancia privada y de solo lectura que almacena la lista enlazada de actividades.
        private readonly ListaActividades actividades = new ListaActividades();
        // Contador entero que genera identificadores únicos autoincrementales para cada actividad.
        private int siguienteId = 1;

        // Método público que devuelve un arreglo con todas las actividades registradas.
        public Actividad[] ObtenerActividades()
        {
            // Llama al método ObtenerTodas de la estructura y retorna el arreglo resultante.
            return actividades.ObtenerTodas();
        }

        // Método público que busca y devuelve una actividad específica según su identificador numérico.
        public Actividad BuscarActividad(int id)
        {
            // Delega la búsqueda por ID a la estructura de datos y retorna la actividad (o null si no existe).
            return actividades.BuscarPorId(id);
        }

        // Método público para validar y registrar una nueva actividad; devuelve true si tuvo éxito y un mensaje de salida.
        public bool RegistrarActividad(string nombre, string descripcion, DateTime fecha,
                                       string lugar, int capacidad, out string mensaje)
        {
            // Elimina espacios en blanco al inicio y final de 'nombre', o asigna cadena vacía si es null.
            nombre = (nombre ?? "").Trim();
            // Elimina espacios en blanco al inicio y final de 'descripcion', o asigna cadena vacía si es null.
            descripcion = (descripcion ?? "").Trim();
            // Elimina espacios en blanco al inicio y final de 'lugar', o asigna cadena vacía si es null.
            lugar = (lugar ?? "").Trim();

            // Verifica que el nombre de la actividad tenga al menos 3 caracteres.
            if (nombre.Length < 3)
            {
                // Asigna el mensaje de error indicando la longitud mínima del nombre.
                mensaje = "El nombre debe tener al menos 3 caracteres.";
                // Interrumpe el registro y devuelve false indicando que falló la validación.
                return false;
            }

            // Verifica que el lugar tenga al menos 2 caracteres.
            if (lugar.Length < 2)
            {
                // Asigna el mensaje de error indicando que el lugar no es válido.
                mensaje = "Ingresa un lugar válido.";
                // Interrumpe el registro y devuelve false.
                return false;
            }

            // Comprueba que la fecha de la actividad no sea anterior al día actual.
            if (fecha.Date < DateTime.Today)
            {
                // Asigna el mensaje de error indicando que no se permiten fechas pasadas.
                mensaje = "La fecha no puede estar en el pasado.";
                // Interrumpe el registro y devuelve false.
                return false;
            }

            // Valida que la capacidad de cupos se encuentre dentro del rango permitido (1 a 500).
            if (capacidad < 1 || capacidad > 500)
            {
                // Asigna el mensaje de error especificando el rango válido de cupos.
                mensaje = "La capacidad debe estar entre 1 y 500 cupos.";
                // Interrumpe el registro y devuelve false.
                return false;
            }

            // Busca si ya existe otra actividad registrada con el mismo nombre para evitar duplicados.
            if (actividades.BuscarPorNombre(nombre) != null)
            {
                // Asigna el mensaje de error indicando la duplicidad del nombre.
                mensaje = "Ya existe una actividad con ese nombre.";
                // Interrumpe el registro y devuelve false.
                return false;
            }

            // Crea una nueva instancia de Actividad asignándole el ID actual (e incrementándolo) y los datos validados.
            Actividad nueva = new Actividad(siguienteId++, nombre, descripcion,
                                            fecha, lugar, capacidad);

            // Inserta la nueva actividad dentro de la estructura ListaActividades.
            actividades.Agregar(nueva);
            // Asigna el mensaje de confirmación de registro exitoso.
            mensaje = "Actividad registrada correctamente.";
            // Devuelve true indicando que la operación se completó con éxito.
            return true;
        }

        // Método público para eliminar una actividad por su ID si cumple las condiciones; devuelve éxito y mensaje.
        public bool EliminarActividad(int id, out string mensaje)
        {
            // Busca la actividad en la lista mediante su ID.
            Actividad actividad = actividades.BuscarPorId(id);

            // Verifica si la actividad no fue encontrada.
            if (actividad == null)
            {
                // Asigna el mensaje informando que la actividad no existe.
                mensaje = "La actividad seleccionada ya no existe.";
                // Devuelve false porque no se pudo eliminar.
                return false;
            }

            // Comprueba si la actividad tiene estudiantes inscritos o en cola de espera antes de borrarla.
            if (actividad.Inscritos > 0 || actividad.EnEspera > 0)
            {
                // Asigna el mensaje de error impidiendo la eliminación por tener alumnos asociados.
                mensaje = "No se puede eliminar: hay estudiantes inscritos o en lista de espera.";
                // Devuelve false cancelando la eliminación.
                return false;
            }

            // Elimina la actividad de la lista enlazada usando su ID.
            actividades.Eliminar(id);
            // Asigna el mensaje de confirmación de eliminación.
            mensaje = "Actividad eliminada correctamente.";
            // Devuelve true indicando que la actividad fue eliminada.
            return true;
        }

        // Método público para inscribir a un estudiante en una actividad o enviarlo a la cola de espera.
        public bool Inscribir(int idActividad, string carnet, string nombre,
                              out string mensaje)
        {
            // Busca la actividad destino mediante su ID.
            Actividad actividad = actividades.BuscarPorId(idActividad);
            // Limpia espacios en blanco del carné (o usa cadena vacía si es null).
            carnet = (carnet ?? "").Trim();
            // Limpia espacios en blanco del nombre del estudiante (o usa cadena vacía si es null).
            nombre = (nombre ?? "").Trim();

            // Verifica si la actividad seleccionada es válida y existe.
            if (actividad == null)
            {
                // Asigna el mensaje de error por actividad inexistente.
                mensaje = "Selecciona una actividad válida.";
                // Devuelve false interrumpiendo la inscripción.
                return false;
            }

            // Valida que la longitud del carné esté entre 3 y 20 caracteres.
            if (carnet.Length < 3 || carnet.Length > 20)
            {
                // Asigna el mensaje de error sobre el formato del carné.
                mensaje = "El carné debe tener entre 3 y 20 caracteres.";
                // Devuelve false interrumpiendo la inscripción.
                return false;
            }

            // Valida que el nombre del estudiante tenga al menos 3 caracteres.
            if (nombre.Length < 3)
            {
                // Asigna el mensaje de error sobre la longitud del nombre.
                mensaje = "El nombre del estudiante debe tener al menos 3 caracteres.";
                // Devuelve false interrumpiendo la inscripción.
                return false;
            }

            // Verifica si el estudiante ya posee un cupo confirmado o ya está en la cola de espera de esta actividad.
            if (actividad.EstaInscrito(carnet) || actividad.EstaEnEspera(carnet))
            {
                // Asigna el mensaje informando que el estudiante ya está registrado en la actividad.
                mensaje = "Este estudiante ya está inscrito o en espera para esta actividad.";
                // Devuelve false para evitar inscripciones duplicadas.
                return false;
            }

            // Crea un nuevo objeto Estudiante con el carné y nombre validados.
            Estudiante estudiante = new Estudiante(carnet, nombre);

            // Comprueba si todavía hay cupos disponibles en la actividad.
            if (actividad.CuposDisponibles > 0)
            {
                // Agrega al estudiante directamente a la lista de inscritos confirmados.
                actividad.AgregarEstudiante(estudiante);
                // Asigna el mensaje confirmando la asignación del cupo.
                mensaje = "Inscripción confirmada. Se asignó un cupo.";
                // Devuelve true indicando que el proceso finalizó correctamente.
                return true;
            }

            // Si no hay cupos disponibles, crea una solicitud y la agrega al final de la cola FIFO de espera.
            actividad.ColaEspera.Encolar(new SolicitudInscripcion(estudiante));
            // Asigna el mensaje informando que el estudiante quedó en lista de espera.
            mensaje = "La actividad está llena. El estudiante fue agregado a la lista de espera.";
            // Devuelve true indicando que la solicitud fue procesada.
            return true;
        }

        // Método público para cancelar la inscripción o solicitud en espera de un estudiante mediante su carné.
        public bool Cancelar(int idActividad, string carnet, out string mensaje)
        {
            // Busca la actividad correspondiente mediante su ID.
            Actividad actividad = actividades.BuscarPorId(idActividad);
            // Limpia los espacios en blanco de los extremos del carné.
            carnet = (carnet ?? "").Trim();

            // Verifica que la actividad exista.
            if (actividad == null)
            {
                // Asigna el mensaje de error por actividad no encontrada.
                mensaje = "Selecciona una actividad válida.";
                // Devuelve false cancelando la operación.
                return false;
            }

            // Comprueba que el carné no esté vacío ni compuesto solo por espacios.
            if (string.IsNullOrWhiteSpace(carnet))
            {
                // Asigna el mensaje solicitando un carné válido.
                mensaje = "Ingresa el carné del estudiante.";
                // Devuelve false cancelando la operación.
                return false;
            }

            // Intenta cancelar una inscripción confirmada; si existe, devuelve los datos del estudiante en 'cancelado'.
            if (actividad.CancelarInscripcion(carnet, out Estudiante cancelado))
            {
                // Extrae (desencola) la primera solicitud en espera (orden FIFO) para cubrir el cupo liberado.
                SolicitudInscripcion siguiente = actividad.ColaEspera.Desencolar();

                // Verifica si había alguien esperando en la cola.
                if (siguiente != null)
                {
                    // Inscribe automáticamente al estudiante que estaba primero en la cola de espera.
                    actividad.AgregarEstudiante(siguiente.Estudiante);
                    // Informa que se canceló la inscripción y quién recibió el cupo liberado.
                    mensaje = $"Inscripción cancelada. El cupo se asignó a {siguiente.Estudiante.Nombre}.";
                }
                else
                {
                    // Si la cola estaba vacía, informa que se canceló la inscripción y el cupo queda libre.
                    mensaje = $"Se canceló la inscripción de {cancelado.Nombre}. El cupo quedó disponible.";
                }

                // Devuelve true confirmando la cancelación.
                return true;
            }

            // Si no estaba inscrito, intenta eliminarlo directamente de la cola de espera por su carné.
            if (actividad.ColaEspera.EliminarPorCarnet(carnet))
            {
                // Asigna el mensaje confirmando que se retiró su solicitud de la cola de espera.
                mensaje = "Se canceló la solicitud de la lista de espera.";
                // Devuelve true confirmando la cancelación.
                return true;
            }

            // Si no estaba ni inscrito ni en espera, asigna un mensaje indicando que no se encontró el carné.
            mensaje = "No se encontró una inscripción ni una solicitud en espera con ese carné.";
            // Devuelve false porque no había nada que cancelar.
            return false;
        }
    }
}