using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_Dashboard : System.Web.UI.Page
{
    string strcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            StaffCount();
            DoctorsCount();
            PatientsCount();
            Appoinments();
        }
    }

    protected void StaffCount()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Staff]", con);
            int count = (int)cmd.ExecuteScalar();
            ttlstaff.Text = count.ToString();

        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }
    protected void DoctorsCount()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Doctors]", con);
            int count = (int)cmd.ExecuteScalar();
            ttldoctors.Text = count.ToString();

          

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
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Paitents_Registration]", con);
            int count = (int)cmd.ExecuteScalar();
            ttlpatients.Text = count.ToString();

        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }
    protected void Appoinments()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(Appointment_Id) FROM [dbo].[Appointment] WHERE CONVERT(date, [Added_On]) = CONVERT(date, GETDATE()) ", con);

            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                int Count = Convert.ToInt32(result);
                lbltodayapp.Text = Count.ToString();
            }
            else
            {
                lbltodayapp.Text = "0";
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