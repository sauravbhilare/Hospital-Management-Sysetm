using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Doctor_Dashboard : System.Web.UI.Page
{
    string strcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        doctorid.Text = ((Label)Master.FindControl("lbldoctid")).Text;
        doctorname.Text = ((Label)Master.FindControl("lbldoctname")).Text;
        if (!IsPostBack)
        {
            TotalApp();
            TodayApp();
            PatientsCount();
            Collection();
        }
    }
    protected void TodayApp()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Appointment] WHERE CONVERT(date, [Added_On]) = CONVERT(date, GETDATE()) where [Appoint_To_Id]=@Appoint_To_Id", con);
            cmd.Parameters.AddWithValue("@Appoint_To_Id", doctorid.Text);
            int count = (int)cmd.ExecuteScalar();
            ttltdapp.Text = count.ToString();

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
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Appointment] where [Appoint_To_Id]=@Appoint_To_Id", con);
            cmd.Parameters.AddWithValue("@Appoint_To_Id",doctorid.Text);
            int count = (int)cmd.ExecuteScalar();
            lbltapp.Text = count.ToString();

        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }
    protected void PatientsCount()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Appointment] where [Appoint_To_Id]=@Appoint_To_Id", con);
            cmd.Parameters.AddWithValue("@Appoint_To_Id",doctorid.Text);
            int count = (int)cmd.ExecuteScalar();
            ttlPatients.Text = count.ToString();

        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }
    protected void Collection()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT SUM(Fees) FROM [dbo].[Check_Up] where [Checked_By_Id]=@Checked_By_Id ", con);
            cmd.Parameters.AddWithValue("@Checked_By_Id",doctorid.Text);
            SqlCommand cmd1 = new SqlCommand("SELECT SUM(Fees) FROM [dbo].[Check_Up] WHERE CONVERT(date, Checked_On) = CONVERT(date, GETDATE()) and [Checked_By_Id]=@Checked_By_Id ", con);
            cmd1.Parameters.AddWithValue("@Checked_By_Id", doctorid.Text);
            object result = cmd.ExecuteScalar();
            object result1 = cmd1.ExecuteScalar();
            if (result != DBNull.Value)
            {
                int sum = Convert.ToInt32(result);
                ttlfees.Text = sum.ToString();
            }
            else
            {
                ttlfees.Text = "0";
            }
            if (result1 != DBNull.Value)
            {

                int sum1 = Convert.ToInt32(result1);
                todaytotalfees.Text = sum1.ToString();
            }
            else
            {
                todaytotalfees.Text = "0";
            }
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