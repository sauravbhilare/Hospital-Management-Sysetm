using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Patient_Patient_Login : System.Web.UI.Page
{
    string strcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        string username = txtusername.Text;
        string password = txtpass.Text;

        using (SqlConnection con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Paitents_Registration] WHERE Username=@Username", con);
                cmd.Parameters.AddWithValue("@Username", username);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string storedPassword = dr["Password"].ToString();
                    // Check password using a secure comparison method (e.g., hashing)
                    if (SecurePasswordComparison(password, storedPassword))
                    {
                        // Store values in session or cookies
                        Response.Cookies["Paitent_Id"].Value = dr["Paitent_Id"].ToString();
                        Response.Cookies["First_Name_Last_Name"].Value = dr["First_Name"].ToString() + " " + dr["Last_Name"].ToString();
                        Response.Cookies["Paitent_Id"].Expires = DateTime.Now.AddHours(1);
                        Response.Cookies["First_Name_Last_Name"].Expires = DateTime.Now.AddHours(1);
                        Response.Redirect("Patient/Dashboard.aspx", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid Credentials...!');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User not found. Please register your account.');", true);
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // Logging: Log.Error("Login Error", ex);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('An error occurred while logging in.');", true);
            }
        }
    }

    // Example secure password comparison function (use appropriate hashing algorithm)
    private bool SecurePasswordComparison(string inputPassword, string hashedPassword)
    {
        // Implement secure password comparison logic (e.g., using a secure hashing algorithm like bcrypt or PBKDF2)
        // Example: return SecureHashing.Verify(inputPassword, hashedPassword);
        // Replace the above line with your secure password comparison logic.
        return inputPassword == hashedPassword; // This is a simple comparison, not recommended for production.
    }

}