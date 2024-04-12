using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Patient_Checkup : System.Web.UI.Page
{
    static String strcon = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
    SqlConnection con = new SqlConnection(strcon);
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblpatient.Text = ((Label)Master.FindControl("lblPatientid")).Text;
        lblpname.Text = ((Label)Master.FindControl("lblPatientname")).Text;
        if (!IsPostBack)
        {
            BindStaff();
        }

    }
    protected void BindStaff()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "select * from [dbo].[Check_Up] where  [Patient_Id]=@Patient_Id ";
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@Patient_Id", lblpatient.Text);


        try
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            gvCheckup.DataSource = ds;
            gvCheckup.DataBind(); // Bind the GridView after setting the data source

            // Check if there are rows in the DataTable
            if (ds.Rows.Count > 0)
            {

                gvCheckup.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvCheckup.FooterRow.TableSection = TableRowSection.TableFooter;
            }

        }
        catch (Exception ex)
        {
            // Handle the exception (log or display error message)
        }
        finally
        {
            con.Close();
        }
    }
    protected void gvCheckup_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
    protected void gvCheckup_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "View")
        {
            string id1 = e.CommandArgument.ToString();
            lblappid.Text = id1;
            bindgrid();
            bindcheckdetails();
            ScriptManager.RegisterStartupScript(this, GetType(), "showModel3", "showModel3();", true);
        }

    }
    protected void gvCheckup_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void bindgrid()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand("select * from [dbo].[Medicine_Master] where [Appointment_Id]=@Appointment_Id", con);
            cmd.Parameters.AddWithValue("Appointment_Id", lblappid.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            gvProduct.DataSource = ds;
            gvProduct.DataBind(); // Bind the GridView after setting the data source

        
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }
    protected void Closebtn1_Click(object sender, EventArgs e)
    {
        BindStaff();
    }

    protected void bindcheckdetails()
    {
        try
        {
            con.Open();

            cmd = new SqlCommand("SELECT A.[Appointment_Id],A.[Name],A.[Mobile],A.[Gmail],A.[Appointment_Reason],A.[Appointment_Type],A.[Appoitment_Date],A.[Time_Slot],A.[Contact_Preferance],A.[Appoint_To_Name],A.[Status],C.[Check_Up_Details],C.[Prescribe_Test],C.[Checked_On]FROM [dbo].[Appointment] A LEFT JOIN [dbo].[Check_Up] C ON A.[Appointment_Id] = C.[Apointment_Id] WHERE A.[Appointment_Id] = @Appointment_Id;",con);
            cmd.Parameters.AddWithValue("Appointment_Id",lblappid.Text);

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
          
            lblreason.Text = dt.Rows[0]["Appointment_Reason"].ToString();
            lbltype1.Text = dt.Rows[0]["Appointment_Type"].ToString();
            lblappdate.Text = DateTime.Parse(dt.Rows[0]["Appoitment_Date"].ToString()).ToString("dd/MM/yyyy");

            lbltimeslot.Text = dt.Rows[0]["Time_Slot"].ToString();
            lblstatus.Text = dt.Rows[0]["Status"].ToString();
            lbldoct.Text = dt.Rows[0]["Appoint_To_Name"].ToString();

            lbldetails.Text = dt.Rows[0]["Check_Up_Details"].ToString();
            lbldoct.Text = dt.Rows[0]["Appoint_To_Name"].ToString();
        }
        catch(Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }
}