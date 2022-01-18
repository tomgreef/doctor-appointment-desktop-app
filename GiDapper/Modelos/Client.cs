using Dapper.Contrib.Extensions;

namespace GiDapper
{
    [Table("tClient")]
    public class Client
    {
        [ExplicitKey]
        public string NIF { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
    }
}
