using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GiDapper.Database
{
    public class EyeDb
    {
        private readonly string _connectionString = Settings.Default.ConnectionString;

        public void Update(Eye eye)
        {
            string sql = "UPDATE tEye SET " +
                "nif = @Nif, " +
                "consulta = @Consulta, " +
                "od_esfera = @OdEsfera, " +
                "od_cilindro = @OdCilindro, " +
                "od_adicion = @OdAdicion, " +
                "od_agudeza = @OdAgudeza, " +
                "oi_esfera = @OiEsfera, " +
                "oi_cilindro = @OiCilindro, " +
                "oi_adicion = @OiAdicion, " +
                "oi_agudeza = @OiAgudeza " +
                "WHERE id = @Id";
            using SqlConnection c = new(_connectionString);
            c.Execute(sql, param: eye);
        }

        public void Create(Eye eye)
        {
            string sql = "INSERT INTO tEye" +
                "VALUES(@Nif, @Consulta, @OdEsfera, @OdCilindro, @OdAdicion, " +
                "@OdAgudeza, @OiEsfera, @OiCilindro, @OiAdicion, @OiAgudeza)";
            using SqlConnection c = new(_connectionString);
            c.Execute(sql, param: eye);
        }

        public void Delete(Eye eye)
        {
            string sql = "DELETE FROM tEye WHERE id = @Id";
            using SqlConnection c = new(_connectionString);
            c.Execute(sql, param: new { eye.Id });

        }

        public Eye GetById(string id)
        {
            string sql = "SELECT * FROM tEye WHERE id = @Id";
            using SqlConnection c = new(_connectionString);
            return c.QueryFirstOrDefault<Eye>(sql, param: new { Id = id });
        }

        public IEnumerable<Eye> GetByNif(string nif)
        {
            string sql = "SELECT * FROM tEye WHERE nif = @Nif";
            using SqlConnection c = new(_connectionString);
            return c.Query<Eye>(sql, param: new { Nif = nif });
        }

        public IEnumerable<Eye> GetAll()
        {
            string sql = "SELECT * FROM tEye";
            using SqlConnection c = new(_connectionString);
            return c.Query<Eye>(sql);
        }
    }
}
