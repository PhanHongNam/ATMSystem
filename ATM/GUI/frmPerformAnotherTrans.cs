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
    public partial class frmPerformAnotherTrans : Form
    {
        frmMain _main;

        public frmPerformAnotherTrans()
        {
            InitializeComponent();
        }

        public frmPerformAnotherTrans(frmMain main)
        {
            _main = main;
            InitializeComponent();
        }

        private void btnRightThree_Click(object sender, EventArgs e)
        {
            this.Close();
            if (_main != null) 
                _main.Show();
        }

        private void btnRightFour_Click(object sender, EventArgs e)
        {
            this.Close();
            if (_main != null)
                _main.Close(); 
        }

        private void frmPerformAnotherTrans_Shown(object sender, EventArgs e)
        {
            if (_main != null)
                _main.Hide();
        }

        private void frmPerformAnotherTrans_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_main != null)
                _main.Show();
        }
    }
}
