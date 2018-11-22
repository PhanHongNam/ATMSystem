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
    public partial class frmHome : Form
    {
        private CashTransferTransaction ctt = new CashTransferTransaction();
        public frmHome()
        {
            InitializeComponent();
            ctt.ATMId = "206829d2-b074-46dd-ace2-f9804d9d1b0b";
            ctt.SenderCardNo = "9704180090222498";
        }

        private void btnLeftTwo_Click(object sender, EventArgs e)
        {
            
            frmChooseCashTranferMethod fcctm = new frmChooseCashTranferMethod(this, this.GetCashTransferTransaction());
            fcctm.Show();
            this.Hide();
        }

        public CashTransferTransaction GetCashTransferTransaction()
        {
            return this.ctt;
        }
    }
}
