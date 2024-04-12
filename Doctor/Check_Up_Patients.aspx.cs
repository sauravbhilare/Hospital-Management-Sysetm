using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Doctor_Check_Up_Patients : System.Web.UI.Page
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
        cmd.CommandText = "select * from [dbo].[Check_Up] where  Checked_By_Id=@Checked_By_Id ";
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@Checked_By_Id", lbldocid.Text);


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
        
    }
    protected void gvCheckup_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
}