using System;
using System.Windows.Forms;
using BULs;
using System.Threading;
using System.Threading.Tasks;

namespace ATM.GUI
{
    public partial class frmConfirmCashTransferInfomation : Form
    {
        frmMain _parent;
        CashTransferTransaction _cash;
        CashTransferBUL transferBUL = new CashTransferBUL();
        public frmConfirmCashTransferInfomation()
        {
            InitializeComponent();
        }

        public frmConfirmCashTransferInfomation(frmMain home, 
                                                CashTransferTransaction cash)
        {
            InitializeComponent();
            _parent = home;
            _cash = cash;
            SetLabelAndContentForlabel();
        }

        private void SetLabelAndContentForlabel()
        {
            if (_cash.TransferType == 0)
            {
                lblSendAccount.Text = "Tài khoản chuyển tiền";
                lblReceiverAccountCard.Text = "Tài khoản nhận tiền";
                lblSendAccountNo.Text = _cash.SenderAccountNo;
                lblReceiverAccountCardNo.Text = _cash.ReceiverAccountNo;
                lblReceiverName.Text = _cash.ReceiverName;
                lblAmount.Text = _cash.Amount.ToString();
                if (_cash.Amount < 10000)
                    _cash.TransferFee = 0;
                else if (_cash.Amount < 30000000)
                    _cash.TransferFee = 1000;
                else if (_cash.Amount > 30000000)
                {
                    _cash.TransferFee = 0.0001m * _cash.Amount;
                    if (_cash.TransferFee > 9000)
                        _cash.TransferFee = 9000;
                }
                lblTransactionFee.Text = _cash.TransferFee.ToString("N");
            } else
            {
                lblSendAccount.Text = "Tài khoản trích nợ";
                if (_cash.TransferService == 0)
                    lblReceiverAccountCard.Text = "Số TK thụ hưởng";
                else
                    lblReceiverAccountCard.Text = "Số thẻ thụ hưởng";
                lblSendAccountNo.Text = _cash.SenderAccountNo;
                lblReceiverAccountCardNo.Text = _cash.ReceiverCardNo;
                lblReceiverName.Text = _cash.ReceiverName;
                lblAmount.Text = _cash.Amount.ToString();
            }
        }

        private void frmConfirmCashTransferInfomation_Shown(object sender, EventArgs e)
        {
            if (_parent != null)
                _parent.Hide();
        }

        private void frmConfirmCashTransferInfomation_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_parent != null)
                _parent.Show();
        }

        private async void btnRightThree_Click(object sender, EventArgs e)
        {
            frmPerformingTransaction performingTransaction = new frmPerformingTransaction();
            this.Hide();
            performingTransaction.Show();
            await Task.Delay(3000);
            performingTransaction.Close();
            int result = -1;
            Guid? logId;
            decimal? availBal;
            transferBUL.PerformCashTransferTransaction(_cash.ATMId, _cash.SenderCardNo,
                                                        _cash.SenderAccountNo, _cash.SenderOverDraftId,
                                                        _cash.ReceiverAccountNo, _cash.Amount,
                                                        out result, out logId,
                                                        _cash.TransferFee, out availBal);
            if (result == 0)
            {
                frmInsuffAvailBal insuffAvailBal = new frmInsuffAvailBal(_parent);
                insuffAvailBal.Show();
                await Task.Delay(3000);
                insuffAvailBal.Close();
                frmTransactionFailed transactionFailed = new frmTransactionFailed(_parent);
                transactionFailed.Show();
                await Task.Delay(3000);
                transactionFailed.Close();
                this.Close();
            } else if (result == 1)
            {
                _cash.LogId = (Guid)logId;
                _cash.AvailBalance = (decimal)availBal;
                frmPrintReceipt frmPrintReceipt = new frmPrintReceipt(_parent, _cash);
                this.Close();
                frmPrintReceipt.Show();
            }

        }
    }
}
