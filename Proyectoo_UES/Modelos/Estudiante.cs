namespace Proyectoo_UES.Modelos
{
    public class Estudiante
    {
        public string Carnet { get; }
        public string Nombre { get; }

        public Estudiante(string carnet, string nombre)
        {
            Carnet = carnet;
            Nombre = nombre;
        }

        public override string ToString() => $"{Carnet} - {Nombre}";
    }
}
