using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_Dashboard1 : System.Web.UI.Page
{
    string strcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblid.Text = ((Label)Master.FindControl("lblstaffid")).Text;
        if (!IsPostBack)
        {
            TodayTask();
            TotalTask();
            BindTask();
        }
    }

    //protected void StaffCount()
    //{
    //    SqlConnection con = new SqlConnection(strcon);
    //    try
    //    {
    //        con.Open();
    //        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Staff]", con);
    //        int count = (int)cmd.ExecuteScalar();
    //        ttlstaff.Text = count.ToString();

    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //    finally
    //    {
    //        con.Close();
    //    }
    //}
    //protected void DoctorsCount()
    //{
    //    SqlConnection con = new SqlConnection(strcon);
    //    try
    //    {
    //        con.Open();
    //        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Doctors]", con);
    //        int count = (int)cmd.ExecuteScalar();
    //        ttldoctors.Text = count.ToString();



    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //    finally
    //    {
    //        con.Close();
    //    }
    //}
    protected void TodayTask()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Shift_Master] where [Staff_Id]=@Staff_Id", con);
            cmd.Parameters.AddWithValue("@Staff_Id", lblid.Text);
            int count = (int)cmd.ExecuteScalar();
            lbltotaltask.Text = count.ToString();

        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }
    protected void TotalTask()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Shift_Master] WHERE CONVERT(date, [Shift_Date]) = CONVERT(date, GETDATE()) and [Staff_Id]=@Staff_Id ", con);
            cmd.Parameters.AddWithValue("@Staff_Id", lblid.Text);

            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                int Count = Convert.ToInt32(result);
                lbltodaytask.Text = Count.ToString();
            }
            else
            {
                lbltotaltask.Text = "0";
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

    protected void BindTask()
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select * from [dbo].[Shift_Master] where [Staff_Id]=@Staff_Id order by Shift_Id desc";
        cmd.Parameters.AddWithValue("@Staff_Id", lblid.Text);

        cmd.Connection = con;
        try
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            gvTask.DataSource = ds;
            gvTask.DataBind();
            gvTask.Visible = true;
            if (ds.Rows.Count > 0)
            {

                gvTask.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvTask.FooterRow.TableSection = TableRowSection.TableFooter;
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