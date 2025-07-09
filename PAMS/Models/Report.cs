using PAMS.environment;
using System.Data;

namespace PAMS.Models
{
    public static class Report
    {

        /* 
         type 0 for Get Receipt Vouchers Report
         type 1 for Get Payment Vouchers Report by Project
         type 2 for Get Payment Vouchers Report by Executor
         type * for Get Project Totals Report by beneficiary
         
        */
        public static DataTable ReportData(string fromdate, string todate,int type=-1)
        {
            string query = "";
            if (type == 0)
            {
                query=@$"
                    DECLARE @fromdate DATE = '{fromdate}';
                    DECLARE @todate DATE = '{todate}';
                    SELECT p.Name,t.[Totle amount] FROM Project as p
                        join ReceiptVouchersTotle(@fromdate, @todate) as t on p.ID= t.ProjectID";
            }
            else if(type == 1)
            {
                query = @$"
                    DECLARE @fromdate DATE = '{fromdate}';
                    DECLARE @todate DATE = '{todate}';
                    DECLARE @type TINYINT = 0;
                    SELECT p.Name,t.[Totle amount] FROM Project as p 
                        join dbo.PaymentVouchersTotle(@fromdate, @todate, @type) as t   on t.ID = p.ID;
                ";
            }
            else if (type == -1)
            {
                query = @$"
                    DECLARE @fromdate DATE = '{fromdate}';
                    DECLARE @todate DATE = '{todate}';
                    DECLARE @type TINYINT = 1;
                    SELECT e.name,t.[Totle amount] FROM Executors as e 
	                    join dbo.PaymentVouchersTotle(@fromdate, @todate, @type) as t   on t.ID = e.id;
                ";
            }
            else
            {
                query = @$"
                    DECLARE @fromdate DATE = '{fromdate}';
                    DECLARE @todate DATE = '{todate}';
                    select name,[Totle amount] from Beneficiaries as b 
	                    join ProjectTotle(@fromdate,@todate) as t on t.BeneficiaryID=b.id
                ";
            }
            DataTable data = DB.LoadData(query);
            if(data.Columns.Contains("name"))
            {
                data.Columns["name"].ColumnName = "Name";
            }
            return data;
            
        }
    }
}
