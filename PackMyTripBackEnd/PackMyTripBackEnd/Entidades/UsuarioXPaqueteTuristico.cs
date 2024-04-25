namespace PackMyTripBackEnd.Entidades
{
    public class UsuarioXPaqueteTuristico
    {
        public int id { get; set; }
        public string? correoUsuario { get; set; }
        public int idPaquete { get; set; }
    }
}