using System;
using Proyectoo_UES.Modelos;

namespace Proyectoo_UES.Estructuras
{
    // Declara la clase pública ColaInscripciones que implementa una cola FIFO (primero en entrar, primero en salir).
    public class ColaInscripciones
    {
        // Clase interna privada que representa cada nodo enlazado dentro de la cola.
        private class NodoSolicitud
        {
            // Propiedad de solo lectura que almacena los datos de la solicitud de inscripción.
            public SolicitudInscripcion Solicitud { get; }
            // Propiedad que apunta al siguiente nodo en la fila de espera.
            public NodoSolicitud Siguiente { get; set; }

            // Constructor del nodo que inicializa la solicitud recibida.
            public NodoSolicitud(SolicitudInscripcion solicitud)
            {
                // Asigna la solicitud al nodo actual.
                Solicitud = solicitud;
            }
        }

        // Puntero privado hacia el primer nodo de la cola (el próximo en ser atendido).
        private NodoSolicitud frente;
        // Puntero privado hacia el último nodo de la cola (donde se insertan los nuevos elementos).
        private NodoSolicitud final;

        // Propiedad pública que indica cuántos elementos hay actualmente en la cola (solo modificable internamente).
        public int Cantidad { get; private set; }

        // Propiedad pública que devuelve true si la cola no contiene ningún nodo.
        public bool EstaVacia
        {
            // Descriptor de acceso que evalúa el estado de la cola.
            get
            {
                // Retorna true si el puntero frente es nulo; de lo contrario, false.
                return frente == null;
            }
        }

        // Método público para insertar una nueva solicitud al final de la cola.
        public void Encolar(SolicitudInscripcion solicitud)
        {
            // Crea un nuevo nodo que envuelve la solicitud recibida.
            NodoSolicitud nuevo = new NodoSolicitud(solicitud);

            // Verifica si la cola se encuentra actualmente vacía.
            if (EstaVacia)
            {
                // Si está vacía, tanto el frente como el final apuntan al nuevo nodo.
                frente = final = nuevo;
            }
            else
            {
                // Si ya hay elementos, enlaza el último nodo actual con el nuevo nodo.
                final.Siguiente = nuevo;
                // Actualiza el puntero final para que apunte al nuevo último nodo.
                final = nuevo;
            }

            // Incrementa en uno el contador de solicitudes en espera.
            Cantidad++;
        }

        // Método público para extraer y devolver la solicitud ubicada al frente de la cola.
        public SolicitudInscripcion Desencolar()
        {
            // Si la cola está vacía, no hay nada que extraer y devuelve null.
            if (EstaVacia)
            {
                // Retorna null indicando que no existen solicitudes pendientes.
                return null;
            }

            // Guarda en una variable temporal la solicitud del primer nodo antes de quitarlo.
            SolicitudInscripcion resultado = frente.Solicitud;
            // Avanza el puntero frente hacia el segundo nodo de la cola.
            frente = frente.Siguiente;

            // Si al avanzar frente quedó en null, significa que la cola quedó completamente vacía.
            if (frente == null)
            {
                // Restablece también el puntero final a null.
                final = null;
            }

            // Disminuye en uno el contador de elementos en la cola.
            Cantidad--;
            // Devuelve la solicitud que estaba al frente.
            return resultado;
        }

        // Método público para observar la solicitud al frente de la cola sin eliminarla.
        public SolicitudInscripcion ConsultarFrente()
        {
            // Comprueba si la cola está vacía.
            if (frente == null)
            {
                // Retorna null si no hay ningún nodo al frente.
                return null;
            }

            // Devuelve la solicitud almacenada en el nodo frente sin modificar la estructura.
            return frente.Solicitud;
        }

        // Método público que verifica si un estudiante ya se encuentra en la cola buscando por su carné.
        public bool ContieneCarnet(string carnet)
        {
            // Inicia el recorrido desde el primer nodo de la cola.
            NodoSolicitud actual = frente;

            // Recorre todos los nodos mientras no se llegue al final (null).
            while (actual != null)
            {
                // Compara el carné del estudiante del nodo actual con el buscado ignorando mayúsculas/minúsculas.
                if (actual.Solicitud.Estudiante.Carnet.Equals(
                    carnet, StringComparison.OrdinalIgnoreCase))
                {
                    // Si hay coincidencia, retorna true inmediatamente.
                    return true;
                }

                // Avanza al siguiente nodo de la cola.
                actual = actual.Siguiente;
            }

            // Si terminó el recorrido sin encontrar el carné, retorna false.
            return false;
        }

        // Método público que devuelve un arreglo con todas las solicitudes en el orden en que serán atendidas.
        public SolicitudInscripcion[] ObtenerTodas()
        {
            // Crea un arreglo con el tamaño exacto de elementos actuales en la cola.
            SolicitudInscripcion[] resultado = new SolicitudInscripcion[Cantidad];
            // Inicia un puntero auxiliar en el frente de la cola.
            NodoSolicitud actual = frente;
            // Inicializa el índice para ir llenando el arreglo.
            int i = 0;

            // Recorre cada nodo de la cola hasta llegar al final.
            while (actual != null)
            {
                // Copia la solicitud del nodo actual al arreglo e incrementa el índice.
                resultado[i++] = actual.Solicitud;
                // Avanza al siguiente nodo.
                actual = actual.Siguiente;
            }

            // Devuelve el arreglo completo con todas las solicitudes.
            return resultado;
        }

        // Método público que permite cancelar una solicitud en espera por carné conservando el orden FIFO.
        public bool EliminarPorCarnet(string carnet)
        {
            // Crea una cola auxiliar temporal para reubicar los elementos que no serán eliminados.
            ColaInscripciones temporal = new ColaInscripciones();
            // Bandera booleana que indica si se encontró y eliminó la solicitud buscada.
            bool eliminada = false;

            // Desencola todos los elementos de la cola original uno por uno.
            while (!EstaVacia)
            {
                // Extrae la solicitud del frente de la cola actual.
                SolicitudInscripcion solicitud = Desencolar();

                // Si aún no se ha eliminado y el carné coincide con el buscado, omite volver a encolarla.
                if (!eliminada && solicitud.Estudiante.Carnet.Equals(
                    carnet, StringComparison.OrdinalIgnoreCase))
                {
                    // Marca que la solicitud fue encontrada y descartada.
                    eliminada = true;
                }
                else
                {
                    // Si no coincide, guarda la solicitud en la cola temporal para mantener su orden.
                    temporal.Encolar(solicitud);
                }
            }

            // Devuelve todas las solicitudes restantes desde la cola temporal hacia la cola original.
            while (!temporal.EstaVacia)
            {
                // Desencola de la temporal y vuelve a encolar en la instancia principal.
                Encolar(temporal.Desencolar());
            }

            // Retorna true si se eliminó el carné buscado, o false si no estaba en la cola.
            return eliminada;
        }
    
    
        // Método público que permite actualizar los datos de un estudiante
        // que se encuentra dentro de la cola de espera.
        public bool ActualizarPorCarnet(string carnetAnterior, Estudiante estudianteNuevo)
        {
            // Crea una cola auxiliar para almacenar temporalmente las solicitudes.
            ColaInscripciones temporal = new ColaInscripciones();

            // Variable que indica si se encontró y actualizó al estudiante.
            bool actualizado = false;

            // Recorre todos los elementos de la cola original.
            while (!EstaVacia)
            {
                // Extrae la solicitud que se encuentra al frente de la cola.
                SolicitudInscripcion solicitud = Desencolar();

                // Comprueba si el carné de la solicitud coincide con el carné anterior.
                if (!actualizado &&
                    solicitud.Estudiante.Carnet.Equals(
                        carnetAnterior, StringComparison.OrdinalIgnoreCase))
                {
                    // Crea una nueva solicitud con los datos actualizados del estudiante.
                    // También conserva la fecha y hora de la solicitud original.
                    SolicitudInscripcion nuevaSolicitud =
                        new SolicitudInscripcion(
                            estudianteNuevo,
                            solicitud.FechaSolicitud);

                    // Guarda la nueva solicitud en la cola temporal.
                    temporal.Encolar(nuevaSolicitud);

                    // Indica que el estudiante ya fue actualizado.
                    actualizado = true;
                }
                else
                {
                    // Si no corresponde al estudiante buscado,
                    // conserva la solicitud original en la cola temporal.
                    temporal.Encolar(solicitud);
                }
            }

            // Devuelve todos los elementos de la cola temporal a la cola original.
            while (!temporal.EstaVacia)
            {
                // Extrae el primer elemento de la cola temporal
                // y lo agrega al final de la cola original.
                Encolar(temporal.Desencolar());
            }

            // Devuelve true si encontró y actualizó al estudiante.
            return actualizado;
        } 
    }

    
}
