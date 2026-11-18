
using System;

// Define el espacio de nombres de las clases del modelo.
namespace Proyectoo_UES.Modelos
{
    // Representa una solicitud de inscripción de un estudiante en la cola de espera.
    public class SolicitudInscripcion
    {
        // Propiedad de solo lectura que almacena los datos del estudiante.
        public Estudiante Estudiante { get; }

        // Propiedad de solo lectura que almacena la fecha y hora de la solicitud.
        public DateTime FechaSolicitud { get; }

        // Constructor principal que recibe un estudiante y registra la fecha actual.
        public SolicitudInscripcion(Estudiante estudiante)
        {
            // Asigna el estudiante recibido a la propiedad correspondiente.
            Estudiante = estudiante;

            // Guarda la fecha y hora actual del sistema.
            FechaSolicitud = DateTime.Now;
        }

        // Constructor adicional que permite crear una solicitud conservando su fecha original.
        public SolicitudInscripcion(Estudiante estudiante, DateTime fechaSolicitud)
        {
            // Asigna el estudiante recibido a la propiedad correspondiente.
            Estudiante = estudiante;

            // Conserva la fecha y hora original de la solicitud.
            FechaSolicitud = fechaSolicitud;
        }
    }
}
