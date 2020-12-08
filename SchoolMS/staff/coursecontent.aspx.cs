using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Hosting;
using System.Configuration;
using System.Security.AccessControl;

namespace SchoolMS.staff
{
    public partial class coursecontent : System.Web.UI.Page
    {
        string id;
        string classtaken;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Session["ID"].ToString();
            classtaken = Session["CLASS"].ToString();
            if (!IsPostBack)
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string type;

            Match ismatch = Regex.Match(url.Text.Trim(),
            @"www.youtube.com/embed/([A-Za-z0-9\-]+)$");

            if (ismatch.Success)
            {
                type = "video";
            }
            else
            {
                type = "text";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SMS"].ConnectionString))
                {
                    connection.Open();
                    
                    using (SqlCommand command = new SqlCommand("INSERT INTO Content VALUES (@Name,@Url,@ContentType,@Subject,@Class)", connection))
                    {
  
                        command.Parameters.Add(new SqlParameter("@Name", name.Text.ToUpper())); ;
                        command.Parameters.Add(new SqlParameter("@Url", url.Text.Trim())); ;
                        command.Parameters.Add(new SqlParameter("@ContentType", type));
                        command.Parameters.Add(new SqlParameter("@Subject", DropDownList1.SelectedValue.ToString()));
                        command.Parameters.Add(new SqlParameter("@Class", classtaken));
                        command.ExecuteNonQuery();
                        message.Text = "Uploaded Successfully";
                    }
                }              
            }
            catch(Exception ex)
            {
               message.Text = ex.Message;
            }

           
        }
    }
}