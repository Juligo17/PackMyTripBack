using System.ComponentModel.DataAnnotations;

namespace PackMyTripBackEnd.Entidades
{
    public class Servicio
    {
        public int id { get; set; }
        public string? nombre { get; set; } //El ? indica que acepta valores NULL
        public float precio { get; set; }
        public int limiteDiario { get; set; }
        public string? caracteristicas { get; set; }
        public string? portada { get; set; }
        public DateTime fechaHora { get; set; }
        public string? correoOperador { get; set; }
    }
}
