using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESDAPPER
{
    [Table("tEye")]
    class Eye
    {
        [Key]
        public int ID { get; set; }
        [Computed]
        public Client Cliente { get; set ; }
        public string NIF { get{
            return Cliente.NIF; } set{} }
        public DateTime Consulta { get; set; }
        public double OdEsfera { get; set; }
        public double OdCilindro { get; set; }
        public double OdAdicion { get; set; }
        public double OdAgudeza { get; set; }
        public double OiEsfera { get; set; }
        public double OiCilindro { get; set; }
        public double OiAdicion { get; set; }
        public double OiAgudeza { get; set; }
    }
}
