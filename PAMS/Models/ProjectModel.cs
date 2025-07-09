using PAMS.environment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAMS.Models
{
    public class ProjectModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string StartDate { get; set; }
        public string AllocatedAmount { get; set; }
        public string BeneficiaryID { get; set; }
        public string UserID { get; set; }
        public string CreatedAt { get; set; }
        public string BeneficiaryName { get; set; }
        public string UsernameAdded { get; set; }
        public string WhoAdded { get; set; }

        public ProjectModel(string id = "", string name = "", string type = "", string startDate = "", string allocatedAmount = "", string beneficiaryID = "", string userID = "", string createdAt = "")
        {
            Id = id;
            Name = name;
            Type = type;
            StartDate = startDate;
            AllocatedAmount = allocatedAmount;
            BeneficiaryID = beneficiaryID;
            UserID = userID;
            CreatedAt = createdAt;
        }

        public ProjectModel(string ProjectID)
        {
            DataTable data = DB.LoadData($"select * from infoProjects where ID = {ProjectID}");
            if (data.Rows.Count == 0)
            {
                throw new Exception("Project not found");
            }
            Id = data.Rows[0]["ID"].ToString();
            Name = data.Rows[0]["Name"].ToString();
            Type = data.Rows[0]["Type"].ToString();
            StartDate = data.Rows[0]["StartDate"].ToString();
            AllocatedAmount = StartDate = data.Rows[0]["AllocatedAmount"].ToString();
            BeneficiaryID = data.Rows[0]["BeneficiaryID"].ToString();
            UserID = data.Rows[0]["add_by"].ToString();
            CreatedAt = data.Rows[0]["CreatedAt"].ToString();
            BeneficiaryName = data.Rows[0]["BeneficiaryName"].ToString();
            UsernameAdded = data.Rows[0]["UsernameAdded"].ToString();
            WhoAdded = data.Rows[0]["WhoAdded"].ToString();
        }
        public static DataTable GetAllProjects()
        {
            return DB.LoadData("SELECT * FROM infoProjects");
        }
        public static bool AddProject(ProjectModel project)
        {
            string query = $@"EXEC AddProject '{project.Name}', '{project.Type}', '{project.StartDate}', '{project.AllocatedAmount}','{project.BeneficiaryID}', '{project.UserID}'";
            return DB.Execute(query);
        }
        public static bool UpdateProject(ProjectModel project)
        {
            string query = $@"EXEC UpdateProject
		        @name = '{project.Name}',
		        @type = '{project.Type}',
		        @date = '{project.StartDate}',
		        @amount = '{project.AllocatedAmount}',
		        @benid = '{project.BeneficiaryID}',
		        @Id = '{project.Id}'";
            return DB.Execute(query);
        }
        public static bool DeleteProject(string projectId)
        {
            string query = $"EXEC DeleteProject @Id = '{projectId}'";
            return DB.Execute(query);

        }
    }
}
