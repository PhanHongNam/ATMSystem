using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CashTransferTransaction
    {
        private int _transferType;
        private int _transferService;
        private string _aTMId;
        private int _amount;
        private string _senderCardNo;
        private string _senderAccountNo;
        private string _senderOverDraftId;
        private string _receiverCardNo;
        private string _receiverAccountNo;
        private string _receiverName;
        private decimal _transferFee;
        private decimal _availBalance;
        private DateTime _logDate;
        private Guid _logId;
        private string _detail;

        public CashTransferTransaction() { }

        public CashTransferTransaction(int transferType, int transferService, 
                                        string aTMId, int amount, 
                                        string senderCardNo, string senderAccountNo, 
                                        string senderOverDraftId, string receiverCardNo, 
                                        string receiverAccountNo, string receiverName, 
                                        decimal transferFee, decimal availBalance, 
                                        DateTime logDate, Guid logId, string detail)
        {
            TransferType = transferType;
            TransferService = transferService;
            ATMId = aTMId;
            Amount = amount;
            SenderCardNo = senderCardNo;
            SenderAccountNo = senderAccountNo;
            SenderOverDraftId = senderOverDraftId;
            ReceiverCardNo = receiverCardNo;
            ReceiverAccountNo = receiverAccountNo;
            ReceiverName = receiverName;
            TransferFee = transferFee;
            AvailBalance = availBalance;
            LogDate = logDate;
            LogId = logId;
            Detail = detail;
        }

        public int TransferType { get => _transferType; set => _transferType = value; }
        public int TransferService { get => _transferService; set => _transferService = value; }
        public string ATMId { get => _aTMId; set => _aTMId = value; }
        public int Amount { get => _amount; set => _amount = value; }
        public string SenderCardNo { get => _senderCardNo; set => _senderCardNo = value; }
        public string SenderAccountNo { get => _senderAccountNo; set => _senderAccountNo = value; }
        public string SenderOverDraftId { get => _senderOverDraftId; set => _senderOverDraftId = value; }
        public string ReceiverCardNo { get => _receiverCardNo; set => _receiverCardNo = value; }
        public string ReceiverAccountNo { get => _receiverAccountNo; set => _receiverAccountNo = value; }
        public string ReceiverName { get => _receiverName; set => _receiverName = value; }
        public decimal TransferFee { get => _transferFee; set => _transferFee = value; }
        public decimal AvailBalance { get => _availBalance; set => _availBalance = value; }
        public DateTime LogDate { get => _logDate; set => _logDate = value; }
        public Guid LogId { get => _logId; set => _logId = value; }
        public string Detail { get => _detail; set => _detail = value; }
    }
}
