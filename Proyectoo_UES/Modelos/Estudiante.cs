// Define el espacio de nombres correspondiente a las clases de modelo del proyecto.
namespace Proyectoo_UES.Modelos
{
    // Declara la clase pública Estudiante que almacena la información básica de un alumno.
    public class Estudiante
    {
        // Propiedad de solo lectura que almacena el código de carné del estudiante.
        public string Carnet { get; }
        // Propiedad de solo lectura que almacena el nombre completo del estudiante.
        public string Nombre { get; }

        // Constructor que recibe y asigna el carné y el nombre al instanciar un estudiante.
        public Estudiante(string carnet, string nombre)
        {
            // Asigna el parámetro carnet a la propiedad Carnet.
            Carnet = carnet;
            // Asigna el parámetro nombre a la propiedad Nombre.
            Nombre = nombre;
        }

        // Sobrescribe el método ToString para devolver una representación combinada de carné y nombre.
        public override string ToString()
        {
            // Retorna una cadena con formato concatenando el carné y el nombre del estudiante.
            return $"{Carnet} - {Nombre}";
        }
    }
}