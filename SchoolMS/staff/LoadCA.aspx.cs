using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net.Mail;

namespace SchoolMS.staff
{
    public partial class LoadCA : System.Web.UI.Page
    {
        string id;
        string classtaken;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            id = Session["ID"].ToString();
            classtaken = Session["CLASS"].ToString();

            if (!IsPostBack)
            {
                Response.Write(classtaken);
                LoadTermTable();
                GridView1.DataSource = dt;
                GridView1.DataBind();
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
                // IF CACHE.contains key of (classtaken.tostring)
                // DISABLE CHECKBOX Load.Enabled = false;
                // BIND GRID               
            }

            //CALL BINDING FUNCTION ON POSTBACK
        }

        protected void Load_CheckedChanged(object sender, EventArgs e)
        {
            if (Load.Checked)
            {

                //request excel --- send mail();
                RequestExcel();
               
               // Cache.Insert(classtaken, "true", null, DateTime.Now.AddDays(50), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, null);
                try
                {
                    //  call stored proc
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SMS"].ConnectionString))
                    {
                              
                        using (SqlCommand command = new SqlCommand("LoadAssessment", connection))
                        {

                            connection.Open();
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add(new SqlParameter("@term", Application["term"].ToString()));
                            command.Parameters.Add(new SqlParameter("@class", classtaken));
                            command.ExecuteNonQuery();
                        }                    
                    }

                    LoadTermTable();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("Unable to communicate with the servers: " + ex.Message);
                }
            }
        }

        //datatable function
        public DataTable LoadTermTable()
        {
            string term = Application["term"].ToString();
                        
            if (term == "1")
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SMS"].ConnectionString))
                {
                    using(SqlCommand query = new SqlCommand())
                    {
                        query.CommandText = "SELECT * FROM [STUDENT_GRADES_1] WHERE [CLASS ID] = @class";
                        query.Parameters.AddWithValue("@class", classtaken);
                        query.Connection = con;
                        con.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(query))
                        {
                            adapter.Fill(dt);
                        }

                    }

                    
                }
               

            }
            else if (term == "2")
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SMS"].ConnectionString))
                {
                    using (SqlCommand query = new SqlCommand())
                    {
                        query.CommandText = "SELECT * FROM [STUDENT_GRADES_2] WHERE [CLASS ID] = @class";
                        query.Parameters.AddWithValue("@class", classtaken);
                        con.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(query))
                        {
                            adapter.Fill(dt);
                        }
                    }
                    
                }
            
            }
            else if (term =="3")
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SMS"].ConnectionString))
                {
                    using (SqlCommand query = new SqlCommand())
                    {
                        query.CommandText = "SELECT * FROM [STUDENT_GRADES_3] WHERE [CLASS ID] = @class";
                        query.Parameters.AddWithValue("@class", classtaken);
                        con.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(query))
                        {
                            adapter.Fill(dt);
                        }
                       
                    }
                }

                

            }

            return dt;

        }

        public void RequestExcel()
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.To.Add(new MailAddress("leke.aabdul@gmail.com"));
            message.From = new MailAddress("dontreplytaneschools@gmail.com", "Admin - Tane Crescent School");
            message.Subject = "EXCEL WORKSHEET REQUEST FOR CLASS " + classtaken;
            string body = "Hello! ";
            body += "<br/> PLEASE UPLOAD EXCEL WORKHEET. CURRENT TERM: " + Application["term"].ToString();
                

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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Select")
            {
                Int16 row = Convert.ToInt16(e.CommandArgument);

                lblstudent.Text = GridView1.Rows[row].Cells[1].Text;
                lblsubject.Text = GridView1.Rows[row].Cells[0].Text;
            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex != 0)
            {
               // using ()
                //{
                  //  using ()
                   // {
                   //
                    //}
                //}
            }
            
        }
    }
}