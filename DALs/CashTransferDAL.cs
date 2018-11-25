using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
                ConfigurationManager.ConnectionStrings["dbATMConnectionString"].ToString();
            return new SqlConnection(connectionString);
        }   
        public AccountDTO GetAccountInfor(string cardNo)
        {
            AccountDTO accountDTO = new AccountDTO();
            SqlConnection connection = GetSqlConnection();
            connection.Open();
            string sqlQuery = "select * from Account " +
                "inner join Card on Card.AccountId = Account.AccountId " +
                "where CardNo = @cardNo";
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
            connection.Close();
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
                "inner join Account on Customer.CustId = Account.CustId " +
                "where AccountNo=@accountCardNo";
            else if (type == 1)
                sqlQuery = "select * from Customer " +
                "inner join Account on Customer.CustId = Account.CustId " +
                "inner join Card on Card.AccountId = Account.AccountId" +
                "where Card.CardNo = @accountCardNo";
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
            connection.Close();
            return customerDTO;
        }

        public void PerformCashTransferTransaction(string atmID, string sendCardNo, 
                                                    string sendAccNo, string sendODID, 
                                                    string receiAccNo, int amount, 
                                                    out int result, out Guid? logId, 
                                                    decimal transferFee, out decimal? availBal)
        {
            SqlConnection connection = GetSqlConnection();
            connection.Open();
            string sqlQuery = "cash_transfer";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("atmID", atmID);
            command.Parameters.AddWithValue("sendCardNo", sendCardNo);
            command.Parameters.AddWithValue("sendAccNo", @sendAccNo);
            command.Parameters.AddWithValue("sendODID", sendODID);
            command.Parameters.AddWithValue("receiAccNo", receiAccNo);
            command.Parameters.AddWithValue("amount", amount);
            command.Parameters.AddWithValue("@transferFee", transferFee);
            SqlParameter resultPara = new SqlParameter("@result", SqlDbType.Int);
            resultPara.Direction = ParameterDirection.Output;
            SqlParameter logIdPara = new SqlParameter("@logID", SqlDbType.UniqueIdentifier);
            logIdPara.Direction = ParameterDirection.Output;
            SqlParameter availBalPara = new SqlParameter("@availBalance", SqlDbType.Money);
            availBalPara.Direction = ParameterDirection.Output;
            command.Parameters.Add(resultPara);
            command.Parameters.Add(logIdPara);
            command.Parameters.Add(availBalPara);
            command.ExecuteNonQuery();
            result = (int)resultPara.Value;
            logId = null;
            availBal = null;
            if (result != 0)
            {
                logId = (Guid)logIdPara.Value;
                availBal = (decimal)availBalPara.Value;
            }
            connection.Close();
        }

        public LogDTO GetTransferLog(Guid logId)
        {
            LogDTO log = new LogDTO();
            SqlConnection connection = GetSqlConnection();
            connection.Open();
            string sqlQuery = "select * from Log where LogID = @logId";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("logId",logId.ToString());
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {
                log.LogId = dataReader[0].ToString();
                log.LogDate = Convert.ToDateTime(dataReader[1].ToString());
                log.Amount = (int)decimal.Parse(dataReader[2].ToString());
                log.Details = dataReader[3].ToString();
                log.LogTypeId = dataReader[4].ToString();
                log.ATMId = dataReader[4].ToString();
                log.CardNo = dataReader[6].ToString();
                log.CardNoTo = dataReader[7].ToString();
            }
            connection.Close();
            return log;
        }
    }
}
