using InvestTracker.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestTracker
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();

        }

        private void btnBond_Click(object sender, EventArgs e)
        {
            BondOperationsForm bondOperationsForm = new BondOperationsForm();
            bondOperationsForm.ShowDialog();
        }

        private void buttonBondStorage_Click(object sender, EventArgs e)
        {
            BondStorageForm bondStorageForm = new BondStorageForm();
            bondStorageForm.ShowDialog();
        }
    }
}
