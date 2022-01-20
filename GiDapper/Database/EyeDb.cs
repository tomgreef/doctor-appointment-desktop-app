using Dapper;
using Dommel;
using System.Collections.Generic;

namespace GiDapper.Database
{
    public class EyeDb : Db<Eye>
    {
        public List<Eye> GetByNif(string nif) => Query(c => c.From<Eye>(sql => sql.Where(e => e.NIF == nif).Select())).AsList();
    }
}
