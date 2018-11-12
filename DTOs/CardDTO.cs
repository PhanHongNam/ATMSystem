/*
 * 
 * ATM System Project
 * Authors: 
 *  + Phan Hong Nam(Demons)
 *  + Ngo Van Son
 *  + Nguyen Huyen Trang
 *  + Vu Van Dung
 * Univestity: Ha Noi Univesity Of Industry
 * Card Database Object
 * 
*/

using System;

namespace DTOs
{
    public class CardDTO
    {
        private string _cardNo;
        private string _pIN;
        private string _status;
        private DateTime _startDate;
        private DateTime _expiredDate;
        private string _accountId;
        private int _attempt;

        public CardDTO() { }

        public CardDTO(string cardNo, string pIN, string status, DateTime startDate, 
                        DateTime expiredDate, string accountId, int attempt)
        {
            CardNo = cardNo;
            PIN = pIN;
            Status = status;
            StartDate = startDate;
            ExpiredDate = expiredDate;
            AccountId = accountId;
            Attempt = attempt;
        }

        public string CardNo { get => _cardNo; set => _cardNo = value; }
        public string PIN { get => _pIN; set => _pIN = value; }
        public string Status { get => _status; set => _status = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime ExpiredDate { get => _expiredDate; set => _expiredDate = value; }
        public string AccountId { get => _accountId; set => _accountId = value; }
        public int Attempt { get => _attempt; set => _attempt = value; }
    }
}
