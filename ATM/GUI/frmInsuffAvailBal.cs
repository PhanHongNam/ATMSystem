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
    public partial class frmInsuffAvailBal : Form
    {
        private frmMain _main;
        public frmInsuffAvailBal()
        {
            InitializeComponent();
        }

        public frmInsuffAvailBal(frmMain main)
        {
            InitializeComponent();
            _main = main;
        }
    }
}
