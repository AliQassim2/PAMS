using PAMS.environment;
using System.Data;

namespace PAMS.Models
{
    public class ReceiptModel
    {
        public string Id { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string Notes { get; set; } // ملاحظات
        public string ProjectId { get; set; }
        public ReceiptModel(string id, string date, string amount, string notes, string projectId)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Notes = notes;
            ProjectId = projectId;
        }
        public static DataTable GetAllReceipts()
        {

            return DB.LoadData("SELECT * FROM [ReceiptVouchers];");
        }
        public static bool AddReceipt(ReceiptModel data)
        {
            return DB.Execute($"EXEC AddReceipt '{data.Date}','{data.Amount}','{data.Notes}','{data.ProjectId}'");
        }
        public static bool UpdateReceipt(ReceiptModel data)
        {
            return DB.Execute($"EXEC UpdateReceipt '{data.Date}','{data.Amount}','{data.Notes}','{data.ProjectId}','{data.Id}'");
        }
        public static bool DeleteReceipt(string id)
        {
            return DB.Execute($"EXEC DeleteReceipt '{id}'");
        }
    }
}
