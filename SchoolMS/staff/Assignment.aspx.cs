using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI.WebControls;

namespace SchoolMS.staff
{
    public partial class Assignment : System.Web.UI.Page
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

                GridView2.DataSource = BindAssignments();
                GridView2.DataBind();
            }

        }


        protected void Upload_Click(object sender, EventArgs e)
        {
            try
            {
                string[] validtypes = { "doc", "docx", "xls", "txt", "pdf" };
                string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                bool isvalid = false;
                for (int i = 0; i < validtypes.Length; i++)
                {
                    if (ext == "." + validtypes[i])
                    {
                        isvalid = true;
                        break;
                    }
                }
                if (!isvalid)
                {
                    Status.ForeColor = System.Drawing.Color.Red;
                    Status.Text = "Invalid file type. Upload a file with either of the following extensions: " + String.Join(",", validtypes);
                }
                else
                {
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string contenttype = FileUpload1.PostedFile.ContentType;
                    using (Stream fs = FileUpload1.PostedFile.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);



                            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SMS"].ConnectionString))
                            {
                                connection.Open();
                                using (SqlCommand command = new SqlCommand("uploadfile", connection))
                                {
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Connection = connection;
                                    command.Parameters.Add(new SqlParameter("@TITLE", title.InnerText));
                                    command.Parameters.Add(new SqlParameter("@INSTRUCTOR", "ti009"));
                                    command.Parameters.Add(new SqlParameter("@CLASS", classtaken));
                                    command.Parameters.Add(new SqlParameter("@SUBJECT", DropDownList1.SelectedValue.ToString()));
                                    command.Parameters.Add(new SqlParameter("@DUE", Convert.ToDateTime(due.Text).ToString("d")));
                                    command.Parameters.Add(new SqlParameter("@NAME", filename));
                                    command.Parameters.Add(new SqlParameter("@CONTENT", contenttype));
                                    command.Parameters.Add(new SqlParameter("@DATA", bytes));
                                    command.Parameters.Add(new SqlParameter("@TERM", Application["Term"].ToString()));

                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            MailMessage message = new MailMessage();
                                            SmtpClient smtp = new SmtpClient();
                                            message.To.Add(new MailAddress(reader["EMAIL"].ToString()));
                                            message.From = new MailAddress("dontreplytaneschools@gmail.com", "Admin - Tane Crescent School");
                                            message.Subject = "New Assignment Uploaded!";
                                            string body = "Hello! ";
                                            body += "<br/> A New Assignment has been Uploaded ";

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
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Status.ForeColor = System.Drawing.Color.Red;
                Status.Text = "Exception occured: " + ex.Message + "";
            }
            GridView1.DataBind();
        }

        private DataTable BindAssignments()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("STUDENT_ID", typeof(string));
            table.Columns.Add("ASSIGNMENT_CODE", typeof(string));
            table.Columns.Add("ASSIGNMENT_TITLE", typeof(string));
            table.Columns.Add("SUBJECT_CODE", typeof(string));
            table.Columns.Add("CLASS_ID", typeof(string));
            table.Columns.Add("DATE", typeof(DateTime));
            table.Columns.Add("DUE_DATE", typeof(DateTime));
            table.Columns.Add("NAME", typeof(string));

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SMS"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT [ID],[STUDENT ID] AS STUDENT_ID,[ASSIGNMENT CODE] AS ASSIGNMENT_CODE, [ASSIGNMENT TITLE] AS ASSIGNMENT_TITLE, [SUBJECT CODE] AS SUBJECT_CODE,[CLASS ID] AS CLASS_ID,[DATE],[DUE DATE] AS DUE_DATE,[Name] FROM [STUDENT ASSIGNMENT] WHERE [CLASS ID] = '" + classtaken + "' ORDER BY ID desc";
                    command.Connection = connection;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                       adapter.Fill(table);
                    }

                }

            }

            return table;
        }

        protected void LnkDownload_Click(object sender, EventArgs e)
        {
            int iden = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SMS"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT Name, Data, ContentType FROM [STUDENT ASSIGNMENT] WHERE ID=@iden";
                    command.Parameters.AddWithValue("@iden", iden);
                    command.Connection = connection;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        fileName = reader["Name"].ToString();
                        bytes = (byte[])reader["Data"];
                        contentType = reader["ContentType"].ToString();

                    }
                    connection.Close();
                }

            }

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = BindAssignments();
            string subject = DropDownList2.SelectedValue.ToString();
            Response.Write(subject);
            if (!string.IsNullOrEmpty(subject))
            {
                IEnumerable<DataRow> records = from each in table.AsEnumerable() where each.Field<string>("SUBJECT_CODE") == subject select each;
                DataTable dt = records.CopyToDataTable<DataRow>();
                GridView2.DataSource = dt;
                GridView2.DataBind();

            }
            else
            {

                GridView2.DataSource = table;
                GridView2.DataBind();

            }
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Select")
            {
                Int16 row = Convert.ToInt16(e.CommandArgument);

                labelstudent.Text = GridView2.Rows[row].Cells[0].Text;
                lblA.Text = GridView2.Rows[row].Cells[1].Text;
                infosub.Value = GridView2.Rows[row].Cells[3].Text;
                infoclass.Value = GridView2.Rows[row].Cells[4].Text;
            }

        }
        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataSource = BindAssignments();
            GridView2.DataBind();

        }

        protected void Mark_Click(object sender, EventArgs e)
        {
            //insert into dbo.ASSIGNMENT_GRADES

            if (labelstudent.Text != null && txtMark.Text != "")
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SMS"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO ASSIGNMENT_GRADES VALUES(@STUDENT,@ASSIGNMENT,@CLASS,@SUBJECT,@MARK,@TERM)", connection))
                    {
                        command.Connection = connection;

                        command.Parameters.AddWithValue("@STUDENT", labelstudent.Text);
                        command.Parameters.AddWithValue("@ASSIGNMENT", lblA.Text);
                        command.Parameters.AddWithValue("@CLASS", infoclass.Value.ToString());
                        command.Parameters.AddWithValue("@SUBJECT", infosub.Value.ToString());
                        command.Parameters.AddWithValue("@MARK", txtMark.Text);
                        command.Parameters.AddWithValue("@TERM", (string)Application["term"]);
                        command.ExecuteNonQuery();

                    }
                }
            }
            else
            {
              //  throw "select what youre submitting to";
            }

            //bing grid

            GridView2.DataSource = BindAssignments();
            GridView2.DataBind();

        }


    }
}


