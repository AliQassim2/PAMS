using System.Data;
using Microsoft.Data.SqlClient;

namespace PAMS
{
    static internal class DB
    {
        private static readonly string ServerName = "AliQassim";
        private static readonly string DatabaseName = "PAMS";

        private static readonly string ConnectionString =
            $@"Data Source={ServerName};Initial Catalog={DatabaseName};Integrated Security=True;TrustServerCertificate=True";

        /// <summary>
        /// Creates and returns a SqlConnection using the configured connection string.
        /// </summary>
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Tests the database connection.
        /// </summary>
        public static void TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Cannot connect to the database.\nError: {ex.Message}",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        /// <summary>
        /// Loads data into a DataTable using a SELECT query.
        /// </summary>
        public static DataTable LoadData(string query)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Executes a non-query SQL command (INSERT, UPDATE, DELETE).
        /// </summary>
        public static bool Execute(string query)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Foreign key violation
                {
                    MessageBox.Show("لا يمكن حذف هذا المشروع لأنه مرتبط ببيانات أخرى.", "خطأ في الحذف", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if a record exists (true/false) using a SELECT query.
        /// </summary>
        public static bool Exists(string query)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            return reader.Read(); // true if data found
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Check Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
