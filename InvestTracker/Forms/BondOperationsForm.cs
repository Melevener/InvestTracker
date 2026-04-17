using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestTracker.Forms
{
    public partial class BondOperationsForm : Form
    {
        public BondOperationsForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Открывается форма для добавления новой операции");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewBondOperations.SelectedRows.Count == 0)
                MessageBox.Show("Сначала нужно выбрать строку в таблице!",
                                "Предупреждение",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            else
                MessageBox.Show("Редактируем выбранную операцию");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewBondOperations.Rows.Count == 0)
                MessageBox.Show("Невозможно удалить строку в пустой таблице!",
                                "Предупреждение",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            else
                MessageBox.Show("Удаляем выбранную операцию");
        }
    }
}
