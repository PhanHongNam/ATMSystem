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
    public partial class frmChooseCashTranferMethod : Form
    {
        private frmMain _parent;
        CashTransferTransaction _cash;
        public frmChooseCashTranferMethod()
        {
            InitializeComponent();
        }

        public frmChooseCashTranferMethod(frmMain home, CashTransferTransaction cash)
        {
            InitializeComponent();
            this._parent = home;
            this._cash = cash;
        }

        private void btnRightOne_Click(object sender, EventArgs e)
        {
            _cash.TransferType = 1;
            frmChooseTypeCashTransferService fctcts = 
                new frmChooseTypeCashTransferService(_parent, _cash);
            this.Close();
            fctcts.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            _parent.Show();
        }

        private void frmChooseCashTranferMethod_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.Show();
        }

        private void btnLeftOne_Click(object sender, EventArgs e)
        {
            _cash.TransferType = 0;
            frmEnterAccountReceiver fctcts = 
                new frmEnterAccountReceiver(_parent, _cash);
            this.Close();
            fctcts.Show();
        }
    }
}
