using Dapper.FluentMap.Conventions;
using Dapper.FluentMap.Dommel.Mapping;
using Dommel;
using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace GiDapper.Database
{
    internal class EyeMap : DommelEntityMap<Eye>
    {
        public EyeMap()
        {
            ToTable("tEye");
            Map(c => c.ID).IsKey();
            Map(c => c.NIF).ToColumn("NIF");
            Map(c => c.OdAdicion).ToColumn("OD_ADICION");
            Map(c => c.OiAdicion).ToColumn("OI_ADICION");
            Map(c => c.OdAgudeza).ToColumn("OD_AGUDEZA");
            Map(c => c.OiAgudeza).ToColumn("OI_AGUDEZA");
            Map(c => c.OdCilindro).ToColumn("OD_CILINDRO");
            Map(c => c.OiCilindro).ToColumn("OI_CILINDRO");
            Map(c => c.OdEsfera).ToColumn("OD_ESFERA");
            Map(c => c.OiEsfera).ToColumn("OI_ESFERA");
        }
    }
}
