/*
 * 
 * ATM System Project
 * Authors: 
 *  + Phan Hong Nam(Demons)
 *  + Ngo Van Son
 *  + Nguyen Huyen Trang
 *  + Vu Van Dung
 * Univestity: Ha Noi Univesity Of Industry
 * Log Database Object
 * 
*/


using System;

namespace DTOs
{
    public class LogDTO
    {
        private string _logId;
        private DateTime _logDate;
        private int _amount;
        private string _details;
        private string _logTypeId;
        private string _aTMId;
        private string _cardNo;
        private string _cardNoTo;

        public LogDTO() { }

        public LogDTO(string logId, DateTime logDate, int amount, string details, 
                        string logTypeId, string aTMId, string cardNo, string cardNoTo)
        {
            LogId = logId;
            LogDate = logDate;
            Amount = amount;
            Details = details;
            LogTypeId = logTypeId;
            ATMId = aTMId;
            CardNo = cardNo;
            CardNoTo = cardNoTo;
        }

        public string LogId { get => _logId; set => _logId = value; }
        public DateTime LogDate { get => _logDate; set => _logDate = value; }
        public int Amount { get => _amount; set => _amount = value; }
        public string Details { get => _details; set => _details = value; }
        public string LogTypeId { get => _logTypeId; set => _logTypeId = value; }
        public string ATMId { get => _aTMId; set => _aTMId = value; }
        public string CardNo { get => _cardNo; set => _cardNo = value; }
        public string CardNoTo { get => _cardNoTo; set => _cardNoTo = value; }
    }
}
