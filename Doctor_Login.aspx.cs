using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Doctor_Login : System.Web.UI.Page
{
    string strcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("Select * from [dbo].[Doctors] where  Username='" + txtusername.Text + "' and Password='" + txtpass.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (txtusername.Text.Equals(dr["Username"].ToString(), StringComparison.OrdinalIgnoreCase) && txtpass.Text == dr["Password"].ToString())
                    {

                        // Store values in cookies
                        Response.Cookies["Doctor_Id"].Value = dr["Doctor_Id"].ToString();
                        Response.Cookies["First_Name_Last_Name"].Value = dr["First_Name"].ToString() + " " + dr["Last_Name"].ToString();
                        // Set expiration for the cookies (if needed)
                        Response.Cookies["Doctor_Id"].Expires = DateTime.Now.AddHours(1); // Example: expires in 1 hour
                        Response.Cookies["First_Name_Last_Name"].Expires = DateTime.Now.AddHours(1);
                        Response.Redirect("Doctor/Dashboard.aspx", true);


                    }
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid Credential...!');", true);
            }


        }
        catch (Exception ex)
        {
            ex.ToString();

        }
        finally
        {
            con.Close();
        }
    }
}