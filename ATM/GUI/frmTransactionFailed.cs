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
    public partial class frmTransactionFailed : Form
    {
        frmMain _main;
        public frmTransactionFailed()
        {
            InitializeComponent();
        }

        public frmTransactionFailed(frmMain main)
        {
            InitializeComponent();
            _main = main;
        }

        private void frmTransactionFailed_Shown(object sender, EventArgs e)
        {
            if (_main != null)
                _main.Hide();
        }

        private void frmTransactionFailed_FormClosed(object sender, FormClosedEventArgs e)
        {
            _main.Close();
        }
    }
}
