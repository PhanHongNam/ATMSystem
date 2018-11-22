/*
 * 
 * ATM System Project
 * Authors: 
 *  + Phan Hong Nam(Demons)
 *  + Ngo Van Son
 *  + Nguyen Huyen Trang
 *  + Vu Van Dung
 * Univestity: Ha Noi Univesity Of Industry
 * Account Database Object
 * 
*/

namespace DTOs
{
    public class AccountDTO
    {
        private string _accountId;
        private string _accountNo;
        private double _balance;
        private string _custId;
        private string _oDId;
        private string _wDId;

        public AccountDTO() { }
             
        public AccountDTO(string accountId, string accountNo, double balance, 
                            string custId, string oDId, string wDId)
        {
            AccountId = accountId;
            AccountNo = accountNo;
            Balance = balance;
            CustId = custId;
            ODId = oDId;
            WDId = wDId;
        }

        public string AccountId { get => _accountId; set => _accountId = value; }
        public string AccountNo { get => _accountNo; set => _accountNo = value; }
        public double Balance { get => _balance; set => _balance = value; }
        public string CustId { get => _custId; set => _custId = value; }
        public string ODId { get => _oDId; set => _oDId = value; }
        public string WDId { get => _wDId; set => _wDId = value; }
    }
}
