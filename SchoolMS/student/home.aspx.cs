using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using SchoolMS.Model;

namespace SchoolMS.student
{
    class Timetable
    {
        public string Subject { get; set; }
        public string Day { get; set; }
        public object Start { get; set; }
        public object End { get; set; }
    }
    public partial class home : System.Web.UI.Page
    {
        string classtaking;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            classtaking = Session["CLASS"].ToString();
           // SELECT [SUBJECT CODE] AS SUBJECT_CODE, [DAY], [CLASS BEGINS] AS CLASS_BEGINS,
           // [CLASS ENDS] AS CLASS_ENDS, [EXAM BEGINS] AS EXAM_BEGINS, [EXAM ENDS] 
           // AS EXAM_ENDS FROM [TIMETABLE] WHERE ([CLASS ID] = @CLASS_ID)
           if(!IsPostBack)
           {   
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SMS"].ConnectionString))
                {
                    Timetable timetable = new Timetable();
                    List<string> list = new List<string>();
                    List<Timetable> genericTimeTable = new List<Timetable>();
                    string sql;
                    string cachekey;
                    int expiry;
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT Distinct(isExam) FROM TIMETABLE WHERE [CLASS ID] = @CLASS_ID "))
                    {
                        command.Connection = connection;
                        command.Parameters.Add(new SqlParameter("@CLASS_ID", classtaking));
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            { 
                                list.Add(reader[0].ToString());
                            }
                        }
                    }
                    if (list.Contains("true"))
                    {
                        sql = @"SELECT [SUBJECT CODE] AS SUBJECT_CODE, [DAY], [EXAM BEGINS] AS EXAM_BEGINS,[EXAM ENDS] AS EXAM_ENDS  FROM TIMETABLE WHERE [CLASS ID] = @CLASS_ID AND isExam = 'true' ";
                        cachekey = "isExam" + classtaking;
                    }
                    else
                    {
                        sql = @"SELECT [SUBJECT CODE] AS SUBJECT_CODE, [DAY], [CLASS BEGINS] AS CLASS_BEGINS,[CLASS ENDS] AS CLASS_ENDS FROM TIMETABLE WHERE [CLASS ID] = @CLASS_ID AND isExam = 'false' ORDER BY DayIndex,[CLASS BEGINS]";
                        cachekey = "class" + classtaking;
                        DateTime.UtcNow.AddDays(1).ToString("yyyy-MM-dd").Replace("-", "");
                    }
                     using (SqlCommand command = new SqlCommand(sql))
                     {
                        command.Connection = connection;
                        command.Parameters.Add(new SqlParameter("@CLASS_ID", classtaking));
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                timetable.Subject = reader[0].ToString();
                                timetable.Day = reader[1].ToString();
                                timetable.Start = reader[2];
                                timetable.End = reader[3];
                                genericTimeTable.Add(timetable);
                            }
                        }
                     }
                    var resultant = genericTimeTable;
                }


            }

            SqliteCache cache = new SqliteCache();
            var obj = cache.GetCache("my second key");
            
           
        }
    }
}