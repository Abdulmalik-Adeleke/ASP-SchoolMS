using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace SchoolMS.student
{
    public partial class Assignment : System.Web.UI.Page
    {

        string IDENTITY;
        string classtaking;
        protected void Page_Load(object sender, EventArgs e)
        {
            IDENTITY = Session["ID"].ToString();
            classtaking = Session["CLASS"].ToString();
            if (!IsPostBack)
            {
                BindUpload();
            }
        }

        private void BindUpload()
        {
            using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SMS"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT ID, [ASSIGNMENT CODE],[ASSIGNMENT TITLE],[SUBJECT CODE],[CLASS ID],[DUE DATE],TERM FROM [ASSIGNMENT_BY_STAFF] WHERE [CLASS ID] ='"+classtaking+"' ORDER BY ID DESC";
                    command.Connection = connection;
                    connection.Open();
                    GridView1.DataSource = command.ExecuteReader();
                    GridView1.DataBind();
                    connection.Close();
                }
            }
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
                    command.CommandText = "SELECT Name, Data, ContentType FROM [ASSIGNMENT_BY_STAFF] WHERE ID = @iden";
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

        protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Select")
            {
                Int16 row = Convert.ToInt16(e.CommandArgument);
                assignmentcode.Text = GridView1.Rows[row].Cells[0].Text;
                subjectcode.Text = GridView1.Rows[row].Cells[3].Text;
            }
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            if (assignmentcode.Text == "" && subjectcode.Text == "")
            {
                Status.ForeColor = System.Drawing.Color.Red;
                Status.Text = "Please select the details of assignment you're submitting to.";
            }
            else
            {
                try
                {
                    string[] validtypes = { "doc", "docx", "xls", "txt", "pdf", "xlsx" };
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



                                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SMS"].ConnectionString);
                                connection.Open();
                                SqlCommand command = new SqlCommand(
"INSERT INTO [ASSIGNMENT_BY_STUDENT] VALUES (@STUDENTID,@ASSIGNMENTCODE,@CLASSID,@SUBJECTCODE,@ASSIGNMENTTITLE,@DATE,@CONTENTTYPE,@DATA,@NAME)", connection);
                                command.Parameters.AddWithValue("@STUDENTID", IDENTITY);
                                command.Parameters.AddWithValue("@ASSIGNMENTCODE", assignmentcode.Text);
                                command.Parameters.AddWithValue("@CLASSID", classtaking);
                                command.Parameters.AddWithValue("@SUBJECTCODE", subjectcode.Text);
                                command.Parameters.AddWithValue("@ASSIGNMENTTITLE", TextBox1.Text);
                                command.Parameters.AddWithValue("@DATE", DateTime.Now.ToString("d"));
                                command.Parameters.AddWithValue("@CONTENTTYPE", contenttype);
                                command.Parameters.AddWithValue("@DATA", bytes);
                                command.Parameters.AddWithValue("@NAME", filename);
                                command.ExecuteNonQuery();
                                connection.Close();
                                Status.ForeColor = System.Drawing.Color.Green;
                                Status.Text = "Assignment uploaded successfully";
                            }

                        }
                        Status.ForeColor = System.Drawing.Color.Green;
                        Status.Text = "Assignment uploaded successfully";
               
                    }
                       Response.Redirect(Request.Url.AbsoluteUri);
                }
                catch (Exception ex)
                {
                    Status.ForeColor = System.Drawing.Color.Red;
                    Status.Text = "Exception occured: " + ex.Message + "";
                }

            }
        }
    }
}