namespace PackMyTripBackEnd.Entidades
{
    public class UsuarioXPaqueteTuristico
    {
        public int id { get; set; }
        public string? correoUsuario { get; set; }
        public int idPaquete { get; set; }
        public int calificacion { get; set; }
        public string? comentarios { get; set; }
        public byte[]? comprobante { get; set; }
        
    }
}