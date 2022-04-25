using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.DataLayer
{
    public class DbContext
    {
        string connectionString = "Server=.\\SQLEXPRESS,49172;Database = Demo;User Id=Sa;Password=allahhelpme;MultipleActiveResultSets=True;";

        public IEnumerable<Customer> GetAllCustomers()
        {
            List<Customer> customerList = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_GetAllCustomers", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    Customer Customer = new Customer();

                    Customer.Age = Convert.ToInt32(dataReader["Age"]);
                    Customer.Name = dataReader["Name"].ToString();
                    Customer.Address = dataReader["Address"].ToString();
                    Customer.Id = Guid.Parse(dataReader["Id"].ToString());
                    customerList.Add(Customer);
                }
                connection.Close();
            }
            return customerList;
        }
   
        public void AddCustomer(Customer Customer)
        {
            Customer.Id = new Guid();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_AddCustomer", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Name", Customer.Name);
                sqlCommand.Parameters.AddWithValue("@Address", Customer.Address);
                sqlCommand.Parameters.AddWithValue("@Id", Customer.Id);
                sqlCommand.Parameters.AddWithValue("@Age", Customer.Age);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpdateCustomer(Customer Customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_UpdateCustomer", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Id", Customer.Id);
                sqlCommand.Parameters.AddWithValue("@Name", Customer.Name);
                sqlCommand.Parameters.AddWithValue("@Address", Customer.Address);
                sqlCommand.Parameters.AddWithValue("@Age", Customer.Age);

                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Customer GetCustomerData(Guid id)
        {
            Customer Customer = new Customer();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand sqlCommand = new SqlCommand("sp_GetCustomerById", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Id", id);
                connection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    Customer.Age = Convert.ToInt32(dataReader["Age"]);
                    Customer.Name = dataReader["Name"].ToString();
                    Customer.Address = dataReader["Address"].ToString();
                    Customer.Id = Guid.Parse(dataReader["Id"].ToString());
                }
            }
            return Customer;
        }

        //To Delete the record on a particular Customer    
        public void DeleteCustomer(Guid id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_DeleteCustomer", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Id", id);

                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public string GenerateGuidSequentially()
        {
            var id = "b4e5652b-be70-41c9-5940-08da237fe46a";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT Count(id) from Customers", connection);
                var i = Convert.ToInt32(sqlCommand.ExecuteScalar());
                i++;
                 id = id +  i ; 
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            return id;
        }
    }
}
