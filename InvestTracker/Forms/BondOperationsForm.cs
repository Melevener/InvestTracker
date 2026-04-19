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
            UpdateBondList();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            dataGridViewBondOperations.DataError += (s, e) => { };
            dataGridViewBondOperations.CellClick += dataGridViewBondOperations_CellClick;
            
            dtpDatePicker.ValueChanged += dtpDatePicker_ValueChanged;
            dtpDatePicker.CloseUp += dtpDatePicker_CloseUp;
        }
        private void BondOperationsForm_Enter(object sender, EventArgs e)
        {
            UpdateBondList();
        }
        private void dataGridViewBondOperations_SizeChanged(object sender, EventArgs e)
        {
            tableLayoutPanel1.Width = dataGridViewBondOperations.Width;
            tableLayoutPanel1.Left = dataGridViewBondOperations.Left;
        }
        private void dataGridViewBondOperations_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dataGridViewBondOperations.Rows[e.RowIndex];
            string colName = dataGridViewBondOperations.Columns[e.ColumnIndex].Name;

            if (colName == "colCount" || colName == "colPrice" || colName == "colComission" || colName == "colNkd")
            {
                decimal.TryParse(row.Cells["colCount"].Value?.ToString(), out decimal count);
                decimal.TryParse(row.Cells["colPrice"].Value?.ToString(), out decimal price);
                decimal.TryParse(row.Cells["colComission"].Value?.ToString(), out decimal comm);
                decimal.TryParse(row.Cells["colNkd"].Value?.ToString(), out decimal nkd);

                row.Cells["colSum"].Value = (count * price) + comm + nkd;
            }
        }
        private void dataGridViewBondOperations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewBondOperations.Columns[e.ColumnIndex].Name == "colDate")
            {
                dtpDatePicker.Font = dataGridViewBondOperations.DefaultCellStyle.Font;

                Rectangle rect = dataGridViewBondOperations.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                dtpDatePicker.Size = new Size(rect.Width, rect.Height);

                dtpDatePicker.Location = new Point(
                    rect.X + dataGridViewBondOperations.Left,
                    rect.Y + dataGridViewBondOperations.Top
                );

                dtpDatePicker.BringToFront();
                dtpDatePicker.Visible = true;

                if (DateTime.TryParse(dataGridViewBondOperations.CurrentCell.Value?.ToString(), out DateTime currentVal))
                    dtpDatePicker.Value = currentVal;

                dtpDatePicker.Focus();
            }
            else
            {
                dtpDatePicker.Visible = false;
            }
        }
        private void dtpDatePicker_ValueChanged(object sender, EventArgs e)
        {
            dataGridViewBondOperations.CurrentCell.Value = dtpDatePicker.Value.ToString("dd.MM.yyyy");
        }
        private void dtpDatePicker_CloseUp(object sender, EventArgs e)
        {
            dtpDatePicker.Visible = false;
            dataGridViewBondOperations.Focus();
        }

        #region Добавление операции
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridViewBondOperations.Rows.Add();
            var row = dataGridViewBondOperations.Rows[rowIndex];

            dataGridViewBondOperations.CurrentCell = row.Cells["colDate"];
            dataGridViewBondOperations_CellClick(this, new DataGridViewCellEventArgs(0, rowIndex));
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
                string bondName = dataGridViewBondOperations.CurrentRow.Cells["colBondName"].Value?.ToString() ?? "эту операцию";

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
            dgv.ReadOnly = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
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
            DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
            comboCol.Name = "colBondName";
            comboCol.HeaderText = "Название облигации";
            comboCol.DataPropertyName = "bond_name";
            comboCol.FlatStyle = FlatStyle.Flat;
            comboCol.Width = 250;

            dataGridViewBondOperations.Columns.Insert(1, comboCol);
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
                col.MinimumWidth = col.Width;

            dgv.Columns["colSum"].ReadOnly = true;

            dgv.CellValueChanged += dataGridViewBondOperations_CellValueChanged;
        }

        private void UpdateBondList()
        {
            string sql = "SELECT name FROM bonds ORDER BY name";
            DataTable dt = DataBaseHelper.ExecuteQuery(sql);

            var comboCol = (DataGridViewComboBoxColumn)dataGridViewBondOperations.Columns["colBondName"];

            comboCol.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                comboCol.Items.Add(row["name"].ToString());
            }
        }
        #endregion
    }
}
