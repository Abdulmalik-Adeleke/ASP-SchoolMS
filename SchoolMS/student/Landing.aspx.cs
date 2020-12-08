using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolMS.student
{
    public partial class Landing : System.Web.UI.Page
    {
        string IDENTITY;
        string classtaking;

        protected void Page_Load(object sender, EventArgs e)
        {
            IDENTITY = Session["ID"].ToString();
            classtaking = Session["CLASS"].ToString();

            //check if null or not 
        }
    }
}