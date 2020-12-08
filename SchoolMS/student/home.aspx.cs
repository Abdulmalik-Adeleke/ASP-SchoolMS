using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolMS.student
{
    public partial class home : System.Web.UI.Page
    {
        string classtaking;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            classtaking = Session["CLASS"].ToString();
           // SELECT[SUBJECT CODE] AS SUBJECT_CODE, [DAY], [CLASS BEGINS] AS CLASS_BEGINS,
           // [CLASS ENDS] AS CLASS_ENDS, [EXAM BEGINS] AS EXAM_BEGINS, [EXAM ENDS] 
           // AS EXAM_ENDS FROM[TIMETABLE] WHERE([CLASS ID] = @CLASS_ID)
           if(!IsPostBack)
           {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SMS"].ConnectionString))
                {
                     connection.Open();
                     using (SqlCommand command = new SqlCommand("SELECT[SUBJECT CODE] AS SUBJECT_CODE, [DAY], [CLASS BEGINS] AS CLASS_BEGINS,[CLASS ENDS] AS CLASS_ENDS FROM TIMETABLE WHERE[CLASS ID] = @CLASS_ID AND isExam = @isexam ORDER BY DayIndex,[CLASS BEGINS] "))
                     {
                        command.Connection = connection;
                        command.Parameters.Add(new SqlParameter("@CLASS_ID", classtaking));
                        command.Parameters.Add(new SqlParameter("@isExam", "false"));

                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                         da.Fill(dt);
                            DataList1.DataSource = dt;
                            DataList1.DataBind();
                        }
                        

                    }

                }


            }
        }
    }
}