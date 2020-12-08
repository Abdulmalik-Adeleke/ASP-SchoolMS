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
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Configuration;

namespace SchoolMS.staff
{
    public partial class Startquiz : System.Web.UI.Page
    {
       
        string quizid;
        string classtaken;
        string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Session["ID"].ToString();
            classtaken = Session["CLASS"].ToString();
            quizid = Request.QueryString["id"];
            

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
                


                DataTable quiztable = new DataTable();
                quiztable.Columns.Add("QUIZ ID", typeof(string));
                quiztable.Columns.Add("QUESTION", typeof(string));
                quiztable.Columns.Add("OPTION 1", typeof(string));
                quiztable.Columns.Add("OPTION 2", typeof(string));
                quiztable.Columns.Add("OPTION 3", typeof(string));
                quiztable.Columns.Add("OPTION 4", typeof(string));
                quiztable.Columns.Add("ANSWER", typeof(string));

                Session["quiztable"] = quiztable;

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (selected.SelectedIndex > 0)
            {
                string rightAnswer = null;
                switch (selected.SelectedIndex)
                {
                    case 1:
                        rightAnswer += option1.Text;
                        break;
                    case 2:
                        rightAnswer += option2.Text;
                        break;
                    case 3:
                        rightAnswer += option3.Text;
                        break;
                    case 4:
                        rightAnswer += option4.Text;
                        break;
                }

                DataTable data = (DataTable)Session["quiztable"];
                DataRow row = data.NewRow();              
                row["QUIZ ID"] = quizid;
                row["QUESTION"] = txtquestion.InnerText;
                row["OPTION 1"] = option1.Text;
                row["OPTION 2"] = option2.Text;
                row["OPTION 3"] = option3.Text;
                row["OPTION 4"] = option4.Text;
                row["ANSWER"] = rightAnswer;
                data.Rows.Add(row);
                txtquestion.InnerText = " ";
                option1.Text = " ";
                option2.Text = " ";
                option3.Text = " ";
                option4.Text = " ";
                selected.SelectedIndex = 0;

                DataTable d = (DataTable)Session["quiztable"];
                QuestionsView.DataSource = d;
                QuestionsView.DataBind();
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Please specify a correct answer";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["quiztable"] != null)
            {
                DataTable qwiz = (DataTable)Session["quiztable"];
                //sqlbulkcopy order by date(default getdate())
                try
                {
                    using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SMS"].ConnectionString))
                    {
                        connection.Open();
                        //var transaction = connection.BeginTransaction();
                        using (var bulkcopy = new SqlBulkCopy(connection))
                        {
                            bulkcopy.DestinationTableName = "QuizQuestions";
                            
                            SqlBulkCopyColumnMapping QUIZ = new SqlBulkCopyColumnMapping(0, "QUIZ ID");
                            bulkcopy.ColumnMappings.Add(QUIZ);
                            SqlBulkCopyColumnMapping QUEST = new SqlBulkCopyColumnMapping(1, "QUESTION");
                            bulkcopy.ColumnMappings.Add(QUEST);
                            SqlBulkCopyColumnMapping OPTION1 = new SqlBulkCopyColumnMapping(2, "OPTION 1");
                            bulkcopy.ColumnMappings.Add(OPTION1);
                            SqlBulkCopyColumnMapping OPTION2 = new SqlBulkCopyColumnMapping(3, "OPTION 2");
                            bulkcopy.ColumnMappings.Add(OPTION2);
                            SqlBulkCopyColumnMapping OPTION3 = new SqlBulkCopyColumnMapping(4, "OPTION 3");
                            bulkcopy.ColumnMappings.Add(OPTION3);
                            SqlBulkCopyColumnMapping OPTION4 = new SqlBulkCopyColumnMapping(5, "OPTION 4");
                            bulkcopy.ColumnMappings.Add(OPTION4);
                            SqlBulkCopyColumnMapping ANS = new SqlBulkCopyColumnMapping(6, "ANSWER");
                            bulkcopy.ColumnMappings.Add(ANS);
                           
         
                            bulkcopy.WriteToServer(qwiz);
                        }
                    }
                    Session.Remove("quiztable");
                }
                catch (Exception ex)
                {
                    Response.Write("Unable to unable " + ex.Message);
                }
            }
            else
            {
                Response.Write("datatable is empty");
            }
        }
    }
}