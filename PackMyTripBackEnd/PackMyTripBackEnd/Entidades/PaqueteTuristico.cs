using System.ComponentModel.DataAnnotations;

namespace PackMyTripBackEnd.Entidades
{
    public class PaqueteTuristico
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public DateTime fechaHora { get; set; }
        public float? precioDolares { get; set; }
        public string? imagen { get; set; }
        public string? correoIntermediario { get; set; }
        public List<Servicio>? listaServicios { get; set; }
        public int? calificacion { get; set; }
        public string? comentarios { get; set; }
        public string? comprobante { get; set; }
    }
}