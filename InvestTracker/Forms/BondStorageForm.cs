using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace InvestTracker.Forms
{
    public partial class BondStorageForm : Form
    {
        public BondStorageForm()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadBondsData();
        }

        private void dataGridViewBonds_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridViewBonds.Rows[e.RowIndex];

            string name = row.Cells["colName"].Value?.ToString();
            string isin = row.Cells["colIsin"].Value?.ToString();

            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(isin))
            {
                string sql = @"
                    INSERT INTO bonds (name, isin) 
                    VALUES (@name, @isin) 
                    ON CONFLICT (isin) 
                    DO UPDATE SET name = EXCLUDED.name;";

                Npgsql.NpgsqlParameter[] ps = {
                    new Npgsql.NpgsqlParameter("@name", name),
                    new Npgsql.NpgsqlParameter("@isin", isin.ToUpper())
                };

                DataBaseHelper.ExecuteNonQuery(sql, ps);
            }
        }

        #region Добавление облигации
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridViewBonds.Rows.Add();

            dataGridViewBonds.CurrentCell = dataGridViewBonds.Rows[rowIndex].Cells["colName"];
            dataGridViewBonds.Focus();
            dataGridViewBonds.BeginEdit(true);
        }
        #endregion
        #region Удаление облигации
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewBonds.CurrentRow != null)
            {
                string bondName = dataGridViewBonds.CurrentRow.Cells["colName"].Value?.ToString() ?? "эту запись";

                var confirm = MessageBox.Show($"Вы уверены, что хотите удалить {bondName}?",
                                              "Подтверждение",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    string isin = dataGridViewBonds.CurrentRow.Cells["colIsin"].Value.ToString();
                    string sql = "DELETE FROM bonds WHERE isin = @isin";

                    NpgsqlParameter[] ps = { new NpgsqlParameter("@isin", isin) };
                    DataBaseHelper.ExecuteNonQuery(sql, ps);

                    dataGridViewBonds.Rows.Remove(dataGridViewBonds.CurrentRow);
                    dataGridViewBonds.Focus();
                }
            }
            else
                MessageBox.Show("Пожалуйста, выберите существующую строку для удаления!",
                                "Предупреждение",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
        }
        #endregion
        #region Пользовательские методы
        private void LoadBondsData()
        {
            string sql = "SELECT name, isin FROM bonds ORDER BY name";
            DataTable dt = DataBaseHelper.ExecuteQuery(sql);

            dataGridViewBonds.Rows.Clear();

            foreach (DataRow dr in dt.Rows)
                dataGridViewBonds.Rows.Add(dr["name"], dr["isin"]);
        }
        private void SetupDataGridView()
        {
            var dgv = dataGridViewBonds;
            dgv.Columns.Clear();

            dgv.AllowUserToAddRows = false;            
            dgv.RowHeadersVisible = false;           
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.MultiSelect = false;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ScrollBars = ScrollBars.Vertical;

            /* Колонка "Название" */
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "Название облигации",
                Width = 233,
                MinimumWidth = 233,                   
                ReadOnly = false,                     
                SortMode = DataGridViewColumnSortMode.Automatic
            });

            /* Колонка "ISIN-код" */
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIsin",
                HeaderText = "ISIN-код",
                Width = 105,
                MinimumWidth = 105,                   
                MaxInputLength = 12,                  
                SortMode = DataGridViewColumnSortMode.Automatic
            });

            dgv.CellFormatting += (s, e) =>
            {
                if (dgv.Columns[e.ColumnIndex].Name == "colIsin" && e.Value != null)
                {
                    e.Value = e.Value.ToString().ToUpper();
                    e.FormattingApplied = true;
                }
            };
            dgv.CellEndEdit += dataGridViewBonds_CellEndEdit;
        }
        #endregion
    }
}
