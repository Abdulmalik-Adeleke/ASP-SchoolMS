using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Web.Security;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;

namespace SchoolMS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            myh1.InnerText = "Term: " + Application["term"].ToString();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {          
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SMS"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Signin", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@EMAIL", txtid.Text));
                        command.Parameters.Add(new SqlParameter("@USERNAME", txtid.Text));
                        command.Parameters.Add(new SqlParameter("@PASSWORD", Encrypt(txtpass.Text)));

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Session["ID"] = reader["USERID"].ToString();
                                Session["LASTNAME"] = reader["LASTNAME"].ToString();
                                Session["FIRSTNAME"] = reader["FIRSTNAME"].ToString();
                                Session["EMAIL"] = reader["EMAIL"].ToString();
                                Session["CLASS"] = reader["CLASS ID"].ToString();
                                reader.Close();

                                if ((string)Session["ID"] != null)
                                {
                                   
                                    List<string> arr = new List<string>();
                                    List<string> timetabletype = new List<string>();
                                    string who = (string)Session["ID"];

                                    if (who.Substring(0, 3) == "TS0")
                                    {
                                      //  using (SqlCommand newcommand = new SqlCommand("SELECT DISTINCT Timetable_type FROM TIMETABLE WHERE CLASS = @class", connection))
                                       // {
                                           // command.Parameters.Add(new SqlParameter("@class", Session["CLASS"].ToString())); 

                                            //using (SqlDataReader dataReader = newcommand.ExecuteReader())
                                           // {

                                           //     while (dataReader.Read())
                                          //      {
                                         //           timetabletype.Add(dataReader[0].ToString());
                                        //        }
                                        //        Session["Timetabletype"] = timetabletype;
                                                FormsAuthentication.RedirectFromLoginPage(txtid.Text, remember.Checked);
                                                Response.Redirect("~/student/home.aspx");
                                        //    }
                                        //}
                                    }
                                    else if (who.Substring(0, 3) == "TI0")
                                    {
                                        using (SqlCommand command1 = new SqlCommand("SELECT USERID FROM INSTRUCTOR", connection))
                                        {
                                            using (SqlDataReader dataReader = command1.ExecuteReader())
                                            {

                                                while (dataReader.Read())
                                                {
                                                    arr.Add(dataReader[0].ToString());
                                                }
                                                Session["Authenticate"] = arr;
                                                FormsAuthentication.RedirectFromLoginPage(txtid.Text, remember.Checked);
                                                Response.Redirect("~/staff/home.aspx");

                                                /*   PERSIST EVERY STAFF PAGE FOR AUTHENTICATION IF(!ISPOSTBACK)
                                                List<string> ls = (List<string>)Session["Authenticate"];
                                                bool ifcontains = ls.Exists(user => user == who);
                                                if (!ifcontains)
                                                {
                                                    // Response.Write("redirect to login");
                                                     Response.Redirect("~/Login.aspx");
                                                }
                                                */


                                            }

                                        }


                                    }
                                }
                                else
                                {
                                    error.Text = "Username and/or password incorrect!";
                                }
                            }
                        }
                       
                    }
                }               
            }
            catch(Exception ex)
            {
                Response.Write("<h3>Server Error: 500 </h3>" +ex.Message);
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
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
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