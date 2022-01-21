using Dapper;

namespace GiDapper.Database
{
    public class ClientDb : Db<Client>
    {
        public void Update(string nif, Client client) =>
            Query(c => 
            c.Execute(
                "UPDATE tClient SET nif = @NIF, nombre = @Nombre, apellidos = @Apellidos, edad = @Edad WHERE NIF = @Id",
                param: new CUpdate(client.NIF, client.Nombre, client.Apellidos, client.Edad, nif)));

        public void Insert(Client client) =>
            Query(c =>
            c.Execute(
                "INSERT INTO tClient (nif, nombre, apellidos, edad) VALUES (@NIF, @Nombre, @Apellidos, @Edad)",
                param: new CInsert(client.NIF, client.Nombre, client.Apellidos, client.Edad)));
    }

    internal record CUpdate(string NIF, string Nombre, string Apellidos, int Edad, string Id);
    internal record CInsert(string NIF, string Nombre, string Apellidos, int Edad);
}
