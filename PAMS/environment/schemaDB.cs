using Microsoft.Data.SqlClient;
using PAMS.Models;
using System.IO;
using System.Text.RegularExpressions;

namespace PAMS.environment
{
    internal static class schemaDB
    {
        private static readonly string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "schema.sql");
        private static readonly string serverName = AppConfig.ServerName;
        private static readonly string dbName = AppConfig.DatabaseName;
        public static void InitializeDatabase()
        {
            if (!DatabaseExists())
            {
                CreateDatabase();
                ExecuteSqlScript();
                AlterCollation();
                AddAdmin();
            }
        }


        public static bool DatabaseExists()
        {
            string connectionString = $@"Data Source={serverName};Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = $"SELECT COUNT(*) FROM sys.databases WHERE name = '{dbName}'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static void CreateDatabase()
        {
            string connectionString = $@"Data Source={serverName};Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = $"CREATE DATABASE [{dbName}]";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void AlterCollation()
        {
            string connectionString = $@"Data Source={serverName};Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = $@"
ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
ALTER DATABASE [{dbName}] COLLATE Arabic_100_CS_AI;
ALTER DATABASE [{dbName}] SET MULTI_USER;
";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ExecuteSqlScript()
        {
            string connectionString = $@"Data Source={serverName};Initial Catalog={dbName};Integrated Security=True;TrustServerCertificate=True";
            string script = File.ReadAllText(scriptPath);

            // Split by GO
            var commands = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (string command in commands)
                {
                    string trimmed = command.Trim();
                    if (!string.IsNullOrEmpty(trimmed))
                    {
                        using (SqlCommand cmd = new SqlCommand(trimmed, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        public static void AddAdmin()
        {
            UserModel.AddUser(
                name: "Admin",
                username: "admin",
                password: "admin",
                type: "0",
                whoAdded: null
            );
        }

    }
}
