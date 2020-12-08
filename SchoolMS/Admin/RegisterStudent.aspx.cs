using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Security.Cryptography;
using System.Net.Mail;
using System.IO;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMS.Admin
{
    public partial class RegisterStudent : System.Web.UI.Page
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        string password;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    //Task go = new Task(Register);
                    //go.Start();

                    Register();
                    //clear all textboxes value
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        public void Register()
        {
            char[] letters = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
            Random random = new Random();
            for(int i = 0; i < 4; i++)
            {
                password += letters[random.Next(0, 36)].ToString();
            }

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SMS"].ConnectionString);
            connection.Open();
            command = new SqlCommand("LogStudent", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@LASTNAME",surname.Text));
            command.Parameters.Add(new SqlParameter("@FIRSTNAME", firstname.Text));
            command.Parameters.Add(new SqlParameter("@DOB", Convert.ToDateTime(DOB.Text).ToString("d")));
            command.Parameters.Add(new SqlParameter("@EMAIL", email.Text));
            command.Parameters.Add(new SqlParameter("@MOBILE", mobile.Text));
            command.Parameters.Add(new SqlParameter("@PASS", Encrypt(password)));
            command.Parameters.Add(new SqlParameter("@CLASS", txtclass.Text));
            command.Parameters.Add(new SqlParameter("@REG", DateTime.Now.Date));

            reader = command.ExecuteReader();
            if (reader.Read())
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.To.Add(new MailAddress(reader["EMAIL"].ToString()));
                message.From = new MailAddress("dontreplytaneschools@gmail.com", "Admin - Tane Crescent School");
                message.Subject = "Student Login/Personal Details. Do not disclose!";
                string body = "Hello " + reader["LASTNAME"].ToString() + " " + reader["FIRSTNAME"].ToString() + ".";
                body += "<br/><br/> Your Portal details are:";
                body += "<br/>Portal User-ID: " + reader["USERID"].ToString() +"";
                body += "<br/>Password: " + password + "";
                body += "<br/><a href='http://www.google.com'>Login here</a>";
                body += "<p>You can login with either your Email or Portal User-ID </p> ";
                message.IsBodyHtml = true;
                message.Body = body;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential("dontreplytaneschools@gmail.com", "Mypassword123");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream()) 
                {
                    using(CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

    }
}