using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dommel;


namespace GiDapper
{
    public class Db<T> where T : class
    {
        private static readonly string _connectionString = Settings.Default.ConnectionString;

        public void Create(T elem) => Query(c => c.Insert<T>(elem));

        public T GetById(string id) => QueryScalar(c => c.Get<T>(id));

        public void Update(T elem) => Query(c => c.Update(elem));

        public void Delete(T elem) => Query(c => c.Delete(elem));

        public IEnumerable<T> GetAll() => Query(c => c.GetAll<T>());

        protected void Query(Action<SqlConnection> predicate)
        {
            using var connection = new SqlConnection(_connectionString);
            predicate(connection);
        }

        protected IEnumerable<T> Query(Func<SqlConnection, IEnumerable<T>> predicate)
        {
            IEnumerable<T> res;
            using (var connection = new SqlConnection(_connectionString))
            {
                res = predicate(connection);
            }

            return res;
        }

        protected T QueryScalar(Func<SqlConnection, T> predicate)
        {
            T res;
            using (var connection = new SqlConnection(_connectionString))
            {
                res = predicate(connection);
            }

            return res;
        }
    }
}
