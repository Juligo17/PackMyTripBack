using Org.BouncyCastle.Asn1.Cms;

namespace PackMyTripBackEnd.Entidades
{
    public class ServicioMetricas
    {
        public Servicio? servicio { get; set; }
        public int idServicio { get; set; }
        public float tasaOcupacion { get; set; }
        public TimeSpan? horasPromedio { get; set; }
        public float ingresos { get; set; }
        public float indiceRepeticion { get; set; }
    }
}
