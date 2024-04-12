using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Doctor_View_Appointments : System.Web.UI.Page
{
    static String strcon = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
    SqlConnection con = new SqlConnection(strcon);
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        lbldocid.Text = ((Label)Master.FindControl("lbldoctid")).Text;
        BindStaff();
    }
    protected void BindStaff()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "select * from [dbo].[Appointment] where  Appoint_To_Id=@Appoint_To_Id order by Appointment_Id desc";
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@Appoint_To_Id", lbldocid.Text);


        try
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            gvAppointment.DataSource = ds;
            gvAppointment.DataBind(); // Bind the GridView after setting the data source

            // Check if there are rows in the DataTable
            if (ds.Rows.Count > 0)
            {
              
                gvAppointment.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvAppointment.FooterRow.TableSection = TableRowSection.TableFooter;
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
    protected void gvAppointment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
    protected void gvAppointment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        if (e.CommandName == "Update")
        {
            Response.Redirect("Check_Up.aspx?Appointment_Id=" + id);
        }
        //else if (e.CommandName == "Delete1")
        //{
        //    string id1 = e.CommandArgument.ToString();
        //    try
        //    {
        //        con.Open();
        //        cmd = new SqlCommand("Delete From [dbo].[Appointment] where Appointment_Id=@Appointment_Id", con);
        //        cmd.Parameters.AddWithValue("@Appointment_Id", id1);
        //        cmd.ExecuteNonQuery();
        //        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Appointment Deleted successfully...!');", true);
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error Occard...!');", true);
        //    }
        //    finally
        //    {
        //        con.Close();
        //        BindStaff();

        //    }
        //}
    }
    protected void gvAppointment_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
}