using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Patient_View_Appointments : System.Web.UI.Page
{
    static String strcon = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
    SqlConnection con = new SqlConnection(strcon);
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblpatient.Text = ((Label)Master.FindControl("lblPatientid")).Text;
        lblpname.Text = ((Label)Master.FindControl("lblPatientname")).Text;
        BindStaff();
    }
    protected void BindStaff()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "select * from [dbo].[Appointment] where  [Paitent_Id]=@Paitent_Id order by Appointment_Id desc";
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@Paitent_Id", lblpatient.Text);


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
            Response.Redirect("Appointment.aspx?Appointment_Id=" + id);
        }
        else if (e.CommandName == "cancle")
        {
            string id1 = e.CommandArgument.ToString();
            try
            {
                con.Open();
                cmd = new SqlCommand("Update [dbo].[Appointment] set [Status]=@Status where Appointment_Id=@Appointment_Id", con);
                cmd.Parameters.AddWithValue("@Appointment_Id", id1);
                cmd.Parameters.AddWithValue("@Status", "Cancle");
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Appointment Cancled successfully...!');", true);
            }
            catch (Exception ex)
            {
                ex.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error Occard...!');", true);
            }
            finally
            {
                con.Close();
                BindStaff();

            }
        }
    }
    protected void gvAppointment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblappstatus = (Label)e.Row.FindControl("lblappstatus");
            if (lblappstatus != null)
            {
                string status = lblappstatus.Text; // Assuming the status is already populated in the label

                switch (status)
                {
                    case "Confirmed":
                        lblappstatus.CssClass = "badge badge-pill badge-warning"; // Yellow badge
                        break;
                    case "Pending":
                        lblappstatus.CssClass = "badge badge-pill badge-danger"; // Red badge
                        break;
                    case "Complete":
                        lblappstatus.CssClass = "badge badge-pill badge-success"; // Green badge
                        break;
                    case "Cancle":
                        lblappstatus.CssClass = "badge badge-pill badge-Primary"; // Green badge
                        break;
                    default:
                        lblappstatus.CssClass = "badge badge-pill"; // Default class
                        break;
                }
            }
        }
    }
    protected void gvAppointment_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
}