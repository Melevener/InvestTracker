using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestTracker.Forms
{
    public partial class BondOperationsForm : Form
    {
        public BondOperationsForm()
        {
            InitializeComponent();
            SetupDataGridView();
        }
        private void dataGridViewBondOperations_SizeChanged(object sender, EventArgs e)
        {
            tableLayoutPanel1.Width = dataGridViewBondOperations.Width;
            tableLayoutPanel1.Left = dataGridViewBondOperations.Left;
        }

        #region Добавление операции
        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Открывается форма для добавления новой операции");
        }
        #endregion
        #region Изменение операции
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
        #endregion
        #region Удаление операции
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewBondOperations.CurrentRow != null)
            {
                string bondName = dataGridViewBondOperations.CurrentRow.Cells["colName"].Value?.ToString() ?? "эту операцию";

                var confirm = MessageBox.Show($"Вы уверены, что хотите удалить {bondName}?",
                                              "Подтверждение",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    dataGridViewBondOperations.Rows.Remove(dataGridViewBondOperations.CurrentRow);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите существующую строку для удаления!",
                                "Предупреждение",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
        #endregion
        #region Пользовательские методы
        private void SetupDataGridView()
        {
            var dgv = dataGridViewBondOperations;
            dgv.Columns.Clear();

            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ScrollBars = ScrollBars.Vertical;

            /* Колонка "Дата операции" */
            dgv.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "colDate", 
                HeaderText = "Дата", 
                Width = 120 
            });
            /* Колонка "Название облигации" */
            dgv.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "colName", 
                HeaderText = "Название",
                Width = 250 
            });
            /* Колонка "Количество купленных облигаций" */
            dgv.Columns.Add(new DataGridViewTextBoxColumn { 
                Name = "colCount", 
                HeaderText = "Кол-во", 
                Width = 80 
            });
            /* Колонка "Цена за 1 облигацию" */
            dgv.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "colPrice", 
                HeaderText = "Цена за шт.", 
                Width = 140 
            });
            /* Колонка "Комиссия" */
            dgv.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "colComission",
                HeaderText = "Комиссия",
                Width = 100 
            });
            /* Колонка "НКД" */
            dgv.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "colNkd", 
                HeaderText = "НКД", 
                Width = 90 
            });
            /* Колонка "Общая сумма операции" */
            dgv.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "colSum", 
                HeaderText = "Сумма", 
                Width = 170 
            });

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.MinimumWidth = col.Width;
            }
        }
        #endregion
    }
}
