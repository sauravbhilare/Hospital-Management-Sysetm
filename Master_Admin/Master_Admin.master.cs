using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_Admin_Master_Admin : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Retrieving values from cookies
            if (Request.Cookies["Master_Id"] != null && Request.Cookies["First_Name_Last_Name"] != null)
            {
                masterid.Text = Request.Cookies["Master_Id"].Value;
                name.Text = Request.Cookies["First_Name_Last_Name"].Value;

            }
            else
            {
                // Handle case when cookies are not present or expired
                // For example, redirect to the login page
                Response.Redirect("../Login.aspx");
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        // Expire or remove cookies
        if (Request.Cookies["Master_Id"] != null)
        {
            Response.Cookies["Master_Id"].Expires = DateTime.Now.AddDays(-1); // Expire the cookie
        }

        if (Request.Cookies["First_Name_Last_Name"] != null)
        {
            Response.Cookies["First_Name_Last_Name"].Expires = DateTime.Now.AddDays(-1); // Expire the cookie
        }

        // Redirect to the login page
        Response.Redirect("~/Login.aspx");
    }
}
