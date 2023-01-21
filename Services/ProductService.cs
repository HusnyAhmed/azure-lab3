using azure_lab_ch3.Models;
using System.Data.Common;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace azure_lab_ch3.Services
{
    public class ProductService
    {
        private static string db_source = "azurech3db.database.windows.net";
        private static string db_user = "appdbadmin";
        private static string db_password = "P@ssw0rd";
        private static string db_database = "appdb";


        private SqlConnection GetConnection()
        {
            var _builder= new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;


            return new SqlConnection(_builder.ConnectionString);
        }


        public List<Product>    GetProduct()
        {
            List<Product> _product_lst = new List<Product>();
            SqlConnection conn= GetConnection();
            conn.Open();
            string _statement = "SELECT ProductID,ProductName,Quantity from Products";
            SqlCommand _sqlcommand = new SqlCommand(_statement, conn);

            using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Product _product = new Product()
                    {
                        ProductID = _reader.GetInt32(0),
                        ProductName = _reader.GetString(1),
                        Quantity = _reader.GetInt32(2)
                    };

                    _product_lst.Add(_product);
                }
            }
            conn.Close();
            return _product_lst;


        }
    }
}
