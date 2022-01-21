using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GiDapper.Database
{
    public class ClientDb
    {
        private readonly string _connectionString = Settings.Default.ConnectionString;

        public void Update(string nif, Client client)
        {
            string sql = "UPDATE tClient SET nif = @NIF, nombre = @Nombre, apellidos = @Apellidos, edad = @Edad WHERE NIF = @Id";
            using SqlConnection c = new(_connectionString);
            c.Execute(sql, param: new { client.Nif, client.Nombre, client.Apellidos, client.Edad, Id = nif });
        }

        public void Create(Client client)
        {
            string sql = "INSERT INTO tClient VALUES(@NIF, @Nombre, @Apellidos, @Edad)";
            using SqlConnection c = new(_connectionString);
            c.Execute(sql, param: client);
        }

        public void Delete(Client client)
        {
            string sql = "DELETE FROM tClient WHERE NIF = @NIF";
            using SqlConnection c = new(_connectionString);
            c.Execute(sql, param: new { client.Nif });

        }

        public Client GetById(string id)
        {
            string sql = "SELECT * FROM tClient WHERE NIF = @NIF";
            using SqlConnection c = new(_connectionString);
            return c.QueryFirstOrDefault<Client>(sql, param: new { NIF = id });
        }

        public IEnumerable<Client> GetAll()
        {
            string sql = "SELECT * FROM tClient";
            using SqlConnection c = new(_connectionString);
            return c.Query<Client>(sql);
        }
    }
}
