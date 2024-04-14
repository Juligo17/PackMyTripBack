namespace PackMyTripBackEnd.Entidades
{
    public class Mensaje
    {
        public int id { get; set; }
        public string? correoUsuario1 { get; set; }
        public string? correoUsuario2 { get; set; }
        public string? mensaje { get; set; }
        public bool enviado{ get; set;}
        public DateTime hora { get; set; }
    }
}