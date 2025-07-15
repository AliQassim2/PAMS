using PAMS.environment;
using System.Data;

namespace PAMS.Models
{
    public class BeneficiaryModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public static DataTable GetAllBeneficiaries()
        {
            return DB.LoadData("SELECT * FROM Beneficiaries");
        }
        public static bool AddBeneficiary(string name)
        {
           using (AppDbContext context = new AppDbContext())
            {
                BeneficiaryModel beneficiary = new BeneficiaryModel { Name = name };
                context.Beneficiaries.Add(beneficiary);
                return context.SaveChanges() > 0;
            }
        }
        public static bool UpdateBeneficiary(string id, string name)
        {
           using (AppDbContext context = new AppDbContext())
            {
                var beneficiary = context.Beneficiaries.Find(int.Parse(id));
                if (beneficiary != null)
                {
                    beneficiary.Name = name ;
                    return context.SaveChanges() > 0;
                }
                return false;
            }
        }
        public static bool DeleteBeneficiary(string id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var beneficiary = context.Beneficiaries.Find(int.Parse(id));
                if (beneficiary != null)
                {
                    context.Beneficiaries.Remove(beneficiary);
                    return context.SaveChanges() > 0;
                }
                return false;
            }
        }
    }
}
