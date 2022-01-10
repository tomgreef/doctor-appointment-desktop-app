using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using System.Data.SqlClient;

namespace GESDAPPER
{
    [Table("tClient")]
    class Client
    {
        [Key]
        public string NIF { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
    }
}
