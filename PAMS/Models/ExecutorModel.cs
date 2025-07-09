using PAMS.environment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAMS.Models
{
    public class ExecutorModel
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public static DataTable GetAllExecutor()
        {
               return DB.LoadData("SELECT * FROM [PAMS].[dbo].[Executors]");
        }
        public static bool AddExecutor(string name)
        {
            string query = $"INSERT INTO [PAMS].[dbo].[Executors] (name) VALUES ('{name}')";
            return DB.Execute(query);
        }
        public static bool UpdateExecutor(string id, string name)
        {
            string query = $"UPDATE [PAMS].[dbo].[Executors] SET name = '{name}' WHERE id = '{id}'";
            return DB.Execute(query);
        }
        public static bool DeleteExecutor(string id)
        {
            string query = $"DELETE FROM [PAMS].[dbo].[Executors] WHERE id = '{id}'";
            return DB.Execute(query);
        }
    }
}
