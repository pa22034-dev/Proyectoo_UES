using System;
using Proyectoo_UES.Modelos;

// Define el espacio de nombres correspondiente a las estructuras de datos personalizadas del proyecto.
namespace Proyectoo_UES.Estructuras
{
    // Declara la clase pública ListaActividades que implementa una lista enlazada simple manualmente.
    public class ListaActividades
    {
        // Puntero privado hacia el primer nodo (inicio) de la lista enlazada.
        private NodoActividad cabeza;
        // Propiedad pública que indica cuántos nodos de actividades contiene actualmente la lista.
        public int Cantidad { get; private set; }

        // Método público para insertar una nueva actividad al final de la lista si su nombre no está duplicado.
        public bool Agregar(Actividad actividad)
        {
            // Verifica si ya existe otra actividad registrada con el mismo nombre.
            if (BuscarPorNombre(actividad.Nombre) != null)
            {
                // Retorna false rechazando la inserción para evitar nombres repetidos.
                return false;
            }

            // Crea un nuevo nodo que encapsula el objeto Actividad recibido.
            NodoActividad nuevo = new NodoActividad(actividad);

            // Comprueba si la lista se encuentra actualmente vacía.
            if (cabeza == null)
            {
                // Si está vacía, el nuevo nodo se convierte en la cabeza de la lista.
                cabeza = nuevo;
            }
            else
            {
                // Inicia un puntero auxiliar en la cabeza para recorrer la lista hasta el último nodo.
                NodoActividad actual = cabeza;
                // Avanza nodo por nodo mientras exista un nodo siguiente.
                while (actual.Siguiente != null)
                {
                    // Desplaza el puntero auxiliar al siguiente nodo de la cadena.
                    actual = actual.Siguiente;
                }

                // Enlaza el último nodo existente con el nuevo nodo creado.
                actual.Siguiente = nuevo;
            }

            // Incrementa en uno el contador total de actividades almacenadas.
            Cantidad++;
            // Retorna true indicando que la actividad fue agregada correctamente.
            return true;
        }

        // Método público que busca y devuelve una actividad recorriendo la lista según su identificador numérico.
        public Actividad BuscarPorId(int id)
        {
            // Inicia el puntero de recorrido desde el primer nodo de la lista.
            NodoActividad actual = cabeza;
            // Recorre la lista mientras no se alcance el final (null).
            while (actual != null)
            {
                // Comprueba si el ID de la actividad en el nodo actual coincide con el ID buscado.
                if (actual.Actividad.Id == id)
                {
                    // Si hay coincidencia, devuelve el objeto Actividad encontrado.
                    return actual.Actividad;
                }
                // Avanza al siguiente nodo de la lista.
                actual = actual.Siguiente;
            }
            // Retorna null si se recorrió toda la lista sin encontrar el ID especificado.
            return null;
        }

        // Método público que busca y devuelve una actividad según su nombre ignorando mayúsculas y minúsculas.
        public Actividad BuscarPorNombre(string nombre)
        {
            // Inicia el puntero de recorrido desde la cabeza de la lista.
            NodoActividad actual = cabeza;
            // Recorre cada nodo hasta llegar al final de la lista.
            while (actual != null)
            {
                // Compara el nombre de la actividad actual con el buscado sin distinguir mayúsculas/minúsculas.
                if (actual.Actividad.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    // Si coinciden, retorna la actividad encontrada.
                    return actual.Actividad;
                }
                // Avanza al siguiente nodo de la cadena.
                actual = actual.Siguiente;
            }
            // Retorna null si ninguna actividad coincide con el nombre proporcionado.
            return null;
        }

        // Método público que elimina de la lista enlazada el nodo cuya actividad coincida con el ID dado.
        public bool Eliminar(int id)
        {
            // Puntero que apunta al nodo que se está evaluando en cada iteración.
            NodoActividad actual = cabeza;
            // Puntero que guarda la referencia al nodo inmediatamente anterior al actual.
            NodoActividad anterior = null;

            // Recorre los nodos de la lista mientras no se llegue al final.
            while (actual != null)
            {
                // Verifica si el nodo actual contiene la actividad que se desea eliminar.
                if (actual.Actividad.Id == id)
                {
                    // Si anterior es null, el nodo a eliminar es el primero (la cabeza).
                    if (anterior == null)
                    {
                        // Mueve la cabeza al segundo nodo, desenlazando el primero.
                        cabeza = actual.Siguiente;
                    }
                    else
                    {
                        // Enlaza el nodo anterior directamente con el siguiente, saltándose el nodo actual.
                        anterior.Siguiente = actual.Siguiente;
                    }

                    // Disminuye en uno el contador total de actividades en la lista.
                    Cantidad--;
                    // Retorna true confirmando que el nodo fue eliminado con éxito.
                    return true;
                }

                // Actualiza el puntero anterior al nodo actual antes de avanzar.
                anterior = actual;
                // Avanza el puntero actual al siguiente nodo de la lista.
                actual = actual.Siguiente;
            }

            // Retorna false si se recorrió toda la lista y no se encontró el ID a eliminar.
            return false;
        }

        // Método público que convierte los nodos de la lista enlazada en un arreglo estático de actividades.
        public Actividad[] ObtenerTodas()
        {
            // Crea un arreglo con capacidad exacta para la cantidad de actividades almacenadas.
            Actividad[] resultado = new Actividad[Cantidad];
            // Inicia el puntero auxiliar en la cabeza de la lista.
            NodoActividad actual = cabeza;
            // Inicializa el índice de posición para ir llenando el arreglo.
            int i = 0;

            // Recorre todos los nodos de la lista hasta llegar a null.
            while (actual != null)
            {
                // Almacena la actividad del nodo actual en el arreglo e incrementa el índice.
                resultado[i++] = actual.Actividad;
                // Avanza al siguiente nodo de la lista.
                actual = actual.Siguiente;
            }

            // Devuelve el arreglo completo con todas las actividades registradas.
            return resultado;
        }
    }
}