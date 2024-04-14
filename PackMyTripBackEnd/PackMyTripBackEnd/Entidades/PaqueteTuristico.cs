using System.ComponentModel.DataAnnotations;

namespace PackMyTripBackEnd.Entidades
{
    public class PaqueteTuristico
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public DateTime fechaHora { get; set; }
        public float? precio { get; set; }
        public byte[]? portada { get; set; }
    }
}