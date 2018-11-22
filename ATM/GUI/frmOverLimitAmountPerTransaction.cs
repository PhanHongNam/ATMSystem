using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace ATM.GUI
{
    public partial class frmOverLimitAmountPerTransaction : Form
    {
        frmHome _parent;
        uint _amount;
        public frmOverLimitAmountPerTransaction()
        {
            InitializeComponent();
        }

        public frmOverLimitAmountPerTransaction(frmHome home, uint amount)
        {
            InitializeComponent();
            _parent = home;
            _amount = amount;
        }

        private void frmOverLimitAmountPerTransaction_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_parent != null)
                _parent.Close();
        }

        private void frmOverLimitAmountPerTransaction_Shown(object sender, EventArgs e)
        {
            if (_parent != null)
                _parent.Hide();
            Task task = Task.Run( () => {
                Thread.Sleep(3000);
            });
            task.Wait();
            // this.Close();
        }

        private void frmOverLimitAmountPerTransaction_Load(object sender, EventArgs e)
        {
            string amoutString = _amount.ToString("N");
            string moneyString = amoutString.Substring(0, amoutString.Length - 3);

            string message =
                String.Format("Maximium amount per transaction limit of 50,000,000 VND is exceeded./ " +
                "Số tiền giao dịch {0} VND VND vượt quá hạn mức. " +
                "Hạn mức Số tiền tối đa/giao dịch bằng 50,000,000 VND", moneyString);
            lblMessage.Text = message;
        }
    }
}
