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
    }
}
