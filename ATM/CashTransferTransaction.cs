using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CashTransferTransaction
    {
        readonly private string _id = "Transfer";
        private int _transferType;
        private int _transferService;
        private string _aTMId;
        private int _amount;
        private string _senderAccountId;
        private string _senderCardNo;
        private string _senderAccountNo;
        private double _senderBalance;
        private string _senderOverDraftId;
        private string _receiverAccountCardNo;
        private string _receiverName;
        private double _transferFee;

        public CashTransferTransaction() { }

        public CashTransferTransaction(int transferType, int transferService, string aTMId, 
                                        int amount, string senderAccountId, string senderCardNo, 
                                        string senderAccountNo, double senderBalance, 
                                        string senderOverDraftId, string receiverAccountCardNo, 
                                        string receiverName, double transferFee)
        {
            _transferType = transferType;
            _transferService = transferService;
            _aTMId = aTMId;
            _amount = amount;
            _senderAccountId = senderAccountId;
            _senderCardNo = senderCardNo;
            _senderAccountNo = senderAccountNo;
            _senderBalance = senderBalance;
            _senderOverDraftId = senderOverDraftId;
            _receiverAccountCardNo = receiverAccountCardNo;
            _receiverName = receiverName;
            _transferFee = transferFee;
        }

        public string Id => _id;
        public int TransferType { get => _transferType; set => _transferType = value; }
        public int TransferService { get => _transferService; set => _transferService = value; }
        public string ATMId { get => _aTMId; set => _aTMId = value; }
        public int Amount { get => _amount; set => _amount = value; }
        public string SenderAccountId { get => _senderAccountId; set => _senderAccountId = value; }
        public string SenderCardNo { get => _senderCardNo; set => _senderCardNo = value; }
        public string SenderAccountNo { get => _senderAccountNo; set => _senderAccountNo = value; }
        public double SenderBalance { get => _senderBalance; set => _senderBalance = value; }
        public string SenderOverDraftId { get => _senderOverDraftId; set => _senderOverDraftId = value; }
        public string ReceiverAccountCardNo { get => _receiverAccountCardNo; set => _receiverAccountCardNo = value; }
        public string ReceiverName { get => _receiverName; set => _receiverName = value; }
        public double TransferFee { get => _transferFee; set => _transferFee = value; }

    }
}
