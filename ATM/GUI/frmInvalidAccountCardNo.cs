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
    public partial class frmInvalidAccountCardNo : Form
    {
        frmMain _parent;
        public frmInvalidAccountCardNo()
        {
            InitializeComponent();
        }

        public frmInvalidAccountCardNo(frmMain home)
        {
            InitializeComponent();
            _parent = home;
        }

        private void frmInvalidAccountCardNo_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.Close();
        }

        private void frmInvalidAccountCardNo_Shown(object sender, EventArgs e)
        {
            if (_parent != null)
                _parent.Hide();
            Task task = Task.Run(() =>
            {
                Thread.Sleep(3000);
            });
            task.Wait();
            this.Close();
        }
    }
}
