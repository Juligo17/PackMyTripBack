using Google.Protobuf;

namespace PackMyTripBackEnd.Entidades
{
    public class PaqueteTuristicoXServicio
    {
        public int? id { get; set; }
        public int? idPaquete { get; set; }
        public int? idServicio { get; set; }
        public TimeSpan? tiempoEstancia { get; set; }
    }
}