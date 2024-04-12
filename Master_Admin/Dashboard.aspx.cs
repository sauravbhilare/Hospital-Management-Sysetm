using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Master_Admin_Dashboard : System.Web.UI.Page
{
    string strcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            StaffCount();
            DoctorsCount();
            PatientsCount();
            Collection();
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
    protected void Collection()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT SUM(Fees) FROM [dbo].[Check_Up]", con);
            SqlCommand cmd1 = new SqlCommand("SELECT SUM(Fees) FROM [dbo].[Check_Up] WHERE CONVERT(date, Checked_On) = CONVERT(date, GETDATE()) ", con);

            object result = cmd.ExecuteScalar();
            object result1 = cmd1.ExecuteScalar();
            if (result != DBNull.Value)
            {
                int sum = Convert.ToInt32(result);
                lbltotal.Text = sum.ToString();
            }
            else
            {
                lbltotal.Text = "0";
            }
            if (result1 != DBNull.Value)
            {
               
                int sum1 = Convert.ToInt32(result1);
                todaytotal.Text = sum1.ToString();
            }
            else
            {
                todaytotal.Text = "0";
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