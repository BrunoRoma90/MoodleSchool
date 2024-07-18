using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Project.ModelsSchool;
using Project.RepositorySchool.RepositorySchoolInterfaces;
using RepositorySchool;

namespace Project.RepositorySchool
{
    public class AddressRepository : IAddressRepository
    {
        //private string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString.ToString();
        private static Generic _generic = new Generic();
        private static string connectionString = _generic.GetConnectionString();
        public DataTable GetAddressById(int id)
        {
            DataTable dt = new DataTable();



            using (SqlConnection con = new SqlConnection(connectionString))
            {


                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Address Where id = @addressId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    //cmd.Parameters.AddWithValue("@addressId", id);
                    cmd.Parameters.Add("@addressId", SqlDbType.Int).Value = id;  //Definimos o formato neste caso é um INT

                    if (con.State != ConnectionState.Open) //Ligação for diferente de aberto Abre
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }// Comando/Instrução/Faz isto

            }
            return dt;
        }

        public DataTable GetAllAddresses()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {


                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Address";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    if (con.State != ConnectionState.Open) //Ligação for diferente de aberto Abre
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }// Comando/Instrução/Faz isto

            }
            return dt;

        }

        //public int InsertNewAddress(Address address)
        //{
        //    int addressId;
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            string query = "INSERT INTO Address(Street, Number, PostalCode, Locale) VALUES(@street, @number, @postalCode, @locale); " + Environment.NewLine;

        //            cmd.CommandText = query;
        //            cmd.Connection = con;

        //            #region Insert query values
        //            cmd.Parameters.Add("@street", SqlDbType.NVarChar).Value = address.Street;
        //            cmd.Parameters.Add("@number", SqlDbType.Int).Value = address.Number;
        //            cmd.Parameters.Add("@postalCode", SqlDbType.NVarChar).Value = address.PostalCode;
        //            cmd.Parameters.Add("@locale", SqlDbType.NVarChar).Value = address.Locale;
        //            #endregion

        //            if (con.State != ConnectionState.Open)
        //                con.Open();
        //            cmd.ExecuteNonQuery();


        //        }

        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            string query = "SELECT IDENT_CURRENT('Address');";

        //            cmd.CommandText = query;
        //            cmd.Connection = con;

        //            if (con.State != ConnectionState.Open)
        //                con.Open();
        //            addressId = Convert.ToInt32(cmd.ExecuteScalar());
        //        }
        //    }
        //    return addressId;
        //}


        public int InsertNewAddress(Address address)
        {
            int addressId;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO Address(Street, Number, PostalCode, Locale) VALUES(@street, @number, @postalCode, @locale); SELECT SCOPE_IDENTITY();" + Environment.NewLine; ;

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@street", SqlDbType.NVarChar).Value = address.Street;
                    cmd.Parameters.Add("@number", SqlDbType.Int).Value = address.Number;
                    cmd.Parameters.Add("@postalCode", SqlDbType.NVarChar).Value = address.PostalCode;
                    cmd.Parameters.Add("@locale", SqlDbType.NVarChar).Value = address.Locale;
                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    addressId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return addressId;
        }

        public void UpdateAddress(Address address)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "UPDATE Address SET Street= @street, Number= @number, PostalCode= @postalCode, Locale= @locale WHERE id = @id " + Environment.NewLine;

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = address.AddressId;
                    cmd.Parameters.Add("@street", SqlDbType.NVarChar).Value = address.Street;
                    cmd.Parameters.Add("@number", SqlDbType.Int).Value = address.Number;
                    cmd.Parameters.Add("@postalCode", SqlDbType.NVarChar).Value = address.PostalCode;
                    cmd.Parameters.Add("@locale", SqlDbType.NVarChar).Value = address.Locale;
                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();


                }
            }

        }

    }
}