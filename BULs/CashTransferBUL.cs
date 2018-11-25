using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using DALs;

namespace BULs
{
    public class CashTransferBUL
    {
        public CashTransferBUL () { }
        CashTransferDAL transferDAL = new CashTransferDAL();
        public AccountDTO GetAccountInfoByCardNo(string cardNo)
        {
            return transferDAL.GetAccountInfor(cardNo);
        }

        public CustomerDTO GetCustomerInfoByAccountNo(string accountNo, int type)
        {
            return transferDAL.GetCustomerInfor(accountNo, type);
        }

        public void PerformCashTransferTransaction(string atmID, string sendCardNo,
                                                    string sendAccNo, string sendODID,
                                                    string receiAccNo, int amount,
                                                    out int result, out Guid logId,
                                                    decimal transferFee, out decimal availBal)
        {
            transferDAL.PerformCashTransferTransaction(atmID, sendCardNo, sendAccNo, 
                                                        sendODID, receiAccNo,amount, 
                                                        out result, out logId, 
                                                        transferFee, out availBal);
        }

        public LogDTO GetTransferLog(Guid logId)
        {
            return transferDAL.GetTransferLog(logId);
        }
    }
}
