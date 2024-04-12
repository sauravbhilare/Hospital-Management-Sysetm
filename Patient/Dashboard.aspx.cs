using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Patient_Dashboard : System.Web.UI.Page
{
    string strcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        lblpatient.Text = ((Label)Master.FindControl("lblPatientid")).Text;
        lblpname.Text = ((Label)Master.FindControl("lblPatientname")).Text;
        if (!IsPostBack)
        {
            TotalApp();
            TodayApp();
        }
    }
    protected void TodayApp()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Appointment] WHERE CONVERT(date, [Added_On]) = CONVERT(date, GETDATE()) where [Paitent_Id]=@Paitent_Id", con);
            cmd.Parameters.AddWithValue("@Paitent_Id", lblpatient.Text);
            int count = (int)cmd.ExecuteScalar();
            todayapp.Text = count.ToString();

        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }
    protected void TotalApp()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Appointment] where [Paitent_Id]=@Paitent_Id", con);
            cmd.Parameters.AddWithValue("@Paitent_Id", lblpatient.Text);
            int count = (int)cmd.ExecuteScalar();
            lblapp.Text = count.ToString();

        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }

}