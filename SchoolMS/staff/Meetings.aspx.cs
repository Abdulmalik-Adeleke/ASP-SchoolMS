using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Configuration;

namespace SchoolMS.staff
{
    public partial class Meetings : System.Web.UI.Page
    {
        string id;
        string classtaken;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Session["ID"].ToString();
            classtaken = Session["CLASS"].ToString();

            if(!IsPostBack)
            {
                //List<string> ls = (List<string>)Session["Authenticate"];

                //if (ls == null)
                //{
                //    Server.Transfer("~/Login.aspx");
                //}
                //bool ifcontains = ls.Exists(user => user == id);
                //if (!ifcontains)
                //{
                //    Server.Transfer("~/Login.aspx");
                //}

            }
        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            var body = meeting.InnerText;
            List<string> emails = new List<string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SMS"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT EMAIL FROM STUDENTS WHERE [CLASS ID] = @class";
                        command.Parameters.AddWithValue("@class",classtaken);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while(dr.Read())
                            {
                                emails.Add(dr[0].ToString());
                            }
                        }
                    }
                }

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                foreach (var email in emails)
                {
                    message.To.Add(email);
                    Response.Write(email);
                }
                
                message.From = new MailAddress("dontreplytaneschools@gmail.com", "Admin - Tane Crescent School");
                message.Subject = "New Class Activity";
                message.Body = body;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential("dontreplytaneschools@gmail.com", "Mypassword123");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                lblmessage.Text = "Link Published Successfully";
            }
            catch(Exception ex)
            {
               // lblmessage.ForeColor = "Red";
                lblmessage.Text = ex.Message;
            }
        }
    }
}