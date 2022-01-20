using Dapper;

namespace GiDapper.Database
{
    public class ClientDb : Db<Client>
    {
        public void Update(string nif, Client client) =>
            Query(c => 
            c.Execute(
                "UPDATE tClient SET nif = @NIF, nombre = @Nombre, apellidos = @Apellidos, edad = @Edad WHERE NIF = @Id",
                param: new C(client.NIF, client.Nombre, client.Apellidos, client.Edad, nif)));
    }

    internal record C(string NIF, string Nombre, string Apellidos, int Edad, string Id);
}
