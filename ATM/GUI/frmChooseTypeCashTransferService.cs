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
    public partial class frmChooseTypeCashTransferService : Form
    {
        private int selectRowIndex = 0;
        List<Label> labels;
        frmHome _parent;
        CashTransferTransaction _cash;
        public frmChooseTypeCashTransferService()
        {
            InitializeComponent();
            AddLabel();
            SetActiveBackgroundForLabel();
        }

        public frmChooseTypeCashTransferService(frmHome parent,
                                                CashTransferTransaction cash)
        {
            InitializeComponent();
            this._cash = cash;
            _parent = parent;
            AddLabel();
            SetActiveBackgroundForLabel();
        }

        private void AddLabel()
        {
            labels = new List<Label>();
            labels.Add(lblTransferToAccount);
            labels.Add(lblTransferToCard);
        }

        private void SetActiveBackgroundForLabel()
        {
            labels[selectRowIndex].BackColor = System.Drawing.Color.Blue;
            labels[selectRowIndex].ForeColor = System.Drawing.Color.White;
            labels[1 - selectRowIndex].BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            labels[1 - selectRowIndex].ForeColor = System.Drawing.Color.Black;
        }

        private void btnRightOne_Click(object sender, EventArgs e)
        {
            if (selectRowIndex == 1)
            {
                selectRowIndex = 0;
                SetActiveBackgroundForLabel();
            }
        }

        private void btnRightTwo_Click(object sender, EventArgs e)
        {
            if (selectRowIndex == 0)
            {
                selectRowIndex = 1;
                SetActiveBackgroundForLabel();
            }
        }

        private void btnRightFour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRightThree_Click(object sender, EventArgs e)
        {
            // _cash.
            _cash.TransferService = selectRowIndex;
            frmEnterAccountCardNoReceiver feacnr =
                new frmEnterAccountCardNoReceiver(_parent, _cash);
            this.Close();
            feacnr.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            _parent.Show();
        }

        private void frmChooseTypeCashTransferService_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.Show();
        }

        private void frmChooseTypeCashTransferService_Shown(object sender, EventArgs e)
        {
            if (_parent != null)
                _parent.Hide();
        }
    }
}
