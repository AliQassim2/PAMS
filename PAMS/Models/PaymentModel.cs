using PAMS.environment;
using System.Data;

namespace PAMS.Models
{
    public class PaymentModel
    {
        public string Id { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string note { get; set; } // Notes
        public string ProjectId { get; set; }
        public string ExecutorId { get; set; }
        public PaymentModel(string id, string date, string amount, string note, string projectId, string executorId)
        {
            Id = id;
            Date = date;
            Amount = amount;
            this.note = note;
            ProjectId = projectId;
            ExecutorId = executorId;
        }
        public static DataTable GetAllPayments()
        {
            return DB.LoadData("SELECT * FROM [PaymentVouchers]");
        }
        public static bool AddPayment(PaymentModel data)
        {
            return DB.Execute($"EXEC AddPayment '{data.Date}','{data.Amount}','{data.note}','{data.ProjectId}','{data.ExecutorId}'");
        }
        public static bool UpdatePayment(PaymentModel data)
        {
            return DB.Execute($"EXEC UpdatePayment '{data.Date}','{data.Amount}','{data.note}','{data.ProjectId}','{data.ExecutorId}','{data.Id}'");
        }
        public static bool DeletePayment(string id)
        {
            return DB.Execute($"EXEC DeletePayment '{id}'");
        }
    }
}
