
using System;
using Proyectoo_UES.Estructuras;
using Proyectoo_UES.Modelos;

// Define el espacio de nombres correspondiente a las clases de modelo del proyecto.
namespace Proyectoo_UES.Modelos
{
    // Declara la clase pública Actividad que representa un evento académico/cultural y administra sus cupos.
    public class Actividad
    {
        // Propiedad de solo lectura que almacena el identificador numérico único de la actividad.
        public int Id { get; }
        // Propiedad de solo lectura que almacena el nombre de la actividad.
        public string Nombre { get; set; }
        // Propiedad de solo lectura que almacena la descripción detallada de la actividad.
        public string Descripcion { get; set; }
        // Propiedad de solo lectura que almacena la fecha programada para la actividad.
        public DateTime Fecha { get; set; }
        // Propiedad de solo lectura que almacena el lugar físico donde se realizará la actividad.
        public string Lugar { get; set; }

        // Arreglo privado y de solo lectura que representa los espacios o cupos físicos disponibles.
        private readonly Estudiante[] cupos;

        // Propiedad que inicializa y expone la cola FIFO propia de solicitudes en espera de esta actividad.
        public ColaInscripciones ColaEspera { get; } = new ColaInscripciones();

        // Propiedad pública que devuelve la capacidad total de cupos de la actividad.
        public int Capacidad
        {
            // Bloque descriptor de acceso que retorna la longitud del arreglo de cupos.
            get
            {
                // Devuelve el tamaño fijo con el que fue creado el arreglo cupos.
                return cupos.Length;
            }
        }

        // Propiedad pública que cuenta cuántos cupos del arreglo están actualmente ocupados por un estudiante.
        public int Inscritos
        {
            // Bloque descriptor de acceso que calcula el total de inscritos.
            get
            {
                // Inicializa en cero el contador de asientos ocupados.
                int contador = 0;

                // Recorre cada posición del arreglo de cupos.
                for (int i = 0; i < cupos.Length; i++)
                {
                    // Verifica si la posición actual contiene una referencia a un estudiante (no es null).
                    if (cupos[i] != null)
                    {
                        // Incrementa el contador de estudiantes inscritos.
                        contador++;
                    }
                }

                // Devuelve la cantidad total de estudiantes con cupo asignado.
                return contador;
            }
        }

        // Propiedad pública que calcula cuántos cupos libres quedan disponibles en la actividad.
        public int CuposDisponibles
        {
            // Bloque descriptor de acceso que resta los inscritos a la capacidad total.
            get
            {
                // Retorna la diferencia entre la capacidad máxima y los lugares ya ocupados.
                return Capacidad - Inscritos;
            }
        }

        // Propiedad pública que devuelve la cantidad de estudiantes aguardando en la cola de espera.
        public int EnEspera
        {
            // Bloque descriptor de acceso que consulta el tamaño de la cola.
            get
            {
                // Retorna la propiedad Cantidad de la instancia ColaEspera.
                return ColaEspera.Cantidad;
            }
        }

        // Constructor que inicializa los datos de la actividad y reserva el arreglo con la capacidad indicada.
        public Actividad(int id, string nombre, string descripcion,
                         DateTime fecha, string lugar, int capacidad)
        {
            // Asigna el identificador único a la propiedad Id.
            Id = id;
            // Asigna el nombre a la propiedad Nombre.
            Nombre = nombre;
            // Asigna la descripción a la propiedad Descripcion.
            Descripcion = descripcion;
            // Asigna la fecha a la propiedad Fecha.
            Fecha = fecha;
            // Asigna el lugar a la propiedad Lugar.
            Lugar = lugar;
            // Crea el arreglo de estudiantes con un tamaño fijo igual a la capacidad máxima.
            cupos = new Estudiante[capacidad];
        }

        // Método público que verifica si un estudiante ya tiene un cupo asignado buscando por su carné.
        public bool EstaInscrito(string carnet)
        {
            // Recorre todas las posiciones del arreglo de cupos.
            for (int i = 0; i < cupos.Length; i++)
            {
                // Comprueba que el cupo esté ocupado y que el carné coincida ignorando mayúsculas/minúsculas.
                if (cupos[i] != null &&
                    cupos[i].Carnet.Equals(carnet, StringComparison.OrdinalIgnoreCase))
                {
                    // Devuelve true inmediatamente si encuentra al estudiante inscrito.
                    return true;
                }
            }

            // Devuelve false si terminó de revisar todo el arreglo sin encontrar coincidencias.
            return false;
        }

        // Método público que verifica si el estudiante ya tiene una solicitud pendiente en la cola de espera.
        public bool EstaEnEspera(string carnet)
        {
            // Delega la búsqueda por carné a la estructura ColaEspera y retorna el resultado.
            return ColaEspera.ContieneCarnet(carnet);
        }

        // Método público que asigna el primer cupo libre del arreglo al estudiante recibido.
        public bool AgregarEstudiante(Estudiante estudiante)
        {
            // Verifica que el estudiante no esté ya inscrito ni en cola de espera para evitar duplicados.
            if (EstaInscrito(estudiante.Carnet) || EstaEnEspera(estudiante.Carnet))
            {
                // Retorna false rechazando la inscripción duplicada.
                return false;
            }

            // Recorre secuencialmente el arreglo buscando la primera casilla vacía (null).
            for (int i = 0; i < cupos.Length; i++)
            {
                // Comprueba si el espacio actual está disponible.
                if (cupos[i] == null)
                {
                    // Asigna el estudiante a ese espacio libre.
                    cupos[i] = estudiante;
                    // Retorna true confirmando que se asignó el cupo.
                    return true;
                }
            }

            // Retorna false si todos los espacios del arreglo estaban ocupados.
            return false;
        }

        // Método público que libera el cupo de un estudiante según su carné y devuelve sus datos por parámetro out.
        public bool CancelarInscripcion(string carnet, out Estudiante estudianteCancelado)
        {
            // Inicializa el parámetro de salida en null por defecto.
            estudianteCancelado = null;

            // Recorre todas las posiciones del arreglo de cupos.
            for (int i = 0; i < cupos.Length; i++)
            {
                // Verifica si la posición está ocupada y pertenece al carné que desea cancelar.
                if (cupos[i] != null &&
                    cupos[i].Carnet.Equals(carnet, StringComparison.OrdinalIgnoreCase))
                {
                    // Guarda la referencia del estudiante cancelado en el parámetro de salida.
                    estudianteCancelado = cupos[i];
                    // Asigna null a esa posición del arreglo para dejar el cupo libre nuevamente.
                    cupos[i] = null;
                    // Retorna true confirmando que la inscripción fue cancelada.
                    return true;
                }
            }

            // Retorna false si no se encontró ningún estudiante inscrito con ese carné.
            return false;
        }


        // Método público que permite actualizar los datos de un estudiante
        // que se encuentra inscrito o en la lista de espera.
        public bool ActualizarEstudiante(string carnetAnterior, Estudiante estudianteNuevo)
        {
            // Recorre todas las posiciones del arreglo de cupos.
            for (int i = 0; i < cupos.Length; i++)
            {
                // Comprueba que la posición tenga un estudiante
                // y que su carné coincida con el carné anterior.
                if (cupos[i] != null &&
                    cupos[i].Carnet.Equals(
                        carnetAnterior, StringComparison.OrdinalIgnoreCase))
                {
                    // Reemplaza el estudiante anterior por el nuevo estudiante.
                    cupos[i] = estudianteNuevo;

                    // Devuelve true indicando que la actualización fue exitosa.
                    return true;
                }
            }

            // Si no se encontró en el arreglo de inscritos,
            // intenta actualizarlo dentro de la cola de espera.
            return ColaEspera.ActualizarPorCarnet(
                carnetAnterior, estudianteNuevo);
        }




        public bool ActualizarInscrito(string carnetAnterior, Estudiante estudianteNuevo)
        {
            // Verifica que el nuevo carné no esté repetido.
            for (int i = 0; i < cupos.Length; i++)
            {
                if (cupos[i] != null &&
                    !cupos[i].Carnet.Equals(carnetAnterior,
                    StringComparison.OrdinalIgnoreCase) &&
                    cupos[i].Carnet.Equals(estudianteNuevo.Carnet,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            // Busca al estudiante que se desea actualizar.
            for (int i = 0; i < cupos.Length; i++)
            {
                if (cupos[i] != null &&
                    cupos[i].Carnet.Equals(carnetAnterior,
                    StringComparison.OrdinalIgnoreCase))
                {
                    // Reemplaza el objeto anterior por el nuevo.
                    cupos[i] = estudianteNuevo;
                    return true;
                }
            }

            return false;
        }



        // Método público que devuelve un arreglo compacto únicamente con los estudiantes inscritos (sin espacios nulos).
        public Estudiante[] ObtenerInscritos()
        {
            // Crea un arreglo nuevo con el tamaño exacto de estudiantes actualmente inscritos.
            Estudiante[] resultado = new Estudiante[Inscritos];
            // Inicializa el índice de escritura para el arreglo resultante.
            int indice = 0;

            // Recorre todas las posiciones del arreglo original de cupos.
            for (int i = 0; i < cupos.Length; i++)
            {
                // Si la posición actual contiene un estudiante válido:
                if (cupos[i] != null)
                {
                    // Copia el estudiante al arreglo compacto e incrementa el índice de escritura.
                    resultado[indice++] = cupos[i];
                }
            }

            // Devuelve el arreglo filtrado con todos los estudiantes inscritos.
            return resultado;
        }

        // Método público que devuelve una copia superficial del arreglo completo de cupos (incluyendo nulos).
        public Estudiante[] ObtenerCupos()
        {
            // Clona el arreglo interno para evitar que código externo altere directamente las referencias.
            return (Estudiante[])cupos.Clone();
        }

        // Sobrescribe el método ToString para mostrar un resumen legible de la actividad (usado en ComboBox).
        public override string ToString()
        {
            // Retorna una cadena formateada con el ID, el nombre y los cupos disponibles actuales.
            return $"{Id} - {Nombre} ({CuposDisponibles} cupos libres)";
        }
    }
}