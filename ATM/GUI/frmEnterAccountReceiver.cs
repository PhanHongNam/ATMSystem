using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using BULs;

namespace ATM.GUI
{
    public partial class frmEnterAccountReceiver : Form
    {
        frmMain _parent;
        CashTransferTransaction _cash;
        List<Button> _buttons;
        CashTransferBUL transferBUL = new CashTransferBUL();
        AccountDTO accountDTO = new AccountDTO();
        public frmEnterAccountReceiver()
        {
            InitializeComponent();
        }

        public frmEnterAccountReceiver(frmMain home, CashTransferTransaction cash)
        {
            InitializeComponent();
            this._parent = home;
            _cash = cash;
            
            accountDTO = transferBUL.GetAccountInfoByCardNo(_cash.SenderCardNo);
            _cash.SenderAccountNo = accountDTO.AccountNo;
            _cash.SenderOverDraftId = accountDTO.ODId;
            lblAccountSendNo.Text = accountDTO.AccountNo;
            AddNumberButon();
            SetNumberHandle();
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
            if (txtAccountReceiverNo.TextLength <= 19)
                txtAccountReceiverNo.Text =
                    txtAccountReceiverNo.Text + ((Button)sender).Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (txtAccountReceiverNo.TextLength >= 1)
            {
                txtAccountReceiverNo.Text =
                    txtAccountReceiverNo.Text.Substring(0, 
                        txtAccountReceiverNo.TextLength - 1);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _parent.Show();
            this.Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAccountReceiverNo.Text))
            {
                _cash.ReceiverAccountNo = txtAccountReceiverNo.Text;
                frmChooseAmountOfMoney fcaom = new frmChooseAmountOfMoney(_parent, _cash);
                this.Close();
                fcaom.Show();
            }
        }

        private void frmEnterAccountReceiver_Load(object sender, EventArgs e)
        {
            if (_parent != null)
                _parent.Hide();
        }

        private void frmEnterAccountReceiver_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.Show();
        }
    }
}
