using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using PAMS.environment;
using System.Data;
using System.Text;

namespace PAMS.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string UserType { get; set; }
        public string CreateAt { get; set; }
        public string WhoAdded { get; set; }

        public UserModel()
        {
            Id = string.Empty;
            Name = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            Type = string.Empty;
            CreateAt = string.Empty;
        }
        public UserModel(string id, string firstName, string username, string password, string type, string createAt)
        {
            Id = id;
            Name = firstName;
            Username = username;
            Password = password;
            Type = type;
            CreateAt = createAt;
        }
        public static string HashPassword(string password, byte[] salt)
        {
            byte[] hashed = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32
            );

            return Convert.ToBase64String(hashed);
        }

        public bool Authenticate(string username, string password)
        {
            string hashedPassword = HashPassword(password, Encoding.UTF8.GetBytes("say my name"));
            DataTable dt = DB.LoadData($"select * from infoUsers where Username='{username}' AND [Password] = '{hashedPassword}' ");
            if (dt.Rows.Count > 0)
            {
                Id = dt.Rows[0]["ID"].ToString();
                Name = dt.Rows[0]["Name"].ToString();
                Username = dt.Rows[0]["Username"].ToString();
                Password = dt.Rows[0]["Password"].ToString();
                Type = dt.Rows[0]["Type"].ToString();
                CreateAt = dt.Rows[0]["Created_at"].ToString();
                WhoAdded = dt.Rows[0]["Who_added"].ToString();
                return true;
            }
            return false;

        }


        public static DataTable GetAllUsers
            (
            string currentid,
            string columns = "[ID]\r\n      ,[Name]\r\n      ,[Username]\r\n      ,[Type]\r\n      ,[UserType]\r\n      ,[Password]\r\n      ,[Created_at]\r\n      ,[who_added]\r\n      ,[WhoAddedType]"
            )
        {
            return DB.LoadData($"SELECT {columns} FROM infoUsers where ID <> '{currentid}' AND [Username] <> 'admin'");
        }
        public static bool AddUser(string name, string username, string password, string type, string whoAdded)
        {
            string hashedPassword = HashPassword(password, Encoding.UTF8.GetBytes("say my name"));
            string whoadded = whoAdded == null ?"NULL":$"'{whoAdded}'";
            string query = $"exec AddUser '{name}' , '{username}' , {type} , '{hashedPassword}' , {whoadded}";
            return DB.Execute(query);
                
        }
        public static bool UpdateUser(string id, string name, string username, string password, string type)
        {
            string hashedPassword = HashPassword(password, Encoding.UTF8.GetBytes("say my name"));
            string query = $"exec UpdateUser  '{name}' , '{username}' , {type} , '{hashedPassword}' , '{id}'";
            return DB.Execute(query);
                
        }
        public static void DeleteUser(string id)
        {
            string query = $"exec DeleteUser '{id}'";
            if (DB.Execute(query))
                MessageBox.Show("تم حذف المستخدم بنجاح", "success", MessageBoxButtons.OK, MessageBoxIcon.None);


        }
    }
}

