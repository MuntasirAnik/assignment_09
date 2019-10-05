using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CustomerInfo.Model;

namespace CustomerInfo.Repository
{
    public class CustomerRepository
    {
        public DataTable LoadCustomerCombo()
        {
            string connectionString = @"Server=DESKTOP-LE66CE0; Database= CustomerInfo; Integrated Security= True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string commandString = @"SELECT Id,Districtname FROM Districts";
            SqlCommand sqlCommand = new SqlCommand(commandString,sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;

        }
        public bool AddCustomer(CustomerDistrict customerDistrict )
        {
            bool isAdded = false;

            string connectionString = @"Server=DESKTOP-LE66CE0; Database= CustomerInfo; Integrated Security= True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string commandString = @"INSERT INTO Customers (Code,Name,Address,Contact,District) VALUES ('" + customerDistrict.Code + "','" + customerDistrict.Name + "','" + customerDistrict.Address + "','"+customerDistrict.Contact+"','"+customerDistrict.District+"')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            int isExecuted = sqlCommand.ExecuteNonQuery();
            if(isExecuted >0)
            {
                isAdded = true;
            }
            sqlConnection.Close();
            return isAdded;
        }
        public bool IsCodeExists(CustomerDistrict customerDistrict)
        {
            string connectionString = @"Server=DESKTOP-LE66CE0; Database= CustomerInfo; Integrated Security= True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            bool isExists = false;

            string commandString = @"SELECT Code FROM Customers WHERE Code= '"+customerDistrict.Code+"'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if(dataTable.Rows.Count>0)
            {
                isExists = true;
            }
            sqlConnection.Close();
            return isExists;
        }
        public bool IsContactExists(CustomerDistrict customerDistrict)
        {
            string connectionString = @"Server=DESKTOP-LE66CE0; Database= CustomerInfo; Integrated Security= True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            bool isExists = false;

            string commandString = @"SELECT Contact FROM Customers WHERE Contact= '" + customerDistrict.Contact + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                isExists = true;
            }
            sqlConnection.Close();
            return isExists;
        }

        public DataTable DisplayData()
        {
            string connectionString = @"Server=DESKTOP-LE66CE0; Database= CustomerInfo; Integrated Security= True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string commandString = @"SELECT * FROM Customers";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;

        }
        public bool Update(CustomerDistrict customerDistrict)
        {
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-LE66CE0; Database=CustomerInfo; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //UPDATE Items SET Name =  'Hot' , Price = 130 WHERE ID = 1
                string commandString = @"UPDATE Customers SET Name =  '" + customerDistrict.Name + "' , Address = '" + customerDistrict.Address + "', Contact = '" + customerDistrict.Contact +"' , District = '" + customerDistrict.District + "' WHERE Code = '" + customerDistrict.Code + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }
                //Close
                sqlConnection.Close();


            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }
            return false;
        }

        public DataTable Search(CustomerDistrict customerDistrict)
        {
            DataTable dataTable = new DataTable();
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-LE66CE0; Database=CustomerInfo; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                //string commandString = @"SELECT * FROM Items WHERE Name='" + name + "'";
                string commandString = @"SELECT * FROM Customers WHERE Name='" + customerDistrict.Name + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                //DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);


                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }

            return dataTable;
        }


    }
}
