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
               return DB.LoadData("SELECT * FROM [Executors]");
        }
        public static bool AddExecutor(string name)
        {
            string query = $"INSERT INTO [Executors] (Name) VALUES ('{name}')";
            return DB.Execute(query);
        }
        public static bool UpdateExecutor(string id, string name)
        {
            string query = $"UPDATE [Executors] SET Name = '{name}' WHERE id = '{id}'";
            return DB.Execute(query);
        }
        public static bool DeleteExecutor(string id)
        {
            string query = $"DELETE FROM [Executors] WHERE id = '{id}'";
            return DB.Execute(query);
        }
    }
}
