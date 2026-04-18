using System;
using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace InvestTracker
{
    public static class DataBaseHelper
    {
        /* Строка подключения */
        private static string connString = "Host=localhost;Username=postgres;Password=root;Database=InvestTrackerDB";

        /* Получение данных */
        public static DataTable ExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                            dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при чтении из БД: " + ex.Message,
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            return dt;
        }

        /* Изменение данных */
        public static void ExecuteNonQuery(string sql, NpgsqlParameter[] parameters = null)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при записи в БД: " + ex.Message);
            }
        }
    }
}
