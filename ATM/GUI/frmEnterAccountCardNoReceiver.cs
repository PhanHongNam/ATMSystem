using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BULs;
using DTOs;

namespace ATM.GUI
{
    public partial class frmEnterAccountCardNoReceiver : Form
    {
        private CashTransferTransaction _cash;
        private frmMain _parent;
        private string _transferString;
        private string _accountCardReceiverString;
        List<Button> _buttons;
        CashTransferBUL transferBUL = new CashTransferBUL();
        AccountDTO accountDTO = new AccountDTO();
        public frmEnterAccountCardNoReceiver()
        {
            InitializeComponent();
        }

        public frmEnterAccountCardNoReceiver(frmMain home, CashTransferTransaction cash)
        {
            InitializeComponent();
            _cash = cash;
            _parent = home;
            SetLabelsString();
            SetTextForLabels();
            AddNumberButon();
            SetNumberHandle();
        }

        private void SetLabelsString()
        {
            if (_cash.TransferService == 0)
            {
                _transferString = "Xin Qúy khách nhập số tài khoản thụ hưởng";
                _accountCardReceiverString = "Số tài khoản thụ hưởng:";
            }
            else if (_cash.TransferService == 1)
            {
                _transferString = "Xin Qúy khách nhập số thẻ thụ hưởng";
                _accountCardReceiverString = "Số thẻ thụ hưởng:";
            }
                
        }

        private void SetTextForLabels()
        {
            accountDTO = transferBUL.GetAccountInfoByCardNo(_cash.SenderCardNo);
            _cash.SenderAccountNo = accountDTO.AccountNo;
            lblEnterAccountCardNoReceiver.Text = _transferString;
            lblAccountCardNoReceiver.Text = _accountCardReceiverString;
            lblAccountCardNo.Text = _cash.SenderAccountNo;
        }

        private void AddNumberButon()
        {
            _buttons = new List<Button>();
            _buttons.Add(btnNumZero);
            _buttons.Add(btnNumOne);
            _buttons.Add(btnNumTwo);
            _buttons.Add(btnNumThree);
            _buttons.Add(btnNumFour);
            _buttons.Add(btnNumFive);
            _buttons.Add(btnNumSix);
            _buttons.Add(btnNumSeven);
            _buttons.Add(btnNumEight);
            _buttons.Add(btnNumNine);
        }

        private void SetNumberHandle()
        {
            foreach (Button button in _buttons)
                button.Click += btnNum_Click;
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            if (txtReceiverAccountCardNo.TextLength <= 19)
                txtReceiverAccountCardNo.Text = 
                    txtReceiverAccountCardNo.Text + ((Button)sender).Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (txtReceiverAccountCardNo.TextLength >= 1)
                txtReceiverAccountCardNo.Text =
                    txtReceiverAccountCardNo.Text.Substring(0, 
                       txtReceiverAccountCardNo.TextLength - 1);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtReceiverAccountCardNo.Text))
            {
                if (_cash.TransferService == 0)
                    _cash.ReceiverAccountNo = txtReceiverAccountCardNo.Text;
                else
                    _cash.ReceiverCardNo = txtReceiverAccountCardNo.Text;
                frmChooseAmountOfMoney fcaom =
                    new frmChooseAmountOfMoney(_parent,
                                                _cash);
                this.Close();
                fcaom.Show();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            _parent.Show();
        }

        private void frmEnterAccountCardNoReceiver_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.Show();
        }

        private void frmEnterAccountCardNoReceiver_Shown(object sender, EventArgs e)
        {
            if (_parent != null)
                _parent.Hide();
        }
    }
}
