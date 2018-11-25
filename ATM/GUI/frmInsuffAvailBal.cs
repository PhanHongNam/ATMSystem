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

namespace ATM.GUI
{
    public partial class frmInsuffAvailBal : Form
    {
        private frmMain _main;
        public frmInsuffAvailBal()
        {
            InitializeComponent();
        }

        public frmInsuffAvailBal(frmMain main)
        {
            _main = main;
            InitializeComponent();
        }

        private void frmInsuffAvailBal_Shown(object sender, EventArgs e)
        {
            if (_main != null)
            {
                _main.Hide();
            }
            
        }
    }
}
