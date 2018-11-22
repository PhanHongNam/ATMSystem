using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DALs
{
    public class CashTransferDAL
    {
        public CashTransferDAL() { }
        public SqlConnection GetSqlConnection()
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["ATMConnectionString"].ToString();
            return new SqlConnection(connectionString);
        }
        public AccountDTO GetAccountInfor(string cardNo)
        {
            AccountDTO accountDTO = new AccountDTO();
            SqlConnection connection = GetSqlConnection();
            connection.Open();
            string sqlQuery = "select * from Account " +
                "where AccountId=(select AccountId from Card " +
                "where CardNo=@cardNo)";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("cardNo", cardNo);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                accountDTO.AccountId = reader[0].ToString();
                accountDTO.AccountNo = reader[1].ToString();
                accountDTO.Balance = double.Parse(reader[2].ToString());
                accountDTO.CustId = reader[3].ToString();
                accountDTO.ODId = reader[4].ToString();
                accountDTO.WDId = reader[5].ToString();
            }
            return accountDTO;
        }

        public CustomerDTO GetCustomerInfor(string accountCardNo, int type)
        {
            CustomerDTO customerDTO = new CustomerDTO();
            SqlConnection connection = GetSqlConnection();
            connection.Open();
            string sqlQuery = "";
            if (type == 0)
                sqlQuery = "select * from Customer " +
                "where CustId=(select CustId from Account " +
                "where AccountNo=@accountCardNo)";
            else if (type == 1)
                sqlQuery = "select * from Customer " +
                "where CustId=(select CustId from Account " +
                "where AccountId=(select AccountId from Card " +
                "where CardNo=@accountCardNo))";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("accountCardNo", accountCardNo);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                customerDTO.CustId = reader[0].ToString();
                customerDTO.Name = reader[1].ToString();
                customerDTO.Email = reader[2].ToString();
                customerDTO.Phone = reader[3].ToString();
                customerDTO.Addr = reader[4].ToString();
            }

            return customerDTO;
        }
    }
}
