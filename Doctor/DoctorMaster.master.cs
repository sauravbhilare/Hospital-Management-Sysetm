using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Doctor_DoctorMaster : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Retrieving values from cookies
            if (Request.Cookies["Doctor_Id"] != null && Request.Cookies["First_Name_Last_Name"] != null)
            {
                lbldoctid.Text = Request.Cookies["Doctor_Id"].Value;
                lbldoctname.Text = Request.Cookies["First_Name_Last_Name"].Value;

            }
            else
            {
                // Handle case when cookies are not present or expired
                // For example, redirect to the login page
                Response.Redirect("../Doctor_Login.aspx");
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        // Expire or remove cookies
        if (Request.Cookies["Doctor_Id"] != null)
        {
            Response.Cookies["Doctor_Id"].Expires = DateTime.Now.AddDays(-1); // Expire the cookie
        }

        if (Request.Cookies["First_Name_Last_Name"] != null)
        {
            Response.Cookies["First_Name_Last_Name"].Expires = DateTime.Now.AddDays(-1); // Expire the cookie
        }

        // Redirect to the login page
        Response.Redirect("~/Doctor_Login.aspx");
    }
}
