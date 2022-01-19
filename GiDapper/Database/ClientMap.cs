using Dapper.FluentMap.Dommel.Mapping;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiDapper.Database
{
    public class ClientMap : DommelEntityMap<Client>
    {
        public ClientMap()
        {
            ToTable("tClient");
            Map(c => c.NIF).IsKey().SetGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
