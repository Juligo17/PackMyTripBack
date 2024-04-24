namespace PackMyTripBackEnd.Entidades
{
    public class Usuario
    {
        public string? correo { get; set; }
        public string? usuario { get; set; }
        public string? contrasenha { get; set; }
        public DateOnly fechaNacimiento { get; set; }
        public float? latitud { get; set; }
        public float? longitud { get; set; }
        public string? region { get; set; }
        public char tipo { get; set; }
        public string? fotoPerfil { get; set; }
        public List<PaqueteTuristico>? listaPaquetes { get; set; }
    }
}
