using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolMS.staff
{
    public partial class Timetable : System.Web.UI.Page
    {
        string id;
        string classtaken;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Session["ID"].ToString();
            classtaken = Session["CLASS"].ToString();

            if(!IsPostBack)
            {
            //    List<string> ls = (List<string>)Session["Authenticate"];

            //    if (ls == null)
            //    {
            //        Server.Transfer("~/Login.aspx");
            //    }
            //    bool ifcontains = ls.Exists(user => user == id);
            //    if (!ifcontains)
            //    {
            //        Server.Transfer("~/Login.aspx");
            //    }
            }
        }

        protected void btnpublish_Click(object sender, EventArgs e)
        {
            try
            {
                if (Isexam.Checked)
                {
                    
                    //create table and edit carefully
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SMS"].ConnectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("INSERT INTO TIMETABLE ([SUBJECT CODE],[CLASS ID],[isExam],[DayIndex],[DAY],[EXAM BEGINS],[EXAM ENDS]) VALUES (@subject,@class,@isexam,@dayindex,@day,@start,@end)", connection))
                        {
                            command.Parameters.Add(new SqlParameter("@subject", subjects.SelectedValue));
                            command.Parameters.Add(new SqlParameter("@class", classtaken));
                            command.Parameters.Add(new SqlParameter("@isexam", "true"));
                            command.Parameters.Add(new SqlParameter("@dayindex", day.SelectedValue));
                            command.Parameters.Add(new SqlParameter("@day", day.SelectedItem.Text));
                            command.Parameters.Add(new SqlParameter("@start", Convert.ToDateTime(start.Text)));
                            command.Parameters.Add(new SqlParameter("@end", Convert.ToDateTime(end.Text)));
                            command.ExecuteNonQuery();
                            message.Text = "Successful";
                        }
                    }

                }           
                else
                {
                    DateTime starttime = DateTime.Parse(start.Text);
                    DateTime endtime = DateTime.Parse(end.Text);
                    TimeSpan startspan = starttime.TimeOfDay;
                    TimeSpan endspan = endtime.TimeOfDay;



                    //create table and edit carefully
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SMS"].ConnectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("INSERT INTO TIMETABLE ([SUBJECT CODE],[CLASS ID],[DayIndex],[DAY],[CLASS BEGINS],[CLASS ENDS]) VALUES (@subject,@class,@dayindex,@day,@start,@end)", connection))
                        {
                            command.Parameters.Add(new SqlParameter("@subject", subjects.SelectedValue)); 
                            command.Parameters.Add(new SqlParameter("@dayindex", day.SelectedValue));
                            command.Parameters.Add(new SqlParameter("@day", day.SelectedItem.Text));
                            command.Parameters.Add(new SqlParameter("@start", startspan));
                            command.Parameters.Add(new SqlParameter("@end", endspan));
                            command.Parameters.Add(new SqlParameter("@class", classtaken));
                            command.ExecuteNonQuery();
                            message.Text = "Successful";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message.Text = "An Error Occured: " + ex.Message;
            }
        }

        protected void Isexam_CheckedChanged(object sender, EventArgs e)
        {
            if(Isexam.Checked)
            {
                start.TextMode = TextBoxMode.DateTimeLocal;
                end.TextMode = TextBoxMode.DateTimeLocal;
            }
        }


    }
}