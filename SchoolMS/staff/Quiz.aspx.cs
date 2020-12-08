using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolMS.staff
{
    public partial class Quiz : System.Web.UI.Page
    {
          string id;
          string classtaken;

        protected void Page_Load(object sender, EventArgs e)
        {

            id = Session["ID"].ToString();
            classtaken = Session["CLASS"].ToString();


            //perform authentication

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
            Random random = new Random();
            StringBuilder quizsb = new StringBuilder("q");
            int quizid = random.Next(100, 10000);
            string quiz = quizsb.Append(quizid).ToString();


            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SMS"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO QUIZ VALUES (@quizid,@subject,@class,@description,@date)", connection))
                    {
                        command.Connection = connection;
                        command.Parameters.Add(new SqlParameter("@quizid", quiz));
                        command.Parameters.Add(new SqlParameter("@subject", DropDownList1.SelectedValue.ToString()));
                        command.Parameters.Add(new SqlParameter("@class", classtaken));
                        command.Parameters.Add(new SqlParameter("@description", txtdescription.InnerText));
                        command.Parameters.Add(new SqlParameter("@date", DateTime.UtcNow.AddHours(1)));
                    }
                }
                Response.Redirect("~/staff/Startquiz.aspx?id=" + quiz);
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('An error occured: "+ex.Message+" ')</script>");
            }
        }
    }
}