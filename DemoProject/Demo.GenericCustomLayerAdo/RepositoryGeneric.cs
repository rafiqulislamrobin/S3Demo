using Custom.GenericCustomLayerAdo;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Demo.GenericCustomLayerAdo
{
    public class RepositoryGeneric<TEntity> where TEntity : class
    {
        string connectionString = "Server=.\\SQLEXPRESS,49172;Database = Demo;User Id=Sa;Password=allahhelpme;MultipleActiveResultSets=True;";
        //private readonly ConnectionString _connectionString;

        //public RepositoryGeneric(IOptions<ConnectionString> connectionString)
        //{
        //    _connectionString = connectionString.Value;
        //}

        public void AddCustomer(TEntity entity)
        {
            Type t = typeof(TEntity);
            var properties = t.GetProperties(System.Reflection.BindingFlags.Public
                                             | System.Reflection.BindingFlags.Instance
                                             | System.Reflection.BindingFlags.DeclaredOnly);

            var q = $"Insert into {t.Name}s(";
            foreach (var item in properties)
            {
                var y = item;
                q = q + $"[{item.Name}], ";
            }
            q = q.Remove(q.Length - 2, 1);
            q = q + ")Values(";

            foreach (var item in properties)
            {
                if (item.Name == "Id")
                {
                    var value = Guid.NewGuid();
                    q = q + $"'{value}', ";
                }
                else
                {
                    var value = item.GetValue(entity);
                    q = q + $"'{value}', ";
                }

            }
            q = q.Remove(q.Length - 2, 1);
            q = q + ")";

            //string queryString = "";
           //$"Insert into {nameof(TEntity)}([Id], [Name], [Address], [Age]) Values('{Customer.Id}', '{Customer.Name}', '{Customer.Address}', '{Customer.Age}') ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(q, connection);
                sqlCommand.CommandType = CommandType.Text;
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                sqlCommand.Dispose();
                connection.Dispose();
            }
        }
    }
}