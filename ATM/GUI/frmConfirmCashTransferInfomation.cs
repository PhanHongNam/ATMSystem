using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM.GUI
{
    public partial class frmConfirmCashTransferInfomation : Form
    {
        frmHome _parent;
        CashTransferTransaction _cash;
        public frmConfirmCashTransferInfomation()
        {
            InitializeComponent();
        }

        public frmConfirmCashTransferInfomation(frmHome home, 
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
                lblReceiverAccountCardNo.Text = _cash.ReceiverAccountCardNo;
                lblReceiverName.Text = _cash.ReceiverName;
                lblAmount.Text = _cash.Amount.ToString();
            } else
            {
                lblSendAccount.Text = "Tài khoản trích nợ";
                if (_cash.TransferService == 0)
                    lblReceiverAccountCard.Text = "Số TK thụ hưởng";
                else
                    lblReceiverAccountCard.Text = "Số thẻ thụ hưởng";
                lblSendAccountNo.Text = _cash.SenderAccountNo;
                lblReceiverAccountCardNo.Text = _cash.ReceiverAccountCardNo;
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
            _parent.Show();
        }
    }
}
