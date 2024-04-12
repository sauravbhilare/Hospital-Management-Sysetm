using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Patient_PatientMaster : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Retrieving values from cookies
            if (Request.Cookies["Paitent_Id"] != null && Request.Cookies["First_Name_Last_Name"] != null)
            {
                lblPatientid.Text = Request.Cookies["Paitent_Id"].Value;
                lblPatientname.Text = Request.Cookies["First_Name_Last_Name"].Value;

            }
            else
            {
                // Handle case when cookies are not present or expired
                // For example, redirect to the login page
                Response.Redirect("~/Patient_Login.aspx");
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        // Expire or remove cookies
        if (Request.Cookies["Paitent_Id"] != null)
        {
            Response.Cookies["Paitent_Id"].Expires = DateTime.Now.AddDays(-1); // Expire the cookie
        }

        if (Request.Cookies["First_Name_Last_Name"] != null)
        {
            Response.Cookies["First_Name_Last_Name"].Expires = DateTime.Now.AddDays(-1); // Expire the cookie
        }

        // Redirect to the login page
        Response.Redirect("~/Patient_Login.aspx");
    }
    
}
