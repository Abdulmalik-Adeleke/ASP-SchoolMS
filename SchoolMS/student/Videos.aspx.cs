using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace SchoolMS.student
{
    public partial class Videos : System.Web.UI.Page
    {
        string id;
        string classtaken;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Session["ID"].ToString();
            classtaken = Session["CLASS"].ToString();
            if (!IsPostBack)
            {
               
            }
            //--Creating data for gridview
            DataTable dt = new DataTable();
            dt.Columns.Add("Url");

            //--adding a youtube video link
            DataRow dr = dt.NewRow();
            dr["url"] = "https://www.youtube.com/embed/MNy3KYKEHAg";
            dt.Rows.Add(dr);

            //--adding a youtube video link
            dr = dt.NewRow();
            dr["url"] = "https://www.youtube.com/embed/U6yPs9do3Zw?enablejsapi=1";
            dt.Rows.Add(dr);

            //--adding a youtube video link
            dr = dt.NewRow();
            dr["url"] = "https://www.youtube.com/embed/haA7DpK9Z4k";
            dt.Rows.Add(dr);

            //--adding a youtube video link
            dr = dt.NewRow();
            dr["url"] = "https://www.youtube.com/embed/FCUk7rIBBAE";
            dt.Rows.Add(dr);

            //--adding a youtube video link
            dr = dt.NewRow();
            dr["url"] = "https://www.youtube.com/embed/B9H3iinXZv0";
            dt.Rows.Add(dr);

            //--adding a youtube video link
            dr = dt.NewRow();
            dr["url"] = "https://www.youtube.com/embed/ucVJrja8r6Q";
            dt.Rows.Add(dr);

            //--adding a youtube video link
            dr = dt.NewRow();
            dr["url"] = "https://www.youtube.com/embed/3Iyuym-Gci0";
            dt.Rows.Add(dr);

            //--adding a youtube video link
            dr = dt.NewRow();
            dr["url"] = "https://www.youtube.com/embed/helEv0kGHd4";
            dt.Rows.Add(dr);

            //--adding a youtube video link
            dr = dt.NewRow();
            dr["url"] = "https://www.youtube.com/embed/helEv0kGHd4";
            dt.Rows.Add(dr);


            //--binding gridview
             Repeater1.DataSource = dt;
             Repeater1.DataBind();

        }
    }
}