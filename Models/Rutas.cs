namespace ApiAppTransporte.Models
{
    public class Rutas
    {
        public int? id;
        public string? nombre;
        public string? descripcion;
        public int? conductorId;
        public Coordenadas? coordenadas;
        public class Coordenadas
        {
            public double? latitud { get; set; }
            public double? longitud { get; set; }

            public Coordenadas()
            {
            }
        }

        public Rutas()
        {
        }

        public Rutas(int? id, string? nombre, string? descripcion, int? conductorId)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.conductorId = conductorId;
        }
    }
}
