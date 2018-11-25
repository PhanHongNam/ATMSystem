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
using System.Threading;

namespace ATM.GUI
{
    public partial class frmChooseAmountOfMoney : Form
    {
        private frmMain _parent;
        private CashTransferTransaction _cash;
        private string _accountCardReceiverString;
        List<Button> _buttons;
        CashTransferBUL transferBUL = new CashTransferBUL();
        public frmChooseAmountOfMoney()
        {
            InitializeComponent();
        }

        public frmChooseAmountOfMoney(frmMain home, CashTransferTransaction cash)
        {
            InitializeComponent();
            this._parent = home;
            this._cash = cash;
            SetLabelsString();
            SetTextForLabels();
            AddNumberButon();
            SetNumberHandle();
        }

        private void SetLabelsString()
        {
            if (_cash.TransferType == 0)
            {
                lblAccountSend.Text = "Tài khoản chuyển tiền";
                _accountCardReceiverString = "Tài khoản nhận tiền";
            }
            else if (_cash.TransferType == 1)
            {
                lblAccountSend.Text = "Tài khoản trích nợ";
                
                if (_cash.TransferService == 0)
                    _accountCardReceiverString = "Số TK thụ hưởng";
                else if (_cash.TransferService == 1)
                    _accountCardReceiverString = "Số thẻ thụ hưởng";
            }

        }

        private void SetTextForLabels()
        {
            lblAccountSendNo.Text = _cash.SenderAccountNo;
            lblAccountCardReceiver.Text = _accountCardReceiverString;
            if (_cash.TransferService == 0)
                lblAccountCardNoReceiver.Text = _cash.ReceiverAccountNo;
            else if (_cash.TransferService == 1)
                lblAccountCardNoReceiver.Text = _cash.ReceiverCardNo;
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
            if (txtAmount.TextLength <= 8)
                txtAmount.Text =
                    txtAmount.Text + ((Button)sender).Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (txtAmount.TextLength >= 1)
                txtAmount.Text =
                    txtAmount.Text.Substring(0, txtAmount.TextLength - 1);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAmount.Text))
            {
                uint amount = 0;
                amount = uint.Parse(txtAmount.Text);
                if (amount == 0)
                    txtAmount.Text = "";
                else if (amount > 50000000)
                {
                    frmOverLimitAmountPerTransaction frmOver =
                        new frmOverLimitAmountPerTransaction(_parent, amount);
                    frmOver.Show();
                    this.Close();
                }
                else
                {
                    _cash.Amount = (int)amount;
                    int getType = _cash.TransferType == 0 ? 0 :
                                   _cash.TransferService;
                    CustomerDTO customerDTO = 
                        transferBUL.GetCustomerInfoByAccountNo(_cash.TransferType == 0 || _cash.TransferService == 0 
                                                                ? _cash.ReceiverAccountNo : _cash.ReceiverCardNo, 
                                                               getType);
                    if (String.IsNullOrEmpty(customerDTO.Name))
                    {
                        frmInvalidAccountCardNo frmInvalid = 
                            new frmInvalidAccountCardNo(_parent);
                        frmInvalid.Show();
                        this.Close();
                    } else
                    {
                        _cash.ReceiverName = customerDTO.Name;
                        frmConfirmCashTransferInfomation frmConfirm =
                            new frmConfirmCashTransferInfomation(_parent, _cash);
                        frmConfirm.Show();
                        this.Close();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            _parent.Show();
        }

        private void frmChooseAmountOfMoney_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.Show();
        }

        private void frmChooseAmountOfMoney_Load(object sender, EventArgs e)
        {
            if (_parent != null)
                _parent.Hide();
        }
    }
}
