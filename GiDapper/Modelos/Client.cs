namespace GiDapper.Modelos
{
    public class Client
    {
        public string Nif { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }

        public override string ToString()
        {
            return this.Nif + ";" + this.Nombre + ";" + this.Apellidos + ";" + this.Edad;
        }
    }
}
